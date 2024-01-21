using Employee.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Employee.API.Entities
{
    public class Employee : BaseEntity<int>
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public Position Position { get; set; }
        public long Salary { get; set; }
        [Required]
        [Range(18, 125)]
        public int Age { get; set; }

    }

}
