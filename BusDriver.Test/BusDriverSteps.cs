using System;
using TechTalk.SpecFlow;
using DrivingGame;
using FluentAssertions;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
        }
        private Game game;

        [Given(@"(.*) Bus Drivers")]
        public void GivenBusDrivers(int args1)
        {
            game = new Game();
            for (int i = 0; i < args1; i++)
            {
                game.BusDrivers.Add(new DrivingGame.BusDriver());
            }
        }

        [When(@"Driver (.*)'s routes as \[(.*), (.*), (.*), (.*)]")]
        public void WhenDriverSRoutesAs(int p0, int p1, int p2, int p3, int p4)
        {
            int[] a = { p1, p2, p3, p4 };
            game.BusDrivers[p0 - 1].Routes.AddRange(a);
            game.BusDrivers[p0 - 1].Gossip.Add(p0);

        }

        [When(@"Driver (.*)'s routes as \[(.*), (.*), (.*), (.*), (.*)]")]
        public void GivenDriversroutesas(int args1, int args2, int args3, int args4, int args5, int args6)
        {
            int[] a = { args2, args3, args4, args5, args6 };
            game.BusDrivers[args1 - 1].Routes.AddRange(a);
            game.BusDrivers[args1 - 1].Gossip.Add(args1);

        }

        [Then(@"All the Gossip should go around after (.*) stops")]
        public void ThenAlltheGossipshouldgoaroundafterstops(int args1)
        {
            game.DriveAround().StopsVisited.Should().Be(args1);
        }

        [When(@"Driver (.*)'s routes as \[(.*), (.*), (.*)]")]
        public void WhenDriversroutesas(int args1, int args2, int args3, int args4)
        {
            int[] a = { args2, args3, args4 };
            game.BusDrivers[args1 - 1].Routes.AddRange(a);
            game.BusDrivers[args1 - 1].Gossip.Add(args1);
        }

        [Then(@"The go around (.*) stops with no gossip")]
        public void ThenThegoaroundstopswithnogossip(int args1)
        {
            game.DriveAround().StopsVisited.Should().Be(args1);
        }


    }
}