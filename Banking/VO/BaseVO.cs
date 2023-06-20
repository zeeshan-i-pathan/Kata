using System;
namespace Banking.VO
{
    public enum RequestType
    {
        Deposit,
        Withdraw,
        Transfer
    }

    public record BaseVO<T>(RequestType RequestType, T Request) where T : IRequest;
}

