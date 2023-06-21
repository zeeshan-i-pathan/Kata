using System;
using Banking.Context;
using Banking.DAL;
using Banking.Models;
using BoDi;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;

namespace Banking.Test
{
    [Binding]
    public sealed class TestInitialize
    {
        IObjectContainer objectContainer;
        public TestInitialize(IObjectContainer objectContainer)
        {
            //    Console.WriteLine("----TestInitializer called-----" + objectContainer.Resolve<ITest>().Name);
            this.objectContainer = objectContainer;
        }

        //[BeforeFeature]
        //public static void BeforeFeature(FeatureContext featureContext, IObjectContainer objectContainer)
        //{
        //    objectContainer.RegisterInstanceAs<ITest>(new Test { Name = featureContext.FeatureInfo.Title });
        //    Console.WriteLine("Starting " + featureContext.FeatureInfo.Title);
        //}

        //[AfterFeature]
        //public static void AfterFeature(FeatureContext featureContext, IObjectContainer objectContainer)
        //{
        //    Console.WriteLine("Finished "+ objectContainer.Resolve<ITest>().Name);
        //}

        //[BeforeScenario]
        //public void BeforeScenario()
        //{
        //    Console.WriteLine(this.objectContainer.Resolve<ITest>().Name);
        //}

        [BeforeScenario("Intrabank")]
        public void BeforeScenarioIntrabank()
        {
            this.objectContainer.RegisterInstanceAs<List<Account>>(new List<Account>());
        }

        [BeforeFeature("FromDb")]
        public static void BeforeFeatureFromDb(IObjectContainer objectContainer)
        {
            var options = new DbContextOptionsBuilder<BankingContext>()
                .UseInMemoryDatabase(databaseName: "BMS_DB")
                .Options;
            BankingContext bankingContext = new BankingContext(options);
            objectContainer.RegisterInstanceAs<BankingContext>(bankingContext);
            UnitOfWork unitOfWork = new UnitOfWork(bankingContext);
            objectContainer.RegisterInstanceAs<UnitOfWork>(unitOfWork);
        }

        // [AfterScenario("FromDb")]
        // public void AfterScenarioFromDB()
        // {
        //     this.objectContainer.Resolve<BankingContext>().Database.EnsureDeleted();
        // }
    }
}

