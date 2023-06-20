using System;
namespace Banking.Models
{
	public enum TransactionType
	{
		Credit,
		Debit
	}

	public enum TransactionStatus
	{
		Pending,
		Success
	}

	public class Transaction
	{
		public uint Id { get; set; }
		public uint AccountId { get; set; }
		public float Amount { get; set; }
		public DateOnly Date { get; set; }
		public string Description { get; set; } = "";
		public TransactionType Indicator { get; set; }
		public TransactionStatus Status { get; set; }
	}
}

