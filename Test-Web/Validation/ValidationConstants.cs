using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Test_Web.Validation
{
    public class ValidationConstants
    {
        public const int MaxNameLength = 100;

        public const int MinNameLength = 3;

        public const int MaxAmount = 1000;

        public const int MinAmount = 1;

        public const int MaxTypeLength = 100;

        public const int MaxDescriptionLength = 1500;

        public const double MaxPrice = 999999.99;

        public const double MinPrice = 0.01;

        public const int MinTypeLength = 3;

        public const int MinDescriptionLength = 30;
    }
}
