using AspNetCoreCars.Data;
using AspNetCoreCars.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCars.Services
{
    public class CarItemService : ICarItemService
    {
        private readonly ApplicationDbContext _context;
        public CarItemService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CarItem[]> GetCarItemsAsync()
        {
            return await _context.Items.ToArrayAsync();
        }

        public async Task<bool> AddCarItemAsync(CarItem newCarItem)
        {
            newCarItem.Id = Guid.NewGuid();
            _context.Items.Add(newCarItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
