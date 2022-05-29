using CourseWork.Services.Interfaces;
using CourseWork.WebApp.Mapping;
using CourseWork.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.WebApp.Controllers
{
    public class AircompanyController : Controller
    {
        private readonly IStorage _storage;

        public AircompanyController(IStorage storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new DataInputViewModel());
        }

        [HttpPost]
        public IActionResult Loading(DataInputViewModel Model)
        {
            if (!ModelState.IsValid)
                return View(Model);

            if (!(Model.FileType == "json" || Model.FileType == "xml"))
                ModelState.AddModelError("", "Некорректный тип файла");

            if (Model.FileType == "json")
                _storage.DownloadFromJson(Model.FileOutput);
            else
                _storage.DownloadFromXml(Model.FileOutput);

            

            return RedirectToAction(nameof(ShowCompany));
        }

        [HttpGet]
        public IActionResult ShowCompany()
        {
            var aircompany_view = _storage.GetMainStructure().ToView();
            return View(aircompany_view);
        }

        [HttpGet]
        public IActionResult CreateAirplane(string name_airport)
        {
            return View(new CreateAirplaneViewModel { AirportName = name_airport }); 
        }

        [HttpPost]
        public IActionResult CreateAirplane(CreateAirplaneViewModel Model)
        {
            _storage.AddAirplane(Model.Brand, Model.YearofManufacture, Model.AirportName);
            return RedirectToAction(nameof(ShowCompany));
        }
    }
}
