using Microsoft.EntityFrameworkCore;
using SalesWebMVCNew.Data;
using SalesWebMVCNew.Models;

namespace SalesWebMVCNew.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCNewContext _context;

        public DepartmentService(SalesWebMVCNewContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
