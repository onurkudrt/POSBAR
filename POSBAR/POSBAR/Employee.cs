using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public abstract class Employee
    {
        public string ID { get; protected set; }
        public string name { get; protected set; }
        public string marketID { get; protected set; }
        
    }
}
