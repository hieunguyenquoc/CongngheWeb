using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }
        public ActionResult Detail(int id)
        {
            var product = new ProductDao().Viewdetail(id);
            ViewBag.Category = new CategoryDao().ViewdetailCat(product.catId.Value);
            return View(product);
        }
        public ActionResult category(int id, int page = 1, int pageSize = 1)
        {   
            var category = new CategoryDao().ViewdetailCat(id);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryID(id,ref totalRecord, page, pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage; 
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);

            
        }



    }
}