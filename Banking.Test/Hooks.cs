using System;
using BoDi;
using TechTalk.SpecFlow;

namespace Banking.Test
{
    [Binding]
    public sealed class TestInitialize
	{
        //IObjectContainer objectContainer;
        //public TestInitialize(IObjectContainer objectContainer)
        //{
        //    Console.WriteLine("----TestInitializer called-----" + objectContainer.Resolve<ITest>().Name);
        //    this.objectContainer = objectContainer;
        //}

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
    }
}

