using System;
using Banking.DAL;
namespace Banking.Test
{
	public class MockUnitOfWork : IUnitOfWork
	{
		public MockUnitOfWork()
		{
		}

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

