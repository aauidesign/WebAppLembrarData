using AppLembrarData.Entity;
using AppLembrarData.Entity.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace AppLembrarData.Controllers
{

    public class CompromissoController : Controller
    {
        private readonly Context _context;

        public CompromissoController(Context context)
        {
            _context = context;
        }


        //public IActionResult Index()
        //{
        //    var listaCompromisso = _context.Compromissos.ToList().OrderBy(c => c.DataCompromisso);

        //    return View(listaCompromisso);
        //}


        //public IActionResult Index(int? pagina)
        //{
        //    int tamanhoPagina = 10;
        //    int numeroPagina = pagina ?? 1;

        //    var listaCompromisso = _context.Compromissos.OrderBy(c => c.DataCompromisso).ToPagedList(numeroPagina, tamanhoPagina);

        //    return View(listaCompromisso);
        //}


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 10)
        {

            //    int tamanhoPagina = 10;
            //    int numeroPagina = pagina ?? 1;
            var search = Request.Query["search"].ToString();
            var compromissos = _context.Compromissos.OrderBy(p => p.DataCompromisso).Where(p => p.Titulo.Contains(search));
            PagedList<Compromisso> model = new PagedList<Compromisso>(compromissos, page, pageSize);

            ViewBag.Search = search;

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var compromisso = new Compromisso();
            PopularTipoCompromisso();
            Status();

            return View(compromisso);
        }

        [HttpPost]
        public IActionResult Create(Compromisso compromisso)
        {
            if (!ModelState.IsValid)
            {
                PopularTipoCompromisso();
                Status();
                return View(compromisso);
            }

            PopularTipoCompromisso();
            Status();

            _context.Compromissos.Add(compromisso);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var compromisso = _context.Compromissos.Find(id);

            PopularTipoCompromisso();
            Status();

            return View(compromisso);
        }

        [HttpPost]
        public IActionResult Edit(Compromisso compromisso)
        {
            if (!ModelState.IsValid)
            {
                PopularTipoCompromisso();
                Status();
                return View(compromisso);
            }

            PopularTipoCompromisso();
            Status();

            _context.Compromissos.Update(compromisso);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var compromisso = _context.Compromissos.Find(id);

            PopularTipoCompromisso();
            Status();

            return View(compromisso);
        }

        [HttpPost]
        public IActionResult Delete(Compromisso compromisso)
        {
            if (!ModelState.IsValid)
            {
                PopularTipoCompromisso();
                Status();
                return View(compromisso);
            }

            PopularTipoCompromisso();
            Status();

            _context.Compromissos.Remove(compromisso);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var compromisso = _context.Compromissos.Find(id);
            PopularTipoCompromisso();
            Status();

            return View(compromisso);
        }


        public void PopularTipoCompromisso()
        {
            var tipoCompromisso = new List<SelectListItem>
            {
                new SelectListItem {Text = "Escolha", Value = "0"},
                new SelectListItem {Text = "Aniversário", Value = "1"},
                new SelectListItem {Text = "Feriado", Value = "2"},
                new SelectListItem {Text = "Outro", Value = "3"}
            };

            ViewBag.TipoCompromisso = tipoCompromisso;
        }

        public void Status()
        {
            var status = new List<SelectListItem>
            {
                new SelectListItem {Text = "Escolha", Value="0"},
                new SelectListItem {Text = "Ativo", Value="1"},
                new SelectListItem {Text = "Inativo", Value="2"},
                new SelectListItem {Text= "Concluido", Value="3"},
                new SelectListItem {Text ="Cancelado", Value="4"}
            };

            ViewBag.Status = status;
        }


    }
}
