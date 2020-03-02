using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iris.Models;
using Iris.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Iris.Controllers
{
    [Route("api/agent")]
    [ApiController]
    public class AgentController : Controller
    {
        private readonly IDataRepository<Agent> _repository;

        public AgentController(GRepository<Agent> dataRepository)
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
        public ActionResult Add(Agent model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                _repository.Save();
                return RedirectToAction("Index", "Agent");
            }
            return View();
        }


        // API-PUT
        [HttpPut("{id}")]
        public ActionResult Edit(Agent model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                _repository.Save();
                return RedirectToAction("Index", "Agent");
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
            Agent agent = _repository.Get(id);
            _repository.Delete(agent);
            return NoContent();
        }
    }
}

