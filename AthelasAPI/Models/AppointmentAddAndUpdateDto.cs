using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthelasAPI.Models
{
    public class AppointmentAddAndUpdateDto
    {
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
