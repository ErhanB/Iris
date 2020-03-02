using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iris.Models;
using Iris.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Iris.Controllers
{
        [Route("api/player")]
        [ApiController]
        public class PlayerController : Controller
        {
            private readonly IDataRepository<Player> _repository;

            public PlayerController(GRepository<Player> dataRepository)
            {
                _repository = dataRepository;
            }

            // API-GET
            [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "None")] 
        public ActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }


        //API - POST
        [HttpPost]
        public ActionResult Add(Player model)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(model);
                _repository.Save();
                return RedirectToAction("Index", "Player");
            }
            return View();
        }


        // API-PUT
        [HttpPut("{id}")]
        public ActionResult Edit(Player model)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(model);
                _repository.Save();
                return RedirectToAction("Index", "Player");
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
                Player Player = _repository.Get(id);
                _repository.Delete(Player);
                return NoContent();
            }
        }
    }

