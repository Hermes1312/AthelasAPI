﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthelasAPI.Models
{
    public class ClientUpdateDto
    {
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        //[Required]
        public string PhoneNumber { get; set; }
    }
}
