using System;
using System.Collections.Generic;
using System.Text;

namespace DbProvider.SqlManager
{
    public interface ISqlConnectionItem : IDisposable
    {
        Guid Owner { get; }
        AppDbContext Context { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Close();
    }
}
