using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlaner
{
    public class Operation
    {
        public int Id { get; set; }
        public int Typeid { get; set; }
        public Type Type { get; set; }
        public int Summa { get; set; }
        public int Caregoryid { get; set; }
        public Category Category { get; set; }
        public string Coment { get; set; }


    }
}
