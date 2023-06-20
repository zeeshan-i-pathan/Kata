using System;
namespace Banking.VO;

public enum RequestType
{
    Deposit,
    Withdraw,
    Transfer
}

public abstract class BaseVO : IBaseVO {
    public BaseVO(uint accountId, float amount)
    {
        this.AccountId = accountId;
        this.Amount = amount;
    }
    public uint AccountId { get; init; }
    public float Amount { get; init; }
};

