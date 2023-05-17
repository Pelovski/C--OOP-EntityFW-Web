using System;
using System.Collections.Generic;

namespace P01._Import_the_SoftUni_Database.Data.Models
{
    public partial class EmployeesProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
