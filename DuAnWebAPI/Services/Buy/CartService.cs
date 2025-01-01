using DuAnWebBlazor;
using DuAnWebData.Data;
using DuAnWebData.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DuAnWebAPI.Services.Buy
{
    public class CartService : ICartcs
    {
        private readonly DataContext _dataContext;
        public CartService(DataContext data)
        {
            _dataContext = data;
        }
        public async Task BuyProduc(CartDetail cardetail)
        {
            _dataContext.CartDetails.Add(cardetail);
              await _dataContext.SaveChangesAsync();
        }

        public async Task<List<CartDetail>> GetAllProduct(Guid Idcart)
        {
             var Cartforme = await  (from a in _dataContext.CartDetails where(a.IdCart==Idcart) select a).ToListAsync();
            return Cartforme;
        }

        public async Task RemoveProductByCart(Guid Idcartdetail)
        {
            var cartdatailremove = _dataContext.CartDetails.Find(Idcartdetail);
            _dataContext.Remove(cartdatailremove);
            await _dataContext.SaveChangesAsync();
        }

        public Task UpdateProducByCart(Guid Idcartdetail)
        {
            throw new NotImplementedException();
        }
    }
}
