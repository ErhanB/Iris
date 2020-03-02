using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iris.Models;
using Iris.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Iris.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly IDataRepository<Team> _repository;

        public TeamController(GRepository<Team> dataRepository)
        {
            _repository = dataRepository;
        }

        // API-GET
        [HttpGet]

        public ActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }


        //API - POST
        [HttpPost]
        public ActionResult Add(Team model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                _repository.Save();
                return RedirectToAction("Index", "Team");
            }
            return View();
        }


        // API-PUT
        [HttpPut("{id}")]
        public ActionResult Edit(Team model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                _repository.Save();
                return RedirectToAction("Index", "Team");
            }
            else
            {
                return View(model);
            }
        }

        // API-DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Team team = _repository.Get(id);
            _repository.Delete(team);
            return NoContent();
        }
    }
}

