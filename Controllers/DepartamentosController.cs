using Microsoft.AspNetCore.Mvc;
using MvcNetCoreAWSPostgresEC2.Models;
using MvcNetCoreAWSPostgresEC2.Repositories;

namespace MvcNetCoreAWSPostgresEC2.Controllers
{
    public class DepartamentosController: Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repository)
        {
            this.repo = repository;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> depts = await repo.GetDepartamentos();
            return View(depts);
        }

        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await repo.GetDepartamento(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await repo.AddDepartamento(departamento);
            return RedirectToAction("Index");
        }
    }
}
