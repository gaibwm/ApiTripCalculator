using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripCalculator
{

    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double TTpay { get; set; }
        public double Balance { get; set; }

    }

    public class Expense
    {
        public string ID { get; set; }
        public string StudentID { get; set; }
        public double Amount { get; set; }
    }
}
