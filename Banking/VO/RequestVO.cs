using System;
namespace Banking.VO
{
    public record RequestVO(uint AccountId, float Amount): IRequest;
}

