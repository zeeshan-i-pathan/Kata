using System;
using Banking.Context;
using Banking.Models;
using Microsoft.EntityFrameworkCore.Storage;
namespace Banking.DAL;

public class UnitOfWork : IDisposable, IUnitOfWork
{
    private BankingContext context;
    private GenericRepository<Account> accountRepository;
    private GenericRepository<Branch> branchRepository;
    private GenericRepository<Transaction> transactionRepository;
    private IDbContextTransaction dbContextTransaction;
    public UnitOfWork(BankingContext context)
    {
        this.context = context;
    }

    public GenericRepository<Account> AccountRepository
    {
        get
        {

            return this.accountRepository ??= new GenericRepository<Account>(context);
        }
    }

    public GenericRepository<Transaction> TransactionRepository
    {
        get
        {

            return this.transactionRepository ??= new GenericRepository<Transaction>(context);
        }
    }

    public GenericRepository<Branch> BranchRepository
    {
        get
        {
            return this.branchRepository ??= new GenericRepository<Branch>(context);
        }
    }

    public void BeginTransaction()
    {
        dbContextTransaction = context.Database.BeginTransaction();
    }

    public void Commit()
    {
        dbContextTransaction.Commit();
    }

    public void Rollback()
    {
        dbContextTransaction.Rollback();
    }

    public void Save()
    {
        context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
                dbContextTransaction.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

