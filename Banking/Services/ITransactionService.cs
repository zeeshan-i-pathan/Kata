using System;
using Banking.Dto;
using Banking.Models;
using Banking.VO;

namespace Banking.Services
{
	public interface ITransactionService<T> where T: IRequest
	{
		public void Process(T Request);
	}
}