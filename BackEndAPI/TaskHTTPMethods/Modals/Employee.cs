using System.ComponentModel.DataAnnotations;

namespace TaskHTTPMethods.Modals
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpSal { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
