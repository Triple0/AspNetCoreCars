using AspNetCoreCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCars.Services
{
    public interface ICarItemService
    {
        Task<CarItem[]> GetCarItemsAsync();

        Task<bool> AddCarItemAsync(CarItem newCarItem);
    }
}
