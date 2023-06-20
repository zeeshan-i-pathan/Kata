using System;
namespace Banking.VO
{
	public interface IBaseVO
	{
        public uint AccountId { get; init; }
        public float Amount { get; init; }
    }
}

