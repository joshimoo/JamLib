using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Crypto.Tests
{
    [TestClass()]
    public class GronsfeldCipherTests
    {
        [TestMethod()]
        public void UserSuppliedAlphabet()
        {
            string alphabet = "ABCD0123.!, ";
            byte[] key = new byte[] { 1, 2 };
            string msg = "AAAA01"; // You can only use elements from the alphabet

            var c = new GronsfeldCipher(alphabet);
            Assert.AreEqual(msg, new String(c.Decode(new String(c.Encode(msg, key)), key)));
            CollectionAssert.AreEqual(msg.ToCharArray(), c.Decode(new String(c.Encode(msg, key)), key));
        }


        [TestMethod()]
        public void SymetryTest()
        {
            byte[] key = new byte[] { 3, 2, 5, 7, 1, 4, 0 };
            string msg = "Hello World!";
            var c = new GronsfeldCipher();

            Assert.AreEqual(msg, new String(c.Decode(new String(c.Encode(msg, key)), key)));
            CollectionAssert.AreEqual(msg.ToCharArray(), c.Decode(new String(c.Encode(msg, key)), key));
        }

        [TestMethod()]
        public void EncodeTest()
        {
            var c = new GronsfeldCipher();
            Assert.AreEqual("HYEMYDUMPS", new String(c.Encode("EXALTATION", new byte[] { 3, 1, 4, 1, 5 })));
            Assert.AreEqual("M%muxi%dncpqftiix\"", new String(c.Encode("I love challenges!", new byte[] { 4, 5, 1, 6, 2 })));
            Assert.AreEqual("Uix!&kotvx3", new String(c.Encode("Test input.", new byte[] { 1, 4, 5, 8, 6, 2, 1, 4 })));
        }

        [TestMethod()]
        public void DecodeTest()
        {
            var c = new GronsfeldCipher();
            Assert.AreEqual("EXALTATION", new String(c.Decode("HYEMYDUMPS", new byte[] { 3, 1, 4, 1, 5 })));
            Assert.AreEqual("I love challenges!", new String(c.Decode("M%muxi%dncpqftiix\"", new byte[] { 4, 5, 1, 6, 2 })));
            Assert.AreEqual("Test input.", new String(c.Decode("Uix!&kotvx3", new byte[] { 1, 4, 5, 8, 6, 2, 1, 4 })));
        }
    }
}
