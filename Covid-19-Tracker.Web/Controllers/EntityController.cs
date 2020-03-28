using System;
using Covid_19_Tracker.Persistence.Repositories.interfaces;
using Covid_19_Tracker.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Covid_19_Tracker.Web.Controllers
{
    public class EntityController : Controller
    {
        private readonly IEntityRepository _entityRepository;
      
        public EntityController(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;

        }

        public ViewResult Index()
        {
            var entityViewModel = new EntityViewModel();
            return View(entityViewModel);
        }

       
    }
}
