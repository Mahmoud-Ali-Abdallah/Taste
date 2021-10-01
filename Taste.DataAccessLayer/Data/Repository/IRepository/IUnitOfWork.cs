using System;
using System.Collections.Generic;
using System.Text;

namespace Taste.DataAccessLayer.Data.Repository.IRepository
{
    public interface IUnitOfWork<TRepository> :IDisposable
    {
        TRepository Repository { get; }

        bool Save();
    }
}
