using DuAnWebAPI.Services.ProductDL;
using DuAnWebData.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace DuAnWebAPI.Services.Product
{
    public class ProductService : Iproduct
    {
        private readonly DataContext dataContext;
        public ProductService(DataContext _data)
        {
            dataContext = _data;
        }
        public async Task AddProduct(DuAnWebData.Model.Product pro, Guid idUser)
        {
            if (pro == null || idUser == Guid.Empty)
            {
                throw new ArgumentNullException("Dữ liệu không hợp lí ");
            }
            else
            {
                dataContext.Products.Add(pro);
                await dataContext.SaveChangesAsync();
            }

        }

        public async Task DeleteProduct(Guid idProduct)
        {
            var productRemove = await dataContext.Products.FindAsync(idProduct);
            if (productRemove == null)
            {
                throw new KeyNotFoundException("Sản phẩm không tồn tại");
            }
            else
            {
                dataContext.Remove(productRemove);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task<DuAnWebData.Model.Product> DetailProduct(Guid idProduct)
        {
            var productRemove = await dataContext.Products.FindAsync(idProduct);
            if (productRemove == null)
            {
                throw new KeyNotFoundException("Sản phẩm không tồn tại");
            }
            else
            {
                return productRemove;
            }
        }

        public async Task<object> GetAllProduct(DuAnWebData.Model.Product pr, int page, int pageSize)
        {
            var data = await dataContext.Products
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize)
                       .ToListAsync();
            return data;
        }

        public async Task UpadteProduct(DuAnWebData.Model.Product pro, Guid idProduct)
        {
            try
            {
                if(idProduct==null|| pro == null)
                {
                    throw new InvalidCastException("Du lieu chua hop le");
                }
                else
                {
                    var data = dataContext.Products .FindAsync(idProduct);
                    if (data == null)
                    {
                        throw new ArgumentNullException("Khong tim thay san pham");
                    }
                    else
                    {
                        data.Result.NameProduct = pro.NameProduct;
                        data.Result.PriceProduct = pro.PriceProduct;
                        data.Result.Quantity = pro.Quantity;
                        data.Result.Image = pro.Image;
                        await dataContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
