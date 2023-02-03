using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion_library.Models;
using PagedList.Mvc;
using PagedList;
using System.Data.Entity;

namespace Orion_library.Controllers
{
    public class DashboardDisplayController : Controller
    {
        MyDbContext MyDbObj = new MyDbContext();
        // GET: DashboardDisplay
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Dashboard(int? page, string searching, string SortBy)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var PageNumber = page ?? 1;
            var PageSize = 50;
            ViewBag.totatlist = MyDbObj.LibraryRecords.Where(m => m.IsDeleted == false).ToList().Count();
            var MainList = MyDbObj.LibraryRecords.Where(m => m.IsDeleted == false).ToList().ToPagedList(PageNumber, PageSize);


            //for searching
            var SearchList = MyDbObj.LibraryRecords.Where(m => (m.Author1.Contains(searching) && m.IsDeleted==false)
            || (m.Author2.Contains(searching) && m.IsDeleted == false) || (m.Description.Contains(searching) && m.IsDeleted == false)
            || (m.Topics.Contains(searching) && m.IsDeleted == false) || (m.Title.Contains(searching) && m.IsDeleted == false) || (m.Language.Contains(searching) && m.IsDeleted == false)).ToList().ToPagedList(PageNumber, PageSize);


            //for sorting by particular column name
            if (SortBy == "Title")
            {
                var sort = MyDbObj.LibraryRecords.OrderBy(m => m.Title).ToList().ToPagedList(PageNumber, PageSize);
                return View(sort);
            }
            else if (SortBy == "Author1")
            {
                var sort = MyDbObj.LibraryRecords.OrderBy(m => m.Author1).ToList().ToPagedList(PageNumber, PageSize);
                return View(sort);
            }
            else if (SortBy == "Author2")
            {
                var sort = MyDbObj.LibraryRecords.OrderBy(m => m.Author2).ToList().ToPagedList(PageNumber, PageSize);
                return View(sort);
            }
            else if (SortBy == "Description")
            {
                var sort = MyDbObj.LibraryRecords.OrderBy(m => m.Description).ToList().ToPagedList(PageNumber, PageSize);
                return View(sort);
            }
            else if (SortBy == "Language")
            {
                var sort = MyDbObj.LibraryRecords.OrderBy(m => m.Language).ToList().ToPagedList(PageNumber, PageSize);
                return View(sort);
            }
            else if (SortBy == "Topics")
            {
                var sort = MyDbObj.LibraryRecords.OrderBy(m => m.Topics).ToList().ToPagedList(PageNumber, PageSize);
                return View(sort);
            }


            if (searching == null)
            {
                return View(MainList);
            }
            else
            {
                return View(SearchList);
            }
        }






        //Action method for delete opeartion
        public ActionResult Delete(int DeleteBy)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var Data = MyDbObj.LibraryRecords.Where(m => m.ID == DeleteBy).FirstOrDefault();
            if (Data != null)
            {
                if (Data.ID == DeleteBy)
                {
                    Data.IsDeleted = true;
                    MyDbObj.SaveChanges();
                }

            }
            return RedirectToAction("Dashboard");
        }

        //Action method for Edit opeartion
        public ActionResult Edit(int EditBy)
        {
            var EditData = MyDbObj.LibraryRecords.Find(EditBy);
            return View(EditData);
        }
        [HttpPost]
        public ActionResult Edit(LibraryRecord DataObj)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var EditData = MyDbObj.LibraryRecords.Find(DataObj.ID);
            EditData.Title = DataObj.Title;
            EditData.Author1 = DataObj.Author1;
            EditData.Author2 = DataObj.Author2;
            EditData.Description = DataObj.Description;
            EditData.Language = DataObj.Language;
            MyDbObj.SaveChanges();
            return RedirectToAction("Dashboard");
        }

    }
}
