using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthelasAPI.Models
{
    public class AppointmentDto
    {
        public int      Id                  { get; set; }
        public string   ClientFullName      { get; set; }
        public string   EmployeeFullName    { get; set; }
        public string   ServiceName         { get; set; }
        public DateTime Start               { get; set; }
        public DateTime End                 { get; set; }
    }
}
