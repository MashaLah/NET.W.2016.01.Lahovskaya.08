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
        [TestCase("G",ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("A",ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("B",ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("C",ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("D",ExpectedResult = "Customer record: 1000000")]
        public string ToString_ValidData_ValidResult(string format) => customer.ToString(format);

        /// <summary>
        /// A test for ToString without parameter.
        /// </summary>
        [TestCase(ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        public string ToString_NoParameter_ValidData() => customer.ToString();

        /// <summary>
        /// A test for ToString with invalid format.
        /// </summary>
        [Test]
        public void ToString_InvalidFormat_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => customer.ToString("Q"));
        }

        /// <summary>
        /// A test for Format with valid data.
        /// </summary>
        [TestCase("{0:E}",ExpectedResult = "Customer record: Jeffrey Richter, 1000000,00, +1 (425) 555-0100")]
        [TestCase("{0:F}", ExpectedResult = "Customer record: Name Jeffrey Richter, Telehpone +1 (425) 555-0100")]
        [TestCase("{0}", ExpectedResult = "Customer record: Jeffrey Richter, 1000000,00, +1 (425) 555-0100")]
        public string Format_ValidData_ValidResult(string format)=>
            string.Format(new CustumerFormatter(), format, customer);

        /// <summary>
        /// A test for Format with invalid format.
        /// </summary>
        [Test]
        public void Format_InvalidFormat_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => string.Format(new CustumerFormatter(),"{0:Q}", customer));
        }

        /// <summary>
        /// A test for Format with arg is not Customer.
        /// </summary>
        [TestCase(ExpectedResult ="System.Object")]
        public string Format_InvalidArg_ThrowsArgumentNullException()
        {
            object obj = new object();
            return string.Format(new CustumerFormatter(), "{0}", obj);
        }
            

        /// <summary>
        /// A test for Format with arg is null.
        /// </summary>
        [Test]
        public void Format_ArgIsNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => string.Format(new CustumerFormatter(), "{0}", null));
        }
    }
}
