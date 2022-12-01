using InventoryMng.Data;
using InventoryMng.Interfaces;
using InventoryMng.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace InventoryMng.Controllers
{
    [Authorize]
    public class UnitController : Controller
    {
        public IActionResult Index(int pg =1, int pageSize = 5)
        {
            List<Unit> units = _unitRepo.GetItems();

            var pager = new PagerModel(units.Count, pg, pageSize);
            this.ViewBag.Pager = pager;
            units = units.Skip((pg - 1) * pageSize).Take(pageSize).ToList();

            return View(units);
        }

        

        private readonly IUnit _unitRepo;
        public UnitController( IUnit unitrepo)
        {
            
            _unitRepo = unitrepo;
        }

        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Unit unit)
        {
            try
            {
                _unitRepo.Create(unit);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return View(unit);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
           
            Unit unit = _unitRepo.GetUnit(id);

            return View(unit);
        }

        public IActionResult Edit(int id)
        {
           
            return Details(id);
        }


        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                _unitRepo.Edit(unit);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return View(unit);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
           
            return Details(id);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                _unitRepo.Delete(unit);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return View(unit);
            }
            return RedirectToAction(nameof(Index));
        }


     
    }
}
