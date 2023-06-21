using System;
namespace Banking.DAL
{
	public interface IUnitOfWork
	{
        public void BeginTransaction();
        public void Commit();
        public void Rollback();
        public void Save();

    }
}

