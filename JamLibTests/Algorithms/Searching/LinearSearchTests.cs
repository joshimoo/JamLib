using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JamLib.Algorithms.Searching.Tests
{
    [TestClass()]
    public class LinearSearchTests
    {
        [TestMethod()]
        public void SearchTest()
        {
            var data = new int[] { -1, 0, 1, 4, 5, 7, 88, 90, 111, 160, 250 };
            int actualIndex = LinearSearch.Search(data, 90);
            int expectedIndex = 7;

            Assert.AreEqual(expectedIndex, actualIndex, "Linear search did not provide the correct index");
        }

        [TestMethod()]
        public void ReverseSearchTest()
        {
            var data = new int[] { -1, 0, 1, 4, 5, 7, 88, 90, 111, 160, 250 };
            int actualIndex = LinearSearch.ReverseSearch(data, 90);
            int expectedIndex = 7;

            Assert.AreEqual(expectedIndex, actualIndex, "Reverse Linear search did not provide the correct index");
        }

        [TestMethod()]
        public void Search_CustomComparer_Test()
        {
            // This is a rather stupid example for a custom comparer
            var data = new Person[] { new Person() { Age = 2, Name = "firstname" }, new Person() { Age = 66, Name = "middlename" }, new Person() { Age = 33, Name = "lastname" } };

            Comparison<Person> stupidExample = ((x, y) => x.Age > y.Age ? 1 : x.Age < y.Age ? -1 : 0);
            int actualIndex = LinearSearch.Search<Person>(data, new Person() { Age = 66, Name = "stupidExample" }, Comparer<Person>.Create(stupidExample));
            int expectedIndex = 1;

            Assert.AreEqual(expectedIndex, actualIndex, "Binary search did not provide the correct index with a custom comparer");
        }

        private class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
    }
}
