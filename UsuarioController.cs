using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usuarios.Models;

namespace Usuarios.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            using (DbModels contexto = new DbModels()){

                return View(contexto.Usuario.ToList());
            }
                
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels contexto = new DbModels())
            {

                return View(contexto.Usuario.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuarios)
        {
            try
            {
                using (DbModels contexto = new DbModels())
                {

                    contexto.Usuario.Add(usuarios);
                    contexto.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels contexto = new DbModels())
            {

                return View(contexto.Usuario.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuario usuarios)
        {
            try
            {
                using (DbModels contexto = new DbModels())
                {
                    contexto.Entry(usuarios).State = EntityState.Modified;
                    contexto.SaveChanges();

                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels contexto = new DbModels())
            {

                return View(contexto.Usuario.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels contexto = new DbModels())
                {
                    Usuario usuarios = contexto.Usuario.Where(x => x.ID == id).FirstOrDefault();
                    contexto.Usuario.Remove(usuarios);
                    contexto.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
