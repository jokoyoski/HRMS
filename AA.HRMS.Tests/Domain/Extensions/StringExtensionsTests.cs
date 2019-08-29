/*
using AA.HRMS.Domain.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA.HRMS.Tests.Domain.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        [TestCase("a@@vv")]
        [TestCase("cnnistheplacetobe")]
        public void IsValidEmailValue_Returns_False_When_String_Is_Not_Valid_Email(string emailAddress)
        {
            Assert.IsFalse(emailAddress.IsValidEmailValue());
        }

        [Test]
        [TestCase("aa@bcd.com")]
        [TestCase("c@bcd.com")]
        public void IsValidEmailValue_Returns_True_When_String_Is_Valid_Email(string emailAddress)
        {
            Assert.IsTrue(emailAddress.IsValidEmailValue());
        }

        [Test]
        [TestCase("200 S Sixth street, minneapolis, mn")]
        [TestCase("200 P O Davis Drive, PO, mn")]
        [TestCase("123 Box circle, ijebu, mn")]
        public void IsPOBoxInAddress_Returns_False_If_Address_Does_Not_Contain_POBox(string address)
        {
            Assert.IsFalse(address.IsPOBoxInAddress());
        }


        [Test]
        [TestCase("PO Box 123")]
        [TestCase("P O Box 123")]
        [TestCase("P.O. Box 123 ijebu, mn")]
        [TestCase("POBox 123 ijebu, mn")]
        public void IsPOBoxInAddress_Returns_True_If_Address_Contains_POBox(string address)
        {
            Assert.IsTrue(address.IsPOBoxInAddress());
        }

    }
}
*/
