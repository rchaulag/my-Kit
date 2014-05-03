﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.DataModels
{
     public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Location { get; set; }
        public virtual List<Job> Jobs { get; set; }
    
     }
}
