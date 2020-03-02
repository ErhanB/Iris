using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iris.Models;
using Iris.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Iris.Controllers
{
        [Route("api/position")]
        [ApiController]
    public class PositionController : Controller
    {
        private readonly IDataRepository<Position> _repository;

        public PositionController(GRepository<Position> dataRepository)
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
        public ActionResult Add(Position model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                _repository.Save();
                return RedirectToAction("Index", "Position");
            }
            return View();
        }


        // API-PUT
        [HttpPut("{id}")]
        public ActionResult Edit(Position model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                _repository.Save();
                return RedirectToAction("Index", "Position");
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
            Position position = _repository.Get(id);
            _repository.Delete(position);
            return NoContent();
        }
    }
}

