using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VT.CodeTest.WebSite.Equation;
using VT.CodeTest.WebSite.Models;

namespace VT.CodeTest.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Func<decimal, decimal, decimal> Add = (a, b) => a + b;
        private readonly Func<decimal, decimal, decimal> Subtract = (a, b) => a - b;
        private readonly Func<decimal, decimal, decimal> Multiply = (a, b) => a * b;
        private readonly Func<decimal, decimal, decimal> Divide = (a, b) => a / b;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            EquationParameters equationParameters = new EquationParameters()
            {
                Number1 = 1,
                Number2 = 2,
                Operator = System.Linq.Expressions.ExpressionType.Add
            };

            ViewBag.SupportedOperators = SupportedOperators.GetSupportedOperatorsAsListItems();

            return View(equationParameters);
        }

        [HttpPost]
        public IActionResult Index([FromForm] EquationParameters equationParameters)
        {
            ViewBag.EquationResult = equationParameters.Operator switch
            {
                ExpressionType.Add => Add(equationParameters.Number1, equationParameters.Number2),
                ExpressionType.Subtract => Subtract(equationParameters.Number1, equationParameters.Number2),
                ExpressionType.Multiply => Multiply(equationParameters.Number1, equationParameters.Number2),
                ExpressionType.Divide => Divide(equationParameters.Number1, equationParameters.Number2),
                _ => throw new NotSupportedException()
            };

            ViewBag.SupportedOperators = SupportedOperators.GetSupportedOperatorsAsListItems();

            return View(equationParameters);
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
    }
}
