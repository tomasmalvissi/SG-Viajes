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

        public IActionResult Index(string filtro)
        {
            ViewData["Filtro"] = filtro;
            IEnumerable<Viaje> listViajes = _context.Viajes;
            if (!String.IsNullOrWhiteSpace(filtro))
            {
                listViajes = _context.Viajes.Where(v => v.NroViaje.ToString().Contains(filtro) || 
                v.FechaViaje.ToString().Contains(filtro) || v.Empresa.Contains(filtro) || 
                v.Origen.Contains(filtro) || v.Destino.Contains(filtro) || 
                v.Total.ToString().Contains(filtro));
            }
            
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
            viaje.ImporteEsp = viaje.MinEsper * viaje.PrecioEspera;
            viaje.Importe = (viaje.KM * viaje.PrecioKM) + viaje.ImporteEsp;
            viaje.Total = viaje.Importe - (viaje.PeajeEst - viaje.GNC - viaje.Nafta);
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

        //HTTP GET ESTADISTICAS PARA MOSTRAR VIEW
        public IActionResult Estadisticas(String filtro, Viaje viaje)
        {
            List<Viaje> lista = new();
            viaje.KM = _context.Viajes.Sum(v => v.KM);
            viaje.Nafta = _context.Viajes.Sum(v => v.Nafta);
            viaje.GNC = _context.Viajes.Sum(v => v.GNC);
            viaje.PeajeEst = _context.Viajes.Sum(v => v.PeajeEst);
            viaje.MinEsper = _context.Viajes.Sum(v => v.MinEsper);
            viaje.Importe = _context.Viajes.Sum(v => v.Importe);
            viaje.Total = _context.Viajes.Sum(v => v.Total);
            lista.Add(viaje);
            ViewData["Filtro"] = filtro;
            if (!String.IsNullOrWhiteSpace(filtro))
            {
                //lista = _context.Viajes.Where(v => v.FechaViaje.Month.ToString().Contains(filtro));
            }

            return View(lista);
        }
    }
}
