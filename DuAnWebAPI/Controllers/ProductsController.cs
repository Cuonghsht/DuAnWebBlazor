using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DuAnWebData.Data;
using DuAnWebData.Model;
using Newtonsoft.Json;
using DuAnWebData.Migrations;
using System.Drawing.Printing;

namespace DuAnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int page = 1, int pagesize = 5)
        {
            var Sumdata = _context.Products.Where(a => a.Quantity > 0).Count();
            var data = _context.Products.Skip((page - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return Ok
                (new
                    {
                        TotalRecords = Sumdata,
                        Page = page,
                        PageSize = pagesize,
                        TotalPages = (int)Math.Ceiling((double)Sumdata / pagesize),
                        Product = data
                    }
                );

        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //Code test
        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> themtest(string ten, decimal gia, int sl, string mota, bool trangthai, string anh)
        {
            Product spmoi = new Product()
            {
                ProductId = Guid.NewGuid(),
                NameProduct = ten,
                PriceProduct = gia,
                Quantity = sl,
                DescriptionProduct = mota,
                Status = trangthai,
                Image = anh
            };
            _context.Products.Add(spmoi);
            await _context.SaveChangesAsync();
            return Ok("thêm thành công");
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(Guid id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
