using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Banking.VO;
using Banking.Services;
using Banking.Models;
using Banking.Dto;
using BoDi;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TechTalk.SpecFlow.Assist;

namespace Banking.Test
{
    [Binding]
    public class CaseSteps
    {
        private readonly ScenarioContext _scenarioContext;
        IObjectContainer objectContainer;

        Account account;
        Response response;
        List<Account> accounts = new List<Account>();

        public CaseSteps(ScenarioContext scenarioContext, IObjectContainer objectContainer)
        {
            _scenarioContext = scenarioContext;
            this.objectContainer = objectContainer;
        }

        [Given(@"an account with balance of (.*)")]
        public void Givenanaccountwithbalanceof(int args1)
        {
            account = new Account { Id = 1, Balance = (uint)args1 };
        }

        [When(@"requesting to withdraw (.*)")]
        public void Whenrequestingtowithdraw(int args1)
        {
            RequestVO withdrawalRequest = new RequestVO(AccountId: 1, Amount: (uint)args1);
            WithdrawalService withdrawalService = new WithdrawalService();
            response = withdrawalService.TryTransaction(account, withdrawalRequest);
        }

        [Then(@"the balance should be (.*)")]
        public void Thenthebalanceshouldbe(int args1)
        {
            account.Balance.Should().Be((uint)args1);
        }

        [Then(@"withdraw response should be ""(.*)""")]
        public void Givenwithdrawresponseshouldbe(string args1)
        {
            response.Message.Should().Be(args1);
        }

        [When(@"requesting to deposit (.*)")]
        public void Whenrequestingtodeposit(uint args1)
        {
            RequestVO depositRequest = new RequestVO(AccountId: 1, Amount: args1);
            response = new DepositService().TryTransaction(account, depositRequest);
        }

        [Then(@"deposit response should be ""(.*)""")]
        public void Givendepositresponseshouldbe(string args1)
        {
            response.Message.Should().Be(args1);
        }

        [Given(@"account details")]
        public void GivenAccountDetails(Table table)
        {
            var accounts = table.CreateSet<Account>();
            objectContainer.Resolve<List<Account>>().AddRange(accounts);
        }


        [When(@"I transfer (.*) from account (.*) to account (.*)")]
        public void WhenITransferFromAccountToAccount(int p0, uint p1, int p2)
        {
            Account? fromAccount = objectContainer
                                    .Resolve<List<Account>>()
                                    .Find(account => account.Id == p1);
            Account? toAccount = objectContainer
                                    .Resolve<List<Account>>()
                                    .Find(account => account.Id == p2);
            if (fromAccount!= null && toAccount != null && toAccount.AccountNum != null && toAccount.SortCode != null)
            {
                TransferRequestVO transferRequest = new TransferRequestVO(
                    AccountId: fromAccount.Id,
                    Amount: p0,
                    sortCode: toAccount.SortCode,
                    reference: "",
                    accountNum: toAccount.AccountNum);
                TransferService transferService = new TransferService(withdrawalService: new WithdrawalService(), depositService: new DepositService());
                transferService.TryTransaction(fromAccount: fromAccount, toAccount: toAccount, transferRequest: transferRequest);
            }
        }

        [Then(@"account (.*) balance should be (.*)")]
        public void ThenAccountBalanceShouldBe(int p0, int p1)
        {
            Account? account = objectContainer.Resolve<List<Account>>().Find(account => account.Id == p0);
            account?.Balance.Should().Be(p1);
        }

    }
}