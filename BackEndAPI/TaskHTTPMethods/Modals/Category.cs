using System.ComponentModel.DataAnnotations;

namespace TaskHTTPMethods.Modals
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
