using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ExclusionaryList.Models;
namespace ExclusionaryList.Controllers
{
    public class HomeController : Controller
    {

        public static DwainEntities ctx { get; set; }

        public ActionResult Index()
        {
            DwainEntities dwe = new DwainEntities();
            

            return View();
        }


        public JsonResult IndexData()
        {
            DwainEntities ctx = new DwainEntities();

            ExclusionaryListModel elm = new ExclusionaryListModel();
            List<ListDetails> myLists = new List<ListDetails>();
            var lists = from el in ctx.AppinstLists
                        select el;


            var ListTypes = from c in ctx.ListTypes
                            select new Picker { Description = c.Enum, Id = c.ListTypeID };

             foreach(var item in lists)
             {
                 ListDetails ld = new ListDetails();
                 ld.ListId = item.AppinstListID;
                 ld.ListName = item.ListName;
                 ld.urlPath = "/Home/ItemDetails/" + item.AppinstListID.ToString();
                 myLists.Add(ld);
             }

             elm.Types = ListTypes.ToList();
             elm.LineItems = myLists;

            return Json(elm, JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult ItemDetails(int id)
        {

            ctx = new DwainEntities();
            var details = ctx.AppInstListDetails.Where(a => a.AppInstListID == id);
          
           
            return View();
        }

        [HttpPost]
        public JsonResult ItemDetails(ExclusionaryListModel mod)
        {

            ctx = new DwainEntities();
          //  ExclusionaryListModel elm = new ExclusionaryListModel();
            List<LineItemDetails> MyDetails = new List<LineItemDetails>();
            var details = ctx.AppInstListDetails.Where(a => a.AppInstListID == mod.selectedId);
            foreach (var item in details)
            {
                LineItemDetails lid = new LineItemDetails();
                lid.FirstName = item.FirstName;
                lid.LastName = item.LastName;
                lid.License = item.LicenseNo;
                lid.State = item.State;
                lid.ListType = DetermineListType(item.AppInstListTypeID);
                MyDetails.Add(lid);
            }
            mod.ItemDetails = MyDetails;

            return Json(mod, JsonRequestBehavior.AllowGet);
        }

        private string DetermineListType(int? value)
        {
            string type = "";
            switch(value){
                case 1:
                    type = "Post";
                break;
            case 2:
                type = "Pre";
                break;
                case 3:
                type = "WatchList";
                break;
        }
            return type;
       }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}