using System;
using System.Collections.Generic;
using System.Text;
using Taste.DataAccessLayer.Data.Repository.IRepository;

namespace Taste.DataAccessLayer.Data.Repository
{
    public class UnitOfWork<TRepository> : IUnitOfWork<TRepository>
    {
        private readonly ApplicationDbContext db;
        private readonly TRepository repository;

        public UnitOfWork(ApplicationDbContext _db , TRepository repository)
        {
            this.db = _db;
            this.repository = repository;
        }

        public TRepository Repository => repository;

        public void Dispose()
        {
            db.Dispose();
            
        }

        public bool Save()
        {
            return (db.SaveChanges() >= 1 ? true : false) ;
        }
    }
}
