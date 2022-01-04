using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthelasAPI.Entites
{
    public class Employee
    {
        public int      Id          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }

        public virtual List<Appointment> Appointments { get; set; }
    }
}
