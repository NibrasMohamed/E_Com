﻿using LapShop.DataBaseConnection;
using LapShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Diagnostics;

namespace LapShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, MyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Products()
        {
            var categories = _dbContext.Categories.ToList();
            var brands = _dbContext.Brands.ToList();
            var series = _dbContext.Series.ToList();
            var products = _dbContext.Models.ToList();

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            ViewBag.Products = products;

            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}