using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using Banking.VO;
using Banking.Services;
using Banking.Models;
using Banking.Dto;
namespace Banking.Test
{
    [Binding]
    public class CaseSteps
    {
        private readonly ScenarioContext _scenarioContext;

        Account account;
        Response response;

        public CaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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

    }
}