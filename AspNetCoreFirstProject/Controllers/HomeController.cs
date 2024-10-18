using AspNetCoreFirstProject.Models;
using AspNetCoreFirstProject.RequestTools;
using AspNetCoreFirstProject.RequestTools.ProductQueryParameters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreFirstProject.Controllers
{
    public class HomeController : Controller
    {
        List<UserViewModel> resultList;
        List<Product> productList;

        public HomeController()
        {
            resultList = new();
            resultList.Add(new UserViewModel() { Id = 1, UserName = "melihok", NameSurname = "Melih Ömer KAMAR" });
            resultList.Add(new UserViewModel() { Id = 2, UserName = "mustafa", NameSurname = "MUSTAFA" });
            resultList.Add(new UserViewModel() { Id = 3, UserName = "berkant", NameSurname = "BERKANT" });
            resultList.Add(new UserViewModel() { Id = 4, UserName = "selim", NameSurname = "SELİM" });
            productList = new List<Product>()
            {
                new Product{Id =1,ProductName="Monitör",Price=500,IsActive=true},
                new Product{Id =2,ProductName="Klavye",Price=999,IsActive = true},
                new Product{Id =3,ProductName="Kasa",Price=100, IsActive = true},
                new Product{Id =4,ProductName="Mouse",Price=2600, IsActive = false},
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return RedirectToAction("Index", "Product");
        }
        public IActionResult Test()
        {
            var req = Request;
            //Daha çok ufak stringler taşımak için kullandığımız veri dönme yöntemleri
            ViewData["username"] = "melihok";
            ViewBag.NameSurname = "Melih Ömer KAMAR";
            //List olarak bir classı model olarak dönmek istersek.
            


            //Tekil olarak bir classı model dönme yöntemi.
            //UserViewModel model = new()
            //{
            //    Id = 1,
            //    NameSurname = "Melih Ömer KAMAR",
            //    UserName = "melihok"
            //};
            return View(resultList);
        }
        public IActionResult Parameters(int id)
        {
            if (id == 0)
            {
                UserViewModel result2 = resultList.FirstOrDefault(x => x.Id == 3);

                return View(result2);
            }
            UserViewModel result = resultList.FirstOrDefault(x => x.Id == id);
            
            return View(result);
        }
        public IActionResult QueryParameters([FromQuery]UserQueryParameters parameters)
        {
            var req = Request;
            UserViewModel result = resultList.FirstOrDefault(x=> x.UserName.StartsWith(parameters.UserName));

            return View(result);
        }
        public IActionResult FilteredProducts([FromQuery]RequestParameters queryParams)
        {
            bool isActive = false;
            if (queryParams.IsActive == "on")
            {
                isActive = true;
            }


            var resultList = productList.Where(x => x.Price >= queryParams.MinPrice & x.Price <= queryParams.MaxPrice&x.IsActive== isActive).ToList();
            return View(resultList);
        }


    }
}
