using Microsoft.AspNetCore.Mvc;
using SGVIAJES.DATA;
using SGVIAJES.WEB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGVIAJES.WEB.Controllers
{
    public class ViajesController : Controller
    {
        private readonly DataContext _context;
        public ViajesController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Viaje> listViajes = _context.Viajes;
            return View(listViajes);
        }

        //HTTP GET DEL CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                _context.Viajes.Add(viaje);
                _context.SaveChanges();

                TempData["Msj"] = "Nuevo Viaje cargado con exito.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET DEL EDIT
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var viaje = _context.Viajes.Find(id);

            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                _context.Viajes.Update(viaje);
                _context.SaveChanges();

                TempData["Msj"] = "Viaje actualizado con exito.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET DEL DELETE
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var viaje = _context.Viajes.Find(id);

            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteViaje(int? id)
        {
            var viaje = _context.Viajes.Find(id);

            if (viaje == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Viajes.Remove(viaje);
                _context.SaveChanges();

                TempData["Msj"] = "Viaje eliminado con exito.";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
