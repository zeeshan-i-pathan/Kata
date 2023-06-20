using System;
namespace Banking.Models;

public enum AccountType
{
    Savings,
    Current
}

public class Account
{
    public uint Id { get; set; }
    public string AccountNum { get; set; }
    public string SortCode { get; set; }
    // public AccountType AccountType { get; set; } = AccountType.Savings;
    public double Balance { get; set; }
}

