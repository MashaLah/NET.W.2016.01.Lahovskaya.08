using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using NUnit.Framework;

namespace Task1Tests
{
    [TestFixture]
    public class CustomerTests
    {
        Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        /// <summary>
        /// A test for ToString with valid data.
        /// </summary>
        [TestCase("G", "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("A", "Customer record: +1 (425) 555-0100")]
        [TestCase("B", "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("C", "Customer record: Jeffrey Richter")]
        [TestCase("D", "Customer record: 1000000")]
        public void ToString_ValidData_ValidResult(string format, string expected)
        {
            string actual = customer.ToString(format);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for ToString without parameter.
        /// </summary>
        [TestCase("Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        public void ToString_NoParameter_ValidData(string expected)
        {
            string actual = customer.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for ToString with invalid format.
        /// </summary>
        [Test]
        public void ToString_InvalidFormat_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => customer.ToString("Q"));
        }
    }
}
