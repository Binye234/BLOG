using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Model;

namespace UI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private InfoDal infoDal = new InfoDal();
        // GET: Manage
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string title,string introduce,string context)
        {
            try
            {
                infoDal.Insert(title, introduce, context);
                return Json(true);
            }catch(Exception e)
            {
                return Json(false);
            }
        }

        public ActionResult Delete(int page=0, bool flag = true)
        {
            var nums = infoDal.GetAllNums() / 10; ;
            if (page < 0)
            {
                page = 0;
            }
            if (page > nums)
            {
                page = nums;
            }
            ViewBag.HotList = infoDal.GetHostList();
            var list = infoDal.GetInfoAll(page, flag);
            ViewBag.Flag = flag;
            ViewBag.page = page;
            ViewBag.Nums = nums;
            return View(list);
            
        }
        
        public ActionResult TrueDelete(int id)
        {
            try
            {
                infoDal.Delete(id);
                return Redirect("/Manage/Delete");
            }catch(Exception e)
            {
                return Redirect("Error");
            }
        }
    }
}