using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class CustumerProvider:IFormatProvider,ICustomFormatter
    {
        private IFormatProvider parentFormatProvider;

        public CustumerProvider(IFormatProvider parentFormatProvider)
        {
            this.parentFormatProvider=parentFormatProvider?? CultureInfo.CurrentCulture; 
        }

        public object GetFormat(Type formatType)=>
             formatType == typeof(ICustomFormatter) ? this : parentFormatProvider.GetFormat(formatType);

        /// <summary>
        /// String representation of the arg.
        /// </summary>
        ///<exception cref="ArgumentNullException">
        /// Throw ArgumentNullException if arg is null.
        ///</exception>
        /// <param name="format">String format. Provided "E" and "F"</param>
        /// <param name="arg">Customer instance. If is not customer returns object's to string</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>String representation of Customer</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null))
                throw new ArgumentNullException(nameof(arg));

            Customer customer = arg as Customer;
            if (ReferenceEquals(customer, null))
                return arg.ToString();

            if (string.IsNullOrEmpty(format))
                format = "E";

            switch (format.ToUpperInvariant())
            {
                case "E": return $"Customer record: {customer.Name}, {customer.Revenue.ToString("F2", formatProvider)}, {customer.ContactPhone}";
                case "F": return $"Customer record: Name {customer.Name}, Telehpone {customer.ContactPhone}";
                default:
                    throw new FormatException($"The {format} format specifier is not supported.");

            }
        }
    }
}
