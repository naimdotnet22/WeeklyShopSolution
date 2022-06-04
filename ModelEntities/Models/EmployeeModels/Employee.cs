using System;

namespace zModelEntities.Models.EmployeeModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public int EmployeeAge { get; set; } = 0;
        public DateTime JoiningDate { get; set; } = DateTime.Now;

    }
}
