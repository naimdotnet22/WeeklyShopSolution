using System.Collections.Generic;
using System.Threading.Tasks;
using zModelEntities.Models.EmployeeModels;

namespace EmployeeApp.Repositories.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> FindEmployee(int id);
        Task<Employee> AddOrEdit(Employee employee);
        Task<string> DeleteEmployee(Employee emp);
    }
}
