using EmployeeApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using zModelEntities.Models.EmployeeModels;

namespace EmployeeApp.Repositories.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        #region dependency injection _db
        private readonly EmployeeDbContext _db;
        public EmployeeRepo(EmployeeDbContext db)
        {
            _db = db;
        }
        #endregion

        public async Task<Employee> AddOrEdit(Employee employee)
        {
            if (employee.EmployeeId > 0)
            {
                _db.Entry(employee).State = EntityState.Modified;
                await SaveChangesAsync();
                return employee;
            }
            else
            {
                await _db.Employees.AddAsync(employee);
                await SaveChangesAsync();
                return employee;
            }
        }

        public async Task<string> DeleteEmployee(Employee emp)
        {
            _db.Employees.Remove(emp);
            await SaveChangesAsync();
            return emp.EmployeeName + " Deleted Successfully";
        }

        public async Task<Employee> FindEmployee(int id)
        {
            var emp = await _db.Employees.FindAsync(id);
            return emp;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _db.Employees.ToListAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
