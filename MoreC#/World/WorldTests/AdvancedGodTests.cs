using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using World.Factories;
using hw4;
using hw4.Exceptions;
using World.Creatures;
using World.Services;

namespace WorldTests
{
    [TestClass]
    public class AdvancedGodTests
    {
        private AdvancedGod god = new AdvancedGod();
        private GirlFactory girlFactory = new GirlFactory();
        private SmartGirlFactory smartGirlFactory = new SmartGirlFactory();
        private PrettyGirlFactory prettyGirlFactory = new PrettyGirlFactory();
        private BotanFactory botanFactory = new BotanFactory();
        private StudentFactory studentFactory = new StudentFactory();


        [TestMethod]
        [ExpectedException(typeof(WrongCoupleException))]
        public void NoHomoCouplesTest()
        {
            var girl = girlFactory.CreateHuman();
            var smartGirl = smartGirlFactory.CreateHuman();
            var child = god.Couple(girl, smartGirl);
        }

        [TestMethod]
        public void GirlStudentTest()
        {
            try
            {
                while (true)
                {
                    var girl = girlFactory.CreateHuman();
                    var student = studentFactory.CreateHuman(Sex.Male);
                    var child = god.Couple(girl, student);
                    if (child == null) continue;
                    Assert.IsTrue(child is Girl);
                    Assert.AreEqual(((Girl)child).MidName,
                        Generator.GenerateMidNameFromParentName(Sex.Female, student.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void GirlBotanTest()
        {
            try
            {
                while (true)
                {
                    var girl = girlFactory.CreateHuman();
                    var botan = botanFactory.CreateHuman(Sex.Male);
                    var child = god.Couple(girl, botan);
                    if (child == null) continue;
                    Assert.IsTrue(child is SmartGirl);
                    Assert.AreEqual(((SmartGirl)child).MidName,
                        Generator.GenerateMidNameFromParentName(Sex.Female, botan.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SmartGirlStudentTest()
        {
            try
            {
                while (true)
                {
                    var smartGirl = smartGirlFactory.CreateHuman();
                    var student = studentFactory.CreateHuman(Sex.Male);
                    var child = god.Couple(smartGirl, student);
                    if (child == null) continue;
                    Assert.IsTrue(child is Girl);
                    Assert.AreEqual(((Girl)child).MidName,
                        Generator.GenerateMidNameFromParentName(Sex.Female, student.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void SmartGirlBotanTest()
        {
            try
            {
                while (true)
                {
                    var smartGirl = smartGirlFactory.CreateHuman();
                    var botan = botanFactory.CreateHuman(Sex.Male);
                    var child = god.Couple(smartGirl, botan);
                    if (child == null) continue;
                    Assert.IsTrue(child is Book);
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void PrettyGirlStudentTest()
        {
            try
            {
                while (true)
                {
                    var prettyGirl = prettyGirlFactory.CreateHuman();
                    var student = studentFactory.CreateHuman(Sex.Male);
                    var child = god.Couple(prettyGirl, student);
                    if (child == null) continue;
                    Assert.IsTrue(child is PrettyGirl);
                    Assert.AreEqual(((PrettyGirl)child).MidName,
                        Generator.GenerateMidNameFromParentName(Sex.Female, student.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void PrettyGirlBotanTest()
        {
            try
            {
                while (true)
                {
                    var prettyGirl = prettyGirlFactory.CreateHuman();
                    var botan = botanFactory.CreateHuman(Sex.Male);
                    var child = god.Couple(prettyGirl, botan);
                    if (child == null) continue;
                    Assert.IsTrue(child is PrettyGirl);
                    Assert.AreEqual(((PrettyGirl)child).MidName,
                        Generator.GenerateMidNameFromParentName(Sex.Female, botan.Name));
                    break;
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
