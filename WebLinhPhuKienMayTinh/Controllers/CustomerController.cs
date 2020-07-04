using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLinhPhuKienMayTinh.Common;
using WebLinhPhuKienMayTinh.Models;
using WebLinhPhuKienMayTinh.Models.Dao;
using WebLinhPhuKienMayTinh.Models.EF;

namespace WebLinhPhuKienMayTinh.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.Login(model.name, (model.password0));
                if (result == 1)
                {
                    var user = dao.GetById(model.name);
                    var userSession = new UserLogin();
                    userSession.UserName = user.name;
                    userSession.UserID = user.customer_id;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View(model);

        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Register(RegiterModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new CustomerDao();
                if(dao.CheckUserName(model.name))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if(dao.CheckMail(model.email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else if(dao.CheckPhone(model.phone))
                {
                    ModelState.AddModelError("", "Số điện thoại đã tồn tại");
                }
                else
                {
                    var customer = new CUSTOMER();
                    customer.name = model.name;
                    customer.password0 = model.password0;
                    customer.email = model.email;
                    customer.phone = model.phone;
                    customer.zipcode = model.zipcode;
                    customer.address0 = model.address0;
                    customer.city = model.city;
                    customer.country = model.country;
                    var result = dao.Insert(customer);
                    if(result>0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegiterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                    
                }
                
            }
            return View(model);
        }
        public ActionResult CustomerDetail()
        {
            var customer = new CustomerDao().ListAll();
            return View(customer);
        }

    }
}