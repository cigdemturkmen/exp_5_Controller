using exp_5_Controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exp_5_Controller.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Json (JavaScript Object Notation): bütün programlama dilleri arasında, yapılandırılmış veri değişimini kolaylaştıran BİR METİN BİÇİMİDİR..
         * 
         Action methods are responsible to EXECUTE THE REQUEST and GENERATE A RESPONSE to it. All the public methods of the MVC Controller are action methods. If we want the public method to be a non-action method, then we can decorate the action method by “NonAction” attribute
         
         geri dönüşler
         - ActionResult
         - ContentResult : It displays the response without requiring a view .(like a plain text)
         - FileResult : Return a file from an action. (Pdf,Excel,image file,Html…)
         - JsonResult : Action methods return JsonResult that can be used in ajax based application.

        -----------------

        - ViewResult
        - PartialViewResult
        - RedirectResult: It is used to perform an HTTP redirect to a given URL. {  return Redirect(“http://www.google.com/”); }
        - RedirectToRouteResult : redirect by using the specified route values dictionary
        - EmptyResult
        - JavaScriptResult

        ***Action attribute'lerinden birkaçı: [ActionName(string)], [OutputCache(Duration =360)], [HttpGet], [HttpPost]
        
         */

        // home/index
        [ActionName("anasayfa")] // home/index yerine -> home/anasayfa yazarak sayfaya ulaşabiliriz.
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration =360)] //1 saat boyunca bu action'a girmez. veri server side cashe'de tutulur. istek gelince cashe'den dönülür.
        public ContentResult Hakkimizda()  /* ContentResult için view'a ihtiyaç yok. */
        {
            var str = "<h1>Hoşgeldiniz, burası hakkımızda sayfası!</h1>";
            str += "<h2>Şöyle buyurun...</h2>";
            return Content(str);
        }

        public FileResult Indir()
        {
            //Content type'lara mime typesdan erişilebilir
            return new FilePathResult(@"C:\Users\cigdem.turkmen\Desktop\IndirilecekDosya.pdf", "application/pdf");
        }

        public JsonResult GetStudents() /*asenkron yapılar için kullandığımız geri dönüş tipi. postback?*/
        {
            var ogrenciler = new List<Student>()
            {
                new Student {Id=1, Ad="Nur", Soyad="Öztürk"},
                new Student {Id=2, Ad="Çiğdem", Soyad="Türkmen"},
                new Student {Id=3, Ad="Leyla", Soyad="Taş"},
                new Student {Id=4, Ad="Bahar", Soyad="Taşbaş"},
            };
            // json: javascript object notation. bir file standartı. bir sayfadan bir sayfaya veri taşıma standardı. XML.(okunurluğu jsona göre az) web APIda daha çok kullanıcaz bunları.
           

            return Json(ogrenciler, JsonRequestBehavior.AllowGet); // json isteğine izin vermemiz gerekiyor(JsonRequestBehaviour.AllowGet)
        }
    }
}