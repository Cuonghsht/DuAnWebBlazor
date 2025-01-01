using DuAnWebData.Model;

namespace DuAnWebAPI.Services.Buy
{
    public interface ICartcs
    {
        Task BuyProduc( CartDetail cardetail);
        Task<List<CartDetail>> GetAllProduct(Guid Idcart);
        Task RemoveProductByCart(Guid Idcartdetail);
        Task UpdateProducByCart(Guid Idcardetail);
    }
}
