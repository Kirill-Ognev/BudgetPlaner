using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlaner
{
    public class Type
    {
        public int Id { get; set; }
        public string Name{ get; set; }


        public string GetName()
        {
            return Name;
        }
    }
}
