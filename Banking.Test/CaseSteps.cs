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
using Banking.DAL;
using System.Security.Principal;

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
            WithdrawalService withdrawalService = new WithdrawalService(new MockUnitOfWork());
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
            response = new DepositService(new MockUnitOfWork()).TryTransaction(account, depositRequest);
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
            Console.WriteLine("Could resolve");
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
            if (fromAccount != null && toAccount != null && toAccount.AccountNum != null && toAccount.SortCode != null)
            {
                TransferRequestVO transferRequest = new TransferRequestVO(
                    AccountId: fromAccount.Id,
                    Amount: p0,
                    sortCode: toAccount.SortCode,
                    reference: "",
                    accountNum: toAccount.AccountNum);
                TransferService transferService = new TransferService(unitOfWork: new MockUnitOfWork(),withdrawalService: new WithdrawalService(new MockUnitOfWork()), depositService: new DepositService(new MockUnitOfWork()));
                transferService.TryTransaction(fromAccount: fromAccount, toAccount: toAccount, transferRequest: transferRequest);
            }
        }

        [Then(@"account (.*) balance should be (.*)")]
        public void ThenAccountBalanceShouldBe(int p0, int p1)
        {
            Account? account = objectContainer.Resolve<List<Account>>().Find(account => account.Id == p0);
            account?.Balance.Should().Be(p1);
        }

        [Given(@"account details in DB")]
        public void GivenAccountDetailsInDB(Table table)
        {
            IEnumerable<Account> accounts = table.CreateSet<Account>();
            UnitOfWork unitOfWork = this.objectContainer.Resolve<UnitOfWork>();
            foreach (Account account in accounts)
            {
                unitOfWork.AccountRepository.Insert(account);
            }
            unitOfWork.Save();
        }

        [Then(@"the DB should have (.*) records")]
        public async void ThenTheDBShouldHaveRecords(int p0)
        {
            UnitOfWork unitOfWork = this.objectContainer.Resolve<UnitOfWork>();
            var ats = await unitOfWork.AccountRepository.Get();
            ats.Count().Should().Be(p0);
        }

        [When(@"I withdraw (.*)")]
        public void WhenIWithdraw(int p0)
        {
            RequestVO requestVO = new RequestVO(1, p0);
            objectContainer.Resolve<WithdrawalService>().Process(requestVO);
        }

        [When(@"deposit (.*)")]
        public void WhenDeposit(int p0)
        {
            RequestVO requestVO = new RequestVO(1, p0);
            objectContainer.Resolve<DepositService>().Process(requestVO);

        }

        [When(@"I transfer (.*) from my account to account (.*)")]
        public async void WhenITransferFromMyAccountToAccount(int p0, uint p1)
        {
            UnitOfWork unitOfWork = objectContainer.Resolve<UnitOfWork>();
            Account toAccount = await unitOfWork.AccountRepository.GetByID(p1);
            TransferRequestVO transferRequest = new TransferRequestVO(
                    AccountId: 1,
                    Amount: p0,
                    sortCode: toAccount.SortCode,
                    reference: "",
                    accountNum: toAccount.AccountNum);
            objectContainer.Resolve<TransferService>().Process(transferRequest);
            //_scenarioContext.Pending();
        }

        [Then(@"my account balance should be (.*)")]
        public async void ThenMyAccountBalanceShouldBe(int p0)
        {
            UnitOfWork unitOfWork = objectContainer.Resolve<UnitOfWork>();
            Account account = await unitOfWork.AccountRepository.GetByID((uint)1);
            account.Balance.Should().Be(p0);
        }

        [Then(@"I should have (.*) transactions")]
        public async void ThenIShouldHaveTransactions(int p0)
        {
            UnitOfWork unitOfWork = objectContainer.Resolve<UnitOfWork>();
            Account account = await unitOfWork.AccountRepository.GetByID((uint)1);
            account.Transactions.Count().Should().Be(p0);
        }

    }
}