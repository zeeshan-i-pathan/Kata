using System;
using Banking.Models;
using Banking.Dto;
using Banking.VO;
namespace Banking.Services;

public class WithdrawalService : ITransactionService<RequestVO>
{
    public void Process(RequestVO Request)
    {
        throw new NotImplementedException();
    }

    public Response TryTransaction(Account account, RequestVO withdrawalRequest)
    {
        if (account.Id == withdrawalRequest.AccountId && withdrawalRequest.Amount > 0)
        {
            if (account.Balance > withdrawalRequest.Amount)
            {
                account.Balance -= withdrawalRequest.Amount;
                return new Response { Message = ValidResponse.Accepted.ToString() };
            }
        }
        return new Response();
    }

}

