using DuAnWebBlazor;
using DuAnWebData.Data;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Drawing.Printing;

namespace DuAnWebAPI.Services.Buy
{
    public class CartService : ICartcs
    {
        private readonly DataContext _dataContext;
        public CartService(DataContext data)
        {
            _dataContext = data;
        }
        public async Task BuyProduc(CartDetail cardetail )
        {
            
            _dataContext.CartDetails.Add(cardetail);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<object> GetAllProduct(Guid Idcart, int Page = 1, int PageSize = 5)
        {
            var totalRecords = await _dataContext.CartDetails.CountAsync(x => x.IdCart == Idcart);
            var data = await _dataContext.CartDetails
                                         .Where(x => x.IdCart == Idcart)
                                         .Skip((Page - 1) * PageSize)
                                         .Take(PageSize)
                                         .ToListAsync();

            return new
            {
                TotalRecords = totalRecords,
                Page = Page,
                PageSize = PageSize,
                TotalPages = (int)Math.Ceiling((double)totalRecords / PageSize),
                Items = data
            };
        }

        public async Task RemoveProductByCart(Guid Idcartdetail)
        {
            try
            {
                var cartdatailremove = await _dataContext.CartDetails.FindAsync(Idcartdetail);
                if (cartdatailremove != null) 
                {
                    _dataContext.Remove(cartdatailremove);
                    await _dataContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("Khong tim thay doi tuong can xoa");
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
                throw new InvalidCastException("Phuong thuc khong hoat dong");
            }

        }

        public async Task UpdateProducByCart(int  Idcartdetail, CartDetail car)
        {
            
            
            
                var data = _dataContext.CartDetails.FindAsync(Idcartdetail);
                if(data == null)
                {
                    throw new ArgumentNullException("Du lieu khoong duoc tim thay");
                }
                else
                {
                    data.Result.Quantity = car.Quantity;
                    data.Result.NgayThemVao = car.NgayThemVao;
                    data.Result.Total = car.Total;
                    await _dataContext.SaveChangesAsync();
                }
                
        }
    }
}
