using System;
using Banking.Dto;
using Banking.Models;
using Banking.VO;

namespace Banking.Services
{
	public class DepositService : ITransactionService<RequestVO>
	{
        public void Process(RequestVO Request)
        {
            // Begin Transaction
            // Find the Account using repository;
            // try transcation
            // commit if transaction successful
            throw new NotImplementedException();
        }

        public Response TryTransaction(Account account, RequestVO depositRequest)
        {
            if (depositRequest.AccountId==account.Id && depositRequest.Amount >= 0)
            {
                account.Balance += depositRequest.Amount;
                return new Response { Message = ValidResponse.Accepted.ToString() };
            }
            return new Response();
        }
    }
}

