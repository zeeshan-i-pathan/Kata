using System;
namespace Banking.VO
{
	public interface IRequest
	{
		public uint AccountId { get; init; }
		public float Amount { get; init; }
	}
}

