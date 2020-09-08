using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Olimpp.Data;
using Olimpp.Models;

namespace Olimpp.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class CartTController : Controller
    {
        private UserManager<IdentityUser> _usermanager;
        private ApplicationDbContext _contex;

        public CartTController(ApplicationDbContext contex, UserManager<IdentityUser> usermanager)
        {
            _usermanager = usermanager;
            _contex = contex;
        }

        public IActionResult Index()
        {

            var item = _contex.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            return View(item);
        }

        [HttpGet]
        public IActionResult CosGol()
        {

            TempData["cosgol"] = "Cos Gol";
            return View();
        }

        [HttpGet]
        public IActionResult proceed(Cart cart)
        {
            var CartList = _contex.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();

            if (CartList.Count == 0)
            {
                return RedirectToAction("CosGol", "CartT");
            }
            else
            {
                return View(CartList);
            }
        }
        

        public IActionResult BookTicket(Cart cart)
        {
            List<BookingTable> bt = new List<BookingTable>();
            var CartList = _contex.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
            foreach (var item in CartList)
            {
                bt.Add(new BookingTable { DateToPresent = item.date, MovieDetaliesId = item.MovieId, seatno = item.seatno, UserId = item.UserId, Amount = item.Amount });

            }
            foreach (var item in bt)
            {
                _contex.BookingTable.Add(item);
                _contex.SaveChanges();
            }
            if (cart != null)
            {
                var itemList = _contex.Cart.Where(a => a.UserId == _usermanager.GetUserId(HttpContext.User)).ToList();
                foreach (var item in itemList)
                {
                    _contex.Cart.Remove(item);
                    _contex.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
            
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var item = _contex.Cart.Where(a => a.Id == Id).SingleOrDefault();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int Id)
        {
            var item = _contex.Cart.Where(a => a.Id == Id).SingleOrDefault();
            _contex.Cart.Remove(item);
            _contex.SaveChanges();
            return RedirectToAction("Index", "CartT");
        }

    }
}
    