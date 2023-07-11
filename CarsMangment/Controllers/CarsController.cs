using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarsMangment.Data;
using CarsMangment.Models;
using System.Collections;
using CarsMangment.Services;

namespace CarsMangment.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarBO _bo;
        private readonly ICacheService _cacheService;
        public CarsController(CarBO bo, ICacheService cacheService)
        {
            _bo = bo;
            _cacheService = cacheService;
        }

        // GET: Cars
        public IActionResult Index()
        {
            var cacheCars = _cacheService.GetData<IEnumerable<Car>>("cars") as List <Car>;
            if (cacheCars != null && cacheCars.Count() > 0)
                return View(cacheCars);
            var cars = _bo.GetCars();
            var expirtyTime=DateTimeOffset.Now.AddMinutes(2);
            _cacheService.SetData<IEnumerable<Car>>("cars", cars, expirtyTime);
            return View(cars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var car = await _bo.GetCarDetails(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarNumber,Type,Capacity,Color,Fare,HasDriver,DriverId,CustomerId")] Car car)
        {
            if (ModelState.IsValid)
            {
                await _bo.Add(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }


        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _bo.GetCarDetails(id.Value);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarNumber,Type,Capacity,Color,Fare,HasDriver,DriverId,CustomerId")] Car car)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var carnew= await _bo.Update(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                   return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }


        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var car = await _bo.GetCarDetails(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var car = await _bo.GetCarDetails(id);
            if (car != null)
            {
                await _bo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
