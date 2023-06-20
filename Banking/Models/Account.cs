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
    public uint AccountNum { get; set; }
    public uint SortCode { get; set; }
    public AccountType AccountType { get; set; } = AccountType.Savings;
    public double Balance { get; set; }
}

