using System;
using ApiVatEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiVatTests
{
    [TestClass]
    public class ApiVatTests
    {
        [TestMethod]
        public void ApiPositiveTest()
        {
            var response = Vat.GetSubject("5842334017", "2019-11-01");
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void ApiMultiplePositiveTest()
        {
            var response = Vat.GetSubjects("5842334017,9570510820,5842327603", "2019-11-03");
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void ApiWrongNipTest()
        {
            Assert.ThrowsException<AggregateException>((() => Vat.GetSubject("5842343243252334017", "2019-11-01")));
        }

        [TestMethod]
        public void ApiWrongFormatDateTest()
        {
            Assert.ThrowsException<AggregateException>((() => Vat.GetSubject("5842334017", "05052019")));
        }

        [TestMethod]
        public void ApiWrongMultipleNipTest()
        {
            Assert.ThrowsException<AggregateException>((() => Vat.GetSubject("5842334017,9570510820,5842327603,65645453453543543534534", "2019-11-03")));
        }

        [TestMethod]
        public void ApiWrongMultipleFormatDateTest()
        {
            Assert.ThrowsException<AggregateException>((() => Vat.GetSubject("5842334017,9570510820,5842327603", "05052019")));
        }
    }
}
