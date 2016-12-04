using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw3;
using World.Creatures;
using World.Services;

namespace WorldTests
{
    /// <summary>
    /// Summary description for GodTests
    /// </summary>
    [TestClass]
    public class GodTests
    {
        God god = new God();

        [TestMethod]
        public void TestCreateStudentPair()
        {
            var student = god.CreateHuman();
            while (!(student is Student))
            {
                student = god.CreateHuman();
            }
            var pair = god.CreatePair(student);

            Assert.IsTrue(pair is Parent);
            Assert.AreEqual((student as Student).MidName,
                Generator.GenerateMidNameFromParentName(student.Sex, pair.Name));
        }

        [TestMethod]
        public void TestCreateBotanPair()
        {
            var student = god.CreateHuman();
            while (!(student is Botan))
            {
                student = god.CreateHuman();
            }
            var pair = god.CreatePair(student);

            Assert.IsTrue(pair is CoolParent);
            Assert.AreEqual((student as Botan).MidName,
                Generator.GenerateMidNameFromParentName(student.Sex, pair.Name));
        }

        [TestMethod]
        public void TestCreateParentPair()
        {
            var parent = god.CreateHuman();
            while (!(parent is Parent))
            {
                parent = god.CreateHuman();
            }
            var pair = god.CreatePair(parent);

            Assert.IsTrue(pair is Student);
            Assert.AreEqual((pair as Student).MidName,
                Generator.GenerateMidNameFromParentName(pair.Sex, parent.Name));
        }

        [TestMethod]
        public void TestCreateCoolParentPair()
        {
            var parent = god.CreateHuman();
            while (!(parent is CoolParent))
            {
                parent = god.CreateHuman();
            }
            var pair = god.CreatePair(parent);

            Assert.IsTrue(pair is Botan);
            Assert.AreEqual((pair as Botan).MidName,
                Generator.GenerateMidNameFromParentName(pair.Sex, parent.Name));
        }

    }
}
