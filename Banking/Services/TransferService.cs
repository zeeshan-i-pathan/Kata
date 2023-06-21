using System;
using Banking.DAL;
using Banking.Dto;
using Banking.Models;
using Banking.VO;

namespace Banking.Services
{
	public class TransferService : ITransactionService<TransferRequestVO>
    {
        WithdrawalService withdrawalService;
        DepositService depositService;
        IUnitOfWork unitOfWork;

        public TransferService(IUnitOfWork unitOfWork, WithdrawalService withdrawalService, DepositService depositService)
        {
            this.withdrawalService = withdrawalService;
            this.depositService = depositService;
            this.unitOfWork = unitOfWork;
        }

        public void Process(TransferRequestVO Request)
        {
            throw new NotImplementedException();
        }

        public Response TryTransaction(Account fromAccount, Account toAccount, TransferRequestVO transferRequest)
        {
            var response = new Response();
            if (fromAccount.Id == transferRequest.AccountId && transferRequest.Amount > 0)
            {
                response = withdrawalService.TryTransaction(account: fromAccount, withdrawalRequest: new RequestVO(transferRequest.AccountId,transferRequest.Amount));
                ValidResponse validResponse;
                var parsable = Enum.TryParse<ValidResponse>(response.Message, out validResponse);
                if (parsable && validResponse == ValidResponse.Accepted)
                {
                    response = depositService.TryTransaction(account: toAccount, depositRequest: new RequestVO(toAccount.Id, transferRequest.Amount));
                    return response;
                }
                return new Response();

            }
            return response;
        }

    }
}

