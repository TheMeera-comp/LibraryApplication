using LibraryApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace LibraryApplication.Controllers
{
    public class BookController : Controller
    {
        public static List<Bookdto> Books = new List<Bookdto> {

            new Bookdto{ID=1,Title="Why Men Love Bitches",Description="From Doormat to Dream girl a woman's guide to holding her own in a relationship",Author="Sherry Argov",AuthorId=1,Price=3.5 },
            new Bookdto{ID=2,Title="Men are from Mars and Women are from Venus",Description="the book explores the differences between men and women in terms of communication styles, emotional needs, and behavior.",Author="John Gray",AuthorId=2,Price=4.5 },
            new Bookdto{ID=3,Title="The Five Love Languages",Description="The book introduces the concept that individuals have different ways of expressing and receiving love",Author="Dr. Gary Chapman",AuthorId=3,Price=2.5 },
            new Bookdto{ID=4,Title="The Secret",Description="The book posits that positive thinking and the power of one's mind can significantly influence life outcomes and achieve personal goals.",Author="Rhonda Byrne",AuthorId=4,Price=5 },
        };





        // GET: BookController
        public ActionResult Index()
        {
            ViewBag.WelcomePhrase = "Welcome to our Cute BookShop! Please choose your book and pick a place to sit, or proceed to purchasing your new bestfriend :)";
            ViewData["WeHave"]= "This is the list of books we have...choose what you like";
            return View(Books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var model= Books[id];



            return View(model);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bookdto book)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Books.Add(book);

                }
                else
                {
                    return View();

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Books.Where(x => x.ID == id).FirstOrDefault();
            if (model == null)
            {
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View(model);

            }


            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Bookdto book)
        {
            try
            {
                var model = Books.Where(x => x.ID == id).FirstOrDefault();
                if (model != null)
                {
                    model.ID = book.ID;
                    model.Title = book.Title;    
                    model.Author = book.Author;
                    model.AuthorId = book.AuthorId;
                    model.Price = book.Price;
                    model.Description= book.Description;

                    return RedirectToAction(nameof(Index));
                }
                
                
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Books.Where(x=> x.ID==id).FirstOrDefault();
            if (model != null)
            {
                Books.Remove(model);

            }

            return RedirectToAction(nameof(Index));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
