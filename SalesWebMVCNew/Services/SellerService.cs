using SalesWebMVCNew.Data;
using SalesWebMVCNew.Models;

namespace SalesWebMVCNew.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCNewContext _context;

        public SellerService(SalesWebMVCNewContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller seller)
        {
            seller.Department = _context.Department.First();
            _context.Add(seller);
            _context.SaveChanges();
        }
    }
}
