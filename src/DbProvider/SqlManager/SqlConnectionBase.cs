using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace FlexiObject.DbProvider
{
    public class SqlConnectionItem : ISqlConnectionItem
    {
        private bool _disposed;
        private readonly DbConnection _connection;
        public AppDbContext Context { get; }
        public Guid Owner { get; }

        public SqlConnectionItem(Guid  owner, AppDbContext context, DbConnection connection)
        {
            _connection = connection;
            Owner = owner;
            Context = context;
        }
        public SqlConnectionItem(Guid owner, DbConnection connection)
        {
            _connection = connection;
            Owner = owner;
            Context = new AppDbContext(connection);
        }
        public void BeginTransaction()
        {
            OnBeginTransaction.Invoke(this, new SqlManagerGetTransactionEventArgs(Owner));
        }

        public void Close()
        {
            OnClose.Invoke(this, Owner);
        }

        public void CommitTransaction()
        {
            OnComminTransaction.Invoke(this, new SqlManagerGetTransactionEventArgs(Owner));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~SqlConnectionItem()
        {
            Dispose(false);
        }
        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Close();
                _connection.Dispose();                
            }

            _disposed = true;
        }
        internal event EventHandler<Guid> OnClose;
        internal event EventHandler<SqlManagerGetTransactionEventArgs> OnBeginTransaction;
        internal event EventHandler<SqlManagerGetTransactionEventArgs> OnComminTransaction;
        internal event EventHandler<SqlManagerGetTransactionEventArgs> OnRollbackTransaction;
    }
}
