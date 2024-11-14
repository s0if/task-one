using System.ComponentModel.DataAnnotations.Schema;

namespace secondProject.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
    }
}
