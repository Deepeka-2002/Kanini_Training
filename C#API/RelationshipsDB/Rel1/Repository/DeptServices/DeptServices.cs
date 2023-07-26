using Microsoft.EntityFrameworkCore;
using Rel1.Models;

namespace Rel1.Repository.DeptServices
{
    public class DeptServices:IDeptServices
    {
        public CompanyContext _context;
        public DeptServices(CompanyContext context) 
        {
            _context = context;
        }

        public async Task<List<Dept>?> GetDepts()
        {
            var depts = await _context.Depts.ToListAsync();
            return depts;
        }

        public async Task<Dept?> GetDept(int id)
        {
            var dept = await _context.Depts.FindAsync();
            if(dept is null)
            {
                return null;
            }
            return dept;
        }

        public async Task<List<Dept>?> PutDept(int id, Dept dept)
        {
            var department = await _context.Depts.FindAsync(id);
            if(department is null)
            {
                return null;
            }
            department.Deptno = dept.Deptno;
            department.Dname = dept.Dname;
            await _context.SaveChangesAsync();
            return await _context.Depts.ToListAsync();
        }

        public async Task<List<Dept>> PostDept(Dept dept)
        {
            _context.Depts.Add(dept);
            await _context.SaveChangesAsync();
            return await _context.Depts.ToListAsync();
        }

        public async Task<List<Dept>?> DeleteDept(int id)
        {
            var department = await _context.Depts.FindAsync(id);
            if( department is null)
            {
                return null;
            }
            _context.Depts.Remove(department);
            await _context.SaveChangesAsync();
            return await _context.Depts.ToListAsync();
        }
    }
}
