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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
