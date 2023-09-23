using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiObject.DbProvider
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
