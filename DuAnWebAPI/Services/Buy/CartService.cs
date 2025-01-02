using DuAnWebBlazor;
using DuAnWebData.Data;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var Sum = _dataContext.CartDetails.Count();
            var data = await _dataContext.CartDetails.Skip((Page - 1) * PageSize).Take(PageSize).ToListAsync();
            return new
            {
                TotalRecords = Sum,
                Page = Page,
                PageSize = PageSize,
                TotalPages = (int)Math.Ceiling((double)Sum / PageSize),
                Product = data
            }; ;
        }

        public async Task RemoveProductByCart(Guid Idcartdetail)
        {
            try
            {

                var cartdatailremove = _dataContext.CartDetails.FindAsync(Idcartdetail);
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

        public Task UpdateProducByCart(Guid Idcartdetail)
        {
            throw new NotImplementedException();
        }
    }
}
