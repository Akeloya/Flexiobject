using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DbProvider
{
    public class SqlManager
    {
        [ThreadStatic] private static DbConnection _dbConnection;
        [ThreadStatic] private static Dictionary<Guid, ISqlConnectionItem> _sqlConnectionItems = new();
        [ThreadStatic] private static Guid _owner;
        [ThreadStatic] private static DbTransaction _transaction;
        private static AppDbSettings _settings;
        private static readonly object _syncConnections = new();

        public static void RegisterManager(AppDbSettings settings)
        {
            _settings = settings;
        }

        public static ISqlConnectionItem Register(Guid owner)
        {
            lock (_syncConnections)
            {
                if (_sqlConnectionItems == null)
                    _sqlConnectionItems = new Dictionary<Guid, ISqlConnectionItem>();
                if (_sqlConnectionItems.ContainsKey(owner))
                    return _sqlConnectionItems[owner];
                if (_owner != Guid.Empty && _owner != owner)
                {
                    var item = new SqlConnectionItem(owner, _dbConnection);
                    item.OnClose += OnClose;
                    item.OnComminTransaction += OnComminTransaction;
                    item.OnRollbackTransaction += OnRollbackTransaction;
                    item.OnBeginTransaction += OnBeginTransaction;
                    _sqlConnectionItems.Add(owner, item);
                    return item;
                }
                if (_dbConnection?.State != ConnectionState.Open)
                {
                    var context = new AppDbContext(_settings);
                    _dbConnection = context.Database.GetDbConnection();
                    _owner = owner;
                    _dbConnection.Open();
                    var item = new SqlConnectionItem(owner, _dbConnection);
                    item.OnClose += OnClose;
                    item.OnComminTransaction += OnComminTransaction; ;
                    item.OnRollbackTransaction += OnRollbackTransaction;
                    item.OnBeginTransaction += OnBeginTransaction;
                    _sqlConnectionItems.Add(owner, item);
                    return item;
                }
            }

            return _sqlConnectionItems[owner];
        }

        private static void OnBeginTransaction(object sender, SqlManagerGetTransactionEventArgs e)
        {
            if (_transaction == null && e.Owner == _owner)
            {
                _transaction = _dbConnection.BeginTransaction();
            }
            e.Transaction = _transaction;
        }
        private static void OnRollbackTransaction(object sender, SqlManagerGetTransactionEventArgs e)
        {
            _transaction?.Rollback();
            _transaction = null;
        }

        private static void OnClose(object sender, Guid e)
        {
            lock (_syncConnections)
            {
                _sqlConnectionItems.Remove(e);
                if (e == _owner && _sqlConnectionItems.Count > 0)
                    _owner = _sqlConnectionItems.First().Key;
                if (_sqlConnectionItems.Count == 0)
                {
                    _dbConnection.Close();
                    _transaction?.Dispose();
                    _transaction = null;
                    _owner = Guid.Empty;
                }
            }
        }
        private static void OnComminTransaction(object sender, SqlManagerGetTransactionEventArgs e)
        {
            if (_owner == e.Owner)
            {
                _transaction?.Commit();
                _transaction = null;
            }
        }
    }

    internal class SqlManagerGetTransactionEventArgs : EventArgs
    {
        public Guid Owner { get; }
        public DbTransaction Transaction { get; set; }
        public SqlManagerGetTransactionEventArgs(Guid owner)
        {
            Owner = owner;
        }
    }
}
