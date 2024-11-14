using System.Collections.ObjectModel;

namespace secondProject.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Collection<Employee> Employees { get; set; }
    }
}
