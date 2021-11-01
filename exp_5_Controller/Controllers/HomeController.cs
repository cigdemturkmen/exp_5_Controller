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
        /*geri dönüşler
         -ActionResult
         -ContentResult
        -
        -

        action attribute'leri
        
         */

        //home/index
        //[HttpGet]
        //[HttpPost]
        [ActionName("anasayfa")] //home/anasayfa
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration =360)] //1 saat boyunca bu action'a girmez. server side cashe
        public ContentResult Hakkimizda()  /*content result için view'a ihtiyaç yok */
        {
            var str = "<h1>Hoşgeldiniz, burası hakkımızda sayfası</h1>";
            str += "<h2>selam</h2>";
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
            // json: javascript object notation. bir file standartı. bir sayfadan bir sayfaya veri taşıma standardı. XML.(okunurluğu jsona göre az) web APIda daha çok kullanıcaz.
           

            return Json(ogrenciler, JsonRequestBehavior.AllowGet); //json isteğine izin vermemiz gerekiyor.
        }
    }
}