using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using StoryQ;

namespace GOOS.Tests
{
    public class TestFixtureShould
    {
        [Test]
        public void RunBehaviourOk()
        {
            // Story is BDD is configured
            // In order to Test expected application behaviour
            // As a Developer
            // I want to ensure this test will pass
            // With Scenario: Setting up testing project 
            // Given everything everything has been installed
            // When the test is ran
            // Then it should assert true

            new Story("BDD is configured").Tag("iteration-0")
                .InOrderTo("Test expected application behaviour")
                .AsA("Developer")
                .IWant("To ensure BDD test framework is working")
                .WithScenario("Setting up testing project")
                  .Given(EverythingIsSetup)
                  .When(TheTestIsRan)
                  .Then(TestShouldAssert)

                  .ExecuteWithReport();
        }

        private void EverythingIsSetup()
        {
            Assert.True(true);
        }

        private void TheTestIsRan()
        {
            Assert.True(true);
        }

        private void TestShouldAssert()
        {
            Assert.True(true);
        }


        [Test]
        public void RunUnitOk()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public void RunMockOk()
        {
            var calc = Substitute.For<ICalc>();
            calc.Add(1, 2).Returns(3);

            Assert.That(calc.Add(1, 2), Is.EqualTo(3));
        }

        public interface ICalc
        {
            int Add(int a, int b);
        }
    }
}
