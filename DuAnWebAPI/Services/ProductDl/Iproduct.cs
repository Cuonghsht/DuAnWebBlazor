using DuAnWebData.Model;

namespace DuAnWebAPI.Services.ProductDL
{
    public interface Iproduct
    {
        Task<object> GetAllProduct(DuAnWebData.Model.Product pr, int page, int pageSize);
        Task AddProduct(DuAnWebData.Model.Product pro, Guid idUser);
        Task DeleteProduct(Guid idProduct);
        Task UpadteProduct(DuAnWebData.Model.Product pro, Guid idProduct);
        Task<DuAnWebData.Model.Product> DetailProduct(Guid idProduct);
    }
}
