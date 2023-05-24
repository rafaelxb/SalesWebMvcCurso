using Microsoft.EntityFrameworkCore;
using SalesWebMVCNew.Data;
using SalesWebMVCNew.Models;
using SalesWebMVCNew.Services.Exceptions;

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
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var seller = FindById(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if(!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }

        }
    }
}
