﻿using RedRestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RedRestaurantRater.Controllers {
    public class RestaurantController : Controller {
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant
        public ActionResult Index() {
            return View(_db.Restaurants.ToList());
        }
        //Get: Restaurant/Create
        public ActionResult Create() {
            return View();
        }
        //Post: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant) {
            if (ModelState.IsValid) {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //Get: Restaurant/Details/{id}
        public ActionResult Details(int? id) {
            if (id is null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant is null)
                return HttpNotFound();
            return View(restaurant);
        }
        //Get:  Restaurant/Edit/{id}
        public ActionResult Edit(int? id) {
            if (id is null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant is null)
                return HttpNotFound();
            return View(restaurant);
        }
        //Post: Restaurant/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Restaurant restaurant) {
            if (ModelState.IsValid) {
                _db.Entry(restaurant).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        } 

        //Get: Restaraurant/Delete/{id}
        public ActionResult Delete(int? id) {
            if (id is null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant is null)
                return HttpNotFound();
            return View(restaurant);
        }
        //POST : Restaurant/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}