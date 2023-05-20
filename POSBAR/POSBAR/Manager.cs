using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBAR
{
    public class Manager:Employee
    {
        public Manager(string name,string ID,string marketID)
        {
            this.name = name;
            this.ID = ID;
            this.marketID = marketID;
        }
        
    }
}
