using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUploadControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olimpp.Data;
using Olimpp.Models;
using Olimpp.Models.ViewModels;

namespace Olimpp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _contex;
        private UploadInterface _upload;

        public AdminController(ApplicationDbContext context, UploadInterface upload)
        {
            _upload = upload;
            _contex = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IList<IFormFile> files, MovieDetaliesViewmodel vmodel, MovieDetalies movie)
        {
            string path = string.Empty;
            movie.MovieName = vmodel.Name;
            movie.MovieDescription = vmodel.Description;
            movie.DateAndTime = vmodel.DateofMovie;
            foreach (var item in files)
            {
                path = Path.GetFileName(item.FileName.Trim());
                movie.MoviePicture = "~/uploads/" + path;
            }

            _upload.uploadfilemultiple(files);
            _contex.MovieDetalies.Add(movie);
            _contex.SaveChanges();
            TempData["SUCESS"] = "SAVE your Movie";


            return RedirectToAction("Create","Admin");
        }

        [HttpGet]
        public IActionResult CheckBookSeat()
        {

            var getBookingTable = _contex.BookingTable.ToList().OrderByDescending(a => a.DateToPresent);
            return View(getBookingTable);
        }


        [HttpGet]
        public IActionResult GetUserDetails()
        {
            var getUserTable = _contex.Users.ToList();
            return View(getUserTable);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var item = _contex.BookingTable.Where(a => a.Id == Id).SingleOrDefault();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int Id)
        {
            var item = _contex.BookingTable.Where(a => a.Id == Id).SingleOrDefault();
            _contex.BookingTable.Remove(item);
            _contex.SaveChanges();
            return RedirectToAction("CheckBookSeat", "Admin");
        }

    }
}