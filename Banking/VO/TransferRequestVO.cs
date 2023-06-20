using System;
namespace Banking.VO
{
    public record TransferRequestVO(uint AccountId, float Amount, DateOnly Date, string Reference, string AccountNum, string sortCode) :
        RequestVO(AccountId, Amount), IRequest;
}

