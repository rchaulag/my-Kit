using JobBoard.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoard.Models
{
    public class JobBoardVM
    {
        public Job Job { get; set; }
        public Company Company { get; set; }

        public List<Job> Jobs { get; set; }
        public List<Company> Companies { get; set; }




    }
}