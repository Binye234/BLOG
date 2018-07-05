using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Model;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private InfoDal infoDal = new InfoDal();

        public ActionResult Index(int page=0,bool flag=true)
        {
            var nums= infoDal.GetAllNums() / 10; ;
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

        public ActionResult Show(int ID )
        {
            ViewBag.HotList = infoDal.GetHostList();
            var info = infoDal.FindID(ID);
            
            return View(info);
        }

        public ActionResult Add(string title, string introduce, string context)
        {
            infoDal.Insert(title,introduce,context);
            return Redirect("/Home/Index");
        }

        public ActionResult FindTitle(string title,int page=0)
        {
            var nums = infoDal.GetTitleNums(title) / 10;
            if (page < 0)
            {
                page = 0;
            }
            if (page > nums)
            {
                page = nums;
            }
            var list = infoDal.GetTitle(title,page);
            ViewBag.myTitle = title;
            ViewBag.page = page;
            ViewBag.Nums = nums;
            return View(list);
        }
    }
}