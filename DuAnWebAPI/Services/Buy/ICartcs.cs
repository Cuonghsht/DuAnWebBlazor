using DuAnWebData.Model;

namespace DuAnWebAPI.Services.Buy
{
    public interface ICartcs
    {
        Task BuyProduc(CartDetail cardetail);
        Task<object> GetAllProduct(Guid Idcart, int Page = 1, int PageSize = 5);
        Task RemoveProductByCart(Guid Idcartdetail);
        Task UpdateProducByCart(int  Idcardetail,CartDetail car);
    }
}
