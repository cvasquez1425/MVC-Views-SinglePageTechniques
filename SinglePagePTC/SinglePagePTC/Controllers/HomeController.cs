using SinglePage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePagePTC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //            TrainingProductManager mgr = new TrainingProductManager();  // to reduce code in the controller, we'll use the MVVM pattern by using TrainingProductViewModel instead.
            TrainingProductViewModel vm = new TrainingProductViewModel();

            // vm.Get(); // call the Get method on that view model to populate the Products collection
            // After implementing HandleRequest
            vm.HandleRequest();

            //            return View(mgr.Get());
            return View(vm);  // passing the whole view model, because we're going to pass additional properties that the view can use.
        }

        [HttpPost]
        public ActionResult Index(TrainingProductViewModel vm)
        {
            vm.IsValid = ModelState.IsValid;  // MVC will validate the State and give it to ViewModel
            vm.HandleRequest();

            if (vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                foreach (KeyValuePair<string, string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return View(vm);
        }


    }
}