using BOTest.Models;
using DB;
using DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BOTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseRepository _baseRepository;
        private readonly BODbContext _bODbContext;
        List<BaseEntity> entities = new List<BaseEntity>();

        public HomeController(ILogger<HomeController> logger, IBaseRepository baseRepository, BODbContext bODbContext)
        {
            _logger = logger;
            _baseRepository = baseRepository;
            _bODbContext = bODbContext;
        }

        public IActionResult Index()
        {
            
            return View(_baseRepository.BaseEntities);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SingleFile(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                //_baseService.UploadFile(reader);
                BaseEntity baseEntity;
                while (!reader.EndOfStream)
                {
                    string tempInfo = reader.ReadLine();
                    baseEntity = new BaseEntity()
                    {
                        Name = tempInfo.Split(',')[0],
                        DateOfBirth = DateTime.ParseExact(tempInfo.Split(',')[1], "dd/MM/yyyy", null),
                        Married = Convert.ToBoolean(tempInfo.Split(',')[2]),
                        Phone = tempInfo.Split(',')[3],
                        Salary = Convert.ToDecimal(tempInfo.Split(',')[4])
                    };

                    _bODbContext.Add(baseEntity);
                    _bODbContext.SaveChanges();
                }
            }

            return RedirectToAction("Index"); 
        }

        private void FetchData()
        {
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
