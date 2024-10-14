using BodegaVinosAustral.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BodegaVinosAustral.Data
{
    public class WineRepository
    {
        private readonly ApplicationContext _context;

        public WineRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int AddWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges();
            return wine.Id;
        }

        public IEnumerable<Wine> GetAllWines()
        {
            return _context.Wines.ToList();
        }

        public Wine GetWineByName(string name)
        {
            return _context.Wines.FirstOrDefault(w => w.Name.ToLower() == name.ToLower());
        }

    }
}
