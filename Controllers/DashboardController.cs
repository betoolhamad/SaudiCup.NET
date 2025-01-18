using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cup.Data;
using Cup.Models;

namespace Cup.Controllers;

public class DashboardController : Controller
{

    private readonly ApplicationDbContext _context;
    private IWebHostEnvironment _webHostEnvironment;
    public DashboardController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment) {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        
    }

    
    // private readonly ILogger<DashboardController> _logger;

    // public DashboardController(ILogger<DashboardController> logger)
    // {
    //     _logger = logger;
    // }

    public IActionResult Index()

    {
        return View();
    }


    public IActionResult Categories() //read data

    {
        var getdata = _context.categories.ToList();
        return View(getdata);
    }

     public IActionResult CreateNewCategories(Categories categories) //create data

    {       
        _context.Add(categories);
        _context.SaveChanges();

        return RedirectToAction("Categories");
    }


        public IActionResult DeleteCategories(int id) {

            var categoriesDel = _context.categories.SingleOrDefault(c=> c.Id == id);
            
            if (categoriesDel != null) {
                _context.categories.Remove(categoriesDel);
                _context.SaveChanges();
            }

            var categries = _context.categories.ToList();

            return PartialView("_partial/_CategoriesPartialData", categries);

        }

        public IActionResult CreateNewCategoriesTransportation(CategoriesTransportation categoriesTransportation) //create data

        {    
            _context.Add(categoriesTransportation);
            _context.SaveChanges();
            return RedirectToAction("CategoriesTransportation");


        }

     public IActionResult CategoriesTransportation()

    {
        var getdata = _context.categoriesTransportation.ToList();
        return View(getdata);
    }


       public IActionResult CreateNewHotels(Hotels hotels, IFormFile photo) //create data

        {     
            if (photo == null || photo.Length == 0){
                return Content("File Not Selected");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName); // path

            using (FileStream stream = new FileStream(path, FileMode.Create)) {
                photo.CopyTo(stream);
                stream.Close();
            }

            hotels.Images = photo.FileName;
            _context.Add(hotels);
            _context.SaveChanges();
            return RedirectToAction("Hotels");


        }

        public IActionResult Hotels()

        {
        var getdata = _context.hotels.ToList();
        return View(getdata);
         }


          public IActionResult Transportation()

            {
            var getdata=_context.categoriesTransportation.ToList();
            ViewBag.getdata=getdata;

            var transport=_context.transportation.ToList();

            var GetdataTransport = _context.transportation.Join(

                _context.categoriesTransportation,

                transportation=>transportation.veichcle,
                categoriesTransportation=>categoriesTransportation.Id,

                (transportation,categoriesTransportation) => new
                {
                    Id=transportation.Id,
                    CarName=transportation.Name,
                    NameCategories=categoriesTransportation.Name,
                    CarColor=transportation.color,
                    Image=transportation.Images,
                    Model=transportation.Model,
                    Km=transportation.Km,
                    Carcpacity=transportation.Capacity,
                    Mversion=transportation.Modelversion,
                    



                }).ToList();

            ViewBag.getdatatransport=GetdataTransport;

            

            return View(transport);

            }


            public IActionResult CreateNewTransportation(Transportation transport, IFormFile photo)

            {

                if (photo == null || photo.Length == 0){
                return Content("File Not Selected");
                 }

                var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName); // path

                using (FileStream stream = new FileStream(path, FileMode.Create)) {
                    photo.CopyTo(stream);
                    stream.Close();
                }

                transport.Images = photo.FileName;
                _context.Add(transport);
                _context.SaveChanges();
                return RedirectToAction("Transportation");
           
            }



            public IActionResult EditCategories(int id){
                var edit_categories=_context.categories.SingleOrDefault(e=> e.Id == id);
                return View(edit_categories);
            }

        
            public IActionResult UpdateCtegories(Categories categories)
                {
                    _context.categories.Update(categories);
                    _context.SaveChanges();
                    return RedirectToAction("Categories");
                }

       

            public IActionResult Stadiums() //read data

                {
                    var getdata = _context.stadium.ToList();
                    return View(getdata);
                }

            public IActionResult CreateNewStadiums(Stadiums stadium) //create data

                    {       
                        _context.Add(stadium);
                        _context.SaveChanges();

                        return RedirectToAction("Stadiums");
                    }   


            public IActionResult DeleteStadium(int id) {

            var StumDel = _context.stadium.SingleOrDefault(s=> s.Id == id);
            
            if (StumDel != null) {
                _context.stadium.Remove(StumDel);
                _context.SaveChanges();
            }

            var stadium = _context.stadium.ToList();

            return RedirectToAction("Stadiums");

            }




            public IActionResult EditStadium(int id){
                var edit_stadium=_context.stadium.SingleOrDefault(e=> e.Id == id);
                return View(edit_stadium);
            }

        
            public IActionResult UpdateStadium(Stadiums stadium)
                {
                    _context.stadium.Update(stadium);
                    _context.SaveChanges();
                    return RedirectToAction("Stadiums");
                }

            public IActionResult FootballTabels()

                {
                    var getdata = _context.stadium.ToList();
                    ViewBag.getdata2 = getdata;

                    var footballTabels = _context.footballTabels.ToList(); //read from footballTabels

                    
                    var footballTabelss = _context.footballTabels.Join(
                        _context.stadium,
                        footballTabels => footballTabels.Stadiums_Id,
                        stadium => stadium.Id,
                        (footballTabels, stadium) => new FootballViewModel
                        {
                            Id = footballTabels.Id,
                            NameStadium = stadium.Name,
                            Team1 = footballTabels.Ateam1,
                            Team2 = footballTabels.Ateam2,
                            MatchTime = footballTabels.MatchTime
                        }
                    ).ToList();

                    return View(footballTabelss); // تمرير قائمة من نوع FootballViewModel إلى العرض
                

                }    




            public IActionResult CreateNewTableFootball(FootballTabels footballTabels) //create data

                    {       
                        _context.Add(footballTabels);
                        _context.SaveChanges();

                        return RedirectToAction("FootballTabels");
                    }  
                    

             public IActionResult Deletetable(int id) {

                var StumDel = _context.footballTabels.SingleOrDefault(s=> s.Id == id);
                
                if (StumDel != null) {
                    _context.footballTabels.Remove(StumDel);
                    _context.SaveChanges();
                }

                var stadium = _context.stadium.ToList();

                return RedirectToAction("FootballTabels");

            }


            public IActionResult Edittable(int id){
                var edit_table =_context.footballTabels.SingleOrDefault(e=> e.Id == id);
                var getdata = _context.stadium.ToList();

                ViewBag.getdata=getdata;
                return View(edit_table);
            }
            

            public IActionResult Updatetable(FootballTabels footballTabels)
                {
                    _context.footballTabels.Update(footballTabels);
                    _context.SaveChanges();
                    return RedirectToAction("FootballTabels");
                }


            

}
