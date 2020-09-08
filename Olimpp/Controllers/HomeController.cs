using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olimpp.Data;
using Olimpp.Models;
using Olimpp.Models.ViewModels;
using OlimppML.Model;

namespace Olimpp.Controllers
{
    public class HomeController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        int count = -1;
        bool flag = true;
        private UserManager<IdentityUser> _usermanager;
        private ApplicationDbContext _contex;

         
        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> roleManager )
       // public HomeController(ApplicationDbContext context)
        {
            _contex = context;
            _usermanager = usermanager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();

        }

        public async Task<IActionResult> Search(string search)
        {
            
            if (search == null)
            {
                search = "";
            }

            return RedirectToAction(nameof(Filme), new { search = search });

        }

        public IActionResult Filme(string CautaDupaNume)
        {
            var produs = new List<MovieDetalies>();
            bool searched = false;
            if (CautaDupaNume != null)
            {
                produs = _contex.MovieDetalies.Where(p => p.MovieName.Contains(CautaDupaNume)).ToList();
                searched = true;
                return View(produs);

            }

            var getMovieList = _contex.MovieDetalies.ToList();
            return View(getMovieList);
        }

        [HttpGet]
        public IActionResult Predict()
        {
            return View();
        }

        public ActionResult Predict(ModelInput input)
        {
            var prediction = ConsumeModel.Predict(input);
            ViewBag.Result = prediction;
            return View();

        }


        [HttpGet]
        public IActionResult RezervaAcum(int Id)
        {
            BookNowViewModel vn = new BookNowViewModel();

            var item = _contex.MovieDetalies.Where(a => a.Id == Id).FirstOrDefault();
            vn.MovieName = item.MovieName;
            vn.MovieDate = item.DateAndTime;
            vn.MovieId = Id;


            return View(vn);
        }

        [Authorize(Roles = "Administrator,User")]
        [HttpPost]
        public IActionResult RezervaAcum(BookNowViewModel vn)
        {
            List<BookingTable> booking = new List<BookingTable>();
            List<Cart> carts = new List<Cart>();
            string seatno = vn.SeatNo.ToString();
            int movieId = vn.MovieId;

            string[] seatnoArray = seatno.Split(',');
            count = seatnoArray.Length;
            if (VerificaScaun(seatno, movieId) == false)
            {
                foreach (var item in seatnoArray)
                {
                    carts.Add(new Cart { Amount = 150, MovieId = vn.MovieId, UserId = _usermanager.GetUserId(HttpContext.User), date = vn.MovieDate, seatno = item });
                }

                foreach (var item in carts)
                {
                    _contex.Cart.Add(item);
                    _contex.SaveChanges();

                }
                TempData["SUCESS"] = "Loc fara Rezervare, Verificati Cosul";

            }
            else
            {
                TempData["seatnomsg"] = "Va rugam schimbati locul numarului";

            }
            return RedirectToAction("RezervaAcum");

        }

        private bool VerificaScaun(string seatno, int movieId)
        {
            // throw new NotImplementedException();
            string seats = seatno;
            string[] seatreserve = seats.Split(',');
            var seatnolist = _contex.BookingTable.Where(a => a.MovieDetaliesId == movieId).ToList();

            foreach (var item in seatnolist)
            {
                string dejarezervat = item.seatno;

                foreach (var item1 in seatreserve)
                {
                    if (item1 == dejarezervat)
                    {
                        flag = false;
                        break;
                    }
                }

            }

            if (flag == false)
                return true;
            else
                return false;

        }

        [HttpPost]
        public IActionResult VerificaScaun(DateTime MovieDate, BookNowViewModel booknow)
        {
            string seatno = string.Empty;
            var movielist = _contex.BookingTable.Where(a => a.DateToPresent == MovieDate).ToList();
            if (movielist != null)
            {
                var getseatno = movielist.Where(b => b.MovieDetaliesId == booknow.MovieId).ToList();
                if (getseatno != null)
                {
                    foreach (var item in getseatno)

                    {
                        seatno = seatno + " " + item.seatno.ToString();

                    }
                    TempData["SNO"] = "Deja rezervat:" + seatno;
                }

            }

            return View();
        }


        public IActionResult Privacy()
        {
            
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviedetalies = await _contex.MovieDetalies
             
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviedetalies == null)
            {
                return NotFound();
            }

            return View(moviedetalies);
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
