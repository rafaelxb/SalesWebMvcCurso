﻿using SalesWebMVCNew.Data;
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
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var seller = FindById(id);
            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }
    }
}
