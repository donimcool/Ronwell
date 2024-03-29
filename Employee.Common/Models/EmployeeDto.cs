﻿namespace Employee.Common.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long? Salary { get; set; }
        public int Age { get; set; }
        public string Position { get; set; } = string.Empty;
    }
}
