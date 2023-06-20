using System;
namespace Banking.VO;

public class RequestVO : BaseVO
{
    public RequestVO(uint AccountId, float Amount) : base(AccountId, Amount)
    {
    }
}

