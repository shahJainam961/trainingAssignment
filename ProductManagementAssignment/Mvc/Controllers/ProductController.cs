using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;
using System.Net.Http;
using System.IO;
using System.Data.Entity;
using WebApi.Models;

namespace Mvc.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        dataEntities db = new dataEntities();

        // GET: Product
        public ActionResult AddOrEdit(MvcProductModel obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }

        }

        //POST: Product

        [HttpPost]
        public ActionResult Add(MvcProductModel product)
        {
            if (ModelState.IsValid)
            { 
                product_tbl obj = new product_tbl();
                obj.Id = product.Id;
                obj.Name = product.Name;
                obj.Category = product.Category;
                obj.Price = product.Price;

                string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string fileExtension = Path.GetExtension(product.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                product.smallImage = "~/SImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/SImages/"), fileName);
                product.ImageFile.SaveAs(fileName);

                string fileName1 = Path.GetFileNameWithoutExtension(product.ImageFile1.FileName);
                string fileExtension1 = Path.GetExtension(product.ImageFile1.FileName);
                fileName1 = fileName1 + DateTime.Now.ToString("yymmssfff") + fileExtension1;
                product.longImage = "~/LImages/" + fileName1;
                fileName1 = Path.Combine(Server.MapPath("~/LImages/"), fileName1);
                product.ImageFile1.SaveAs(fileName1);

                obj.smallImage = product.smallImage;
                obj.longImage = product.longImage;
                obj.shortDescription = product.shortDescription;
                obj.longDescription = product.longDescription;
                obj.Quantity = product.Quantity;

            if (product.Id == 0)
            {
                HttpResponseMessage responses = MvcGlobalVariables.webapiclient.PostAsJsonAsync("product", obj).Result;
                TempData["success"] = product.Name.ToString()+" Added Successfully.";
            }
            else
            {
                HttpResponseMessage responses = MvcGlobalVariables.webapiclient.PutAsJsonAsync("product/" + product.Id, obj).Result;
                TempData["success"] = product.Name.ToString() +" Updated Successfully";
            }

                return RedirectToAction("ProductList");
        }

                return View();

    }

        //GET: Product List
        public ActionResult ProductList()
        {
            HttpResponseMessage response = MvcGlobalVariables.webapiclient.GetAsync("Product").Result;
            IEnumerable<MvcProductModel> productlist = response.Content.ReadAsAsync<IEnumerable<MvcProductModel>>().Result;
            return View(productlist);
        }
        
        //DELETE: Product
        public ActionResult Delete(int id)
        {
            HttpResponseMessage delresponse = MvcGlobalVariables.webapiclient.DeleteAsync("Product/" + id.ToString()).Result;
            TempData["success"] = " Product Deleted Successfully";
            return RedirectToAction("ProductList");
        }

        

    }
}