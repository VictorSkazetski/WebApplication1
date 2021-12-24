using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int shopId)
        {
            var products = await _unitOfWork.Products.GetProducts(shopId);

            return View(products);

        }

        [HttpPost]
        public IActionResult Drop([FromBody] ReqDataDto body)
        {
            _unitOfWork.Products.DropProduct(body.Id);
            _unitOfWork.Complete();
            var redirectUrl = $"https://localhost:44387/product/index/{body.Page}";
            
            return Json(redirectUrl);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ReqDataDto body)
        {
            _unitOfWork.Products.AddProduct(body);
            _unitOfWork.Complete();

            var redirectUrl = $"https://localhost:44387/product/index/{body.Page}";

            return Json(redirectUrl);
        }

        [HttpPost]
        public IActionResult GetEditProduct([FromBody] ReqDataDto body)
        {
            var product = _unitOfWork.Products.GetProductById(body.Id);

            return Json(product);
        }

        [HttpPost]
        public IActionResult Update([FromBody] ReqDataDto body)
        {
            _unitOfWork.Products.Update(body);
            _unitOfWork.Complete();

            var redirectUrl = $"https://localhost:44387/product/index/{body.Page}";

            return Json(redirectUrl);
        }

    }

}
