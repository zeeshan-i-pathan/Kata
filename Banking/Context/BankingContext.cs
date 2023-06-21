using Banking.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking.Context;

public class BankingContext : DbContext
{
    public BankingContext(DbContextOptions<BankingContext> options) : base(options)
    {

    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}