using System;
using Epam_Lab3_Unit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Triangle_Tests
{
    [TestClass]
    public class Triangle_Tests
    {
        [TestMethod]
        public void A_Sidi_Is_Negative()
        {
            float a = -4.5f;
            float b = 10;
            float c = 3;
            bool expected = false;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void B_Sidi_Is_Negative()
        {
            float a = 4;
            float b = -10;
            float c = 3;
            bool expected = false;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void C_Sidi_Is_Negative()
        {
            float a = 4;
            float b = 10;
            float c = -3;
            bool expected = false;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void A_Plus_B_More_C()
        {
            float a = 4;
            float b = 10;
            float c = 13;
            bool expected = true;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void A_Plus_C_More_B()
        {
            float a = 8;
            float b = 15;
            float c = 13;
            bool expected = true;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void C_Plus_B_More_A()
        {
            float a = 8;
            float b = 15;
            float c = 13;
            bool expected = true;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void A_Plus_B_Less_C()
        {
            float a = 8;
            float b = 15;
            float c = 33;
            bool expected = false;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void A_Plus_С_Less_B()
        {
            float a = 8;
            float b = 15;
            float c = 4;
            bool expected = false;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void C_Plus_B_Less_A()
        {
            float a = 8;
            float b = 1;
            float c = 4;
            bool expected = false;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void A_Equal_B_Equal_C()
        {
            float a = 5;
            float b = 5;
            float c = 5;
            bool expected = true;

            Triangle ABC = new Triangle();
            bool actual = ABC.Triangle_Check(a, b, c);

            Assert.AreEqual(expected, actual);
        }

    }

}
