using Microsoft.EntityFrameworkCore;
using Rel1.Models;

namespace Rel1.Repository.EmpServices
{
    public class EmpServices : IEmpServices
    {
        public CompanyContext _context;
        public EmpServices(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<Emp>?> GetEmps()
        {
            var emps= await _context.Emps.ToListAsync();
            return emps;
        }

        public async Task<Emp?> GetEmp(int id)
        {
            var emp = await _context.Emps.FindAsync();
            if (emp is null)
            {
                return null;
            }
            return emp;
        }

        public async Task<List<Emp>?> PutEmp(int id, Emp emp)
        {
            var employee = await _context.Emps.FindAsync(id);
            if (employee is null)
            {
                return null;
            }
            employee.Empno = emp.Empno;
            employee.Ename = emp.Ename;
            await _context.SaveChangesAsync();
            return await _context.Emps.ToListAsync();
        }

        public async Task<List<Emp>> PostEmp(Emp emp)
        {
            _context.Emps.Add(emp);
            await _context.SaveChangesAsync();
            return await _context.Emps.ToListAsync();
        }

        public async Task<List<Emp>?> DeleteEmp(int id)
        {
            var employee = await _context.Emps.FindAsync(id);
            if (employee is null)
            {
                return null;
            }
            _context.Emps.Remove(employee);
            await _context.SaveChangesAsync();
            return await _context.Emps.ToListAsync();
        }
        /*
        public Task<List<Emp>?> GetEmps()
        {
            throw new NotImplementedException();
        }

        public Task<List<Emp>?> PutEmp(int id, Dept dept)
        {
            throw new NotImplementedException();
        }

        public Task<List<Emp>> PostEmp(Dept dept)
        {
            throw new NotImplementedException();
        }
        */
    }
}
