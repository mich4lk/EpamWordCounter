using System;

namespace EpamWordCounter.Exceptions
{
    public class InvalidSortFormatException : Exception
    {
        public InvalidSortFormatException() : base("SortFormat has to contain exactly 2 string.Format arguments")
        { }
    }
}
