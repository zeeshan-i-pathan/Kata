using System;
namespace Banking.VO
{
    public class TransferRequestVO : BaseVO
    {
       public string SortCode { get; init; }

       public TransferRequestVO(uint AccountId, float Amount,string sortCode, string reference, string accountNum)
            : base(AccountId, Amount)
       {
            this.SortCode = sortCode;
            this.Reference = reference;
            this.AccountNum = accountNum;
       }

       public DateOnly Date { get; init; }
       public string Reference { get; init; }
       public string AccountNum { get; init; }
    }
}

