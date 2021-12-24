using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var shopProducts = await _unitOfWork.Shops.AllItem(
                includes: source => source.Include(x => x.ShopProducts)
                                         .ThenInclude(x => x.Product));

          //  ViewBag.shopProducts = shopProducts;
           // shopProducts.Co

            return View(shopProducts);

        }

        
    }
}
