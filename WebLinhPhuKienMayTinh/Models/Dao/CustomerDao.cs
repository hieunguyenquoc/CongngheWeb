using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLinhPhuKienMayTinh.Models.EF;
using PagedList;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Data.Entity;

namespace WebLinhPhuKienMayTinh.Models.Dao
{
    public class CustomerDao
    {
        web db = null;
        public CustomerDao()
        {
            db = new web();
        }
        public int Insert(CUSTOMER id)
        {
            db.CUSTOMERs.Add(id);
            db.SaveChanges();
            return id.customer_id;
        }
        public CUSTOMER GetById(string userName)
        {
            return db.CUSTOMERs.SingleOrDefault(x => x.name == userName);
        }
        public int Login(string name, string password)
        {
            var result = db.CUSTOMERs.SingleOrDefault(x => x.name == name);
            if(result == null)
            {
                return 0;
            }    
            else
            {
                if (result.password0 == password)
                    return 1;
                else
                    return 2;
            }    
        }
        public bool CheckUserName(string userName)
        {
            return db.CUSTOMERs.Count(x => x.name == userName) > 0;
        }
        public bool CheckMail(string mail)
        {
            return db.CUSTOMERs.Count(x => x.email == mail) > 0;
        }
        public bool CheckPhone(string phone)
        {
            return db.CUSTOMERs.Count(x => x.phone == phone) > 0;
        }
        public IEnumerable<CUSTOMER> UserProfile(string searchString, int page, int pageSize)
        {
            IQueryable<CUSTOMER> model = db.CUSTOMERs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.name.Contains(searchString) || x.address0.Contains(searchString) || x.city.Contains(searchString) || x.zipcode.Contains(searchString) || x.email.Contains(searchString) || x.phone.Contains(searchString));
                //Contains tìm kiếm gần đúng
            }
            return model.OrderByDescending(x => x.customer_id).ToPagedList(page, pageSize);
        }
        public CUSTOMER Viewdetail(int id)
        {

            return db.CUSTOMERs.Find(id);//lay ra id

        }
        public List<CUSTOMER> ListAll()
        {
            return db.CUSTOMERs.ToList();
        }
        
    }
}