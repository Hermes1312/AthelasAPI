using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthelasAPI.Entites
{
    public class Appointment
    {
        public int      Id              { get; set; }
        public int      ClientId        { get; set; }
        public int      EmployeeId      { get; set; }
        public int      ServiceId       { get; set; }
        public DateTime Start           { get; set; }
        public DateTime End             { get; set; }

        public virtual Client   Client      { get; set; }
        public virtual Employee Employee    { get; set; }
        public virtual Service  Service     { get; set; }
    }
}
