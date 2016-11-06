using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Customer:IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        /// <summary>
        /// String representation of Customer object.
        /// </summary>
        public override string ToString() => 
            ToString("G", CultureInfo.InvariantCulture);

        /// <summary>
        /// String representation of Customer object using the specified format.
        /// </summary>
        public string ToString(string format) =>
            ToString(format, CultureInfo.InvariantCulture);

        /// <summary>
        /// String representation of Customer object using the specified format and culture-specific format information.
        /// </summary>
        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.InvariantCulture;

            switch (format.ToUpperInvariant())
            {
                case "G": return $"Customer record: {Name}, {Revenue.ToString("0,0.00", provider)}, {ContactPhone}";
                case "A": return $"Customer record: {ContactPhone}";
                case "B": return $"Customer record: {Name}, {Revenue.ToString("0,0.00", provider)}";
                case "C": return $"Customer record: {Name}";
                case "D": return $"Customer record: {Revenue}";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));

            }
        }
    }
}
