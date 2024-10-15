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
        public IEnumerable<Wine> GetWinesbyVariety (string variety)
        {
            return _context.Wines.Where(w => w.Variety.ToLower() == variety).ToList();
        }
        public bool UpdateStock(int wineId, int newStock)
        {
            var wine = _context.Wines.FirstOrDefault(w => w.Id == wineId);
            if (wine != null)
            {
                wine.Stock = newStock;
                _context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
