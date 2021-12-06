using Microsoft.EntityFrameworkCore;
using OilShop.Entities;
using OilShop.Models;
using OilShop.Repo.Implement;
using System.Collections.Generic;
using System.Linq;

namespace OilShop.Repo.Interfaces
{
    public class OilRepo : GenericRepository<Oil>, IOilRepo
    {
        private ApplicationDbContext _context;

        public OilRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

