using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using VT.CodeTest.WebSite.Equation;
using VT.CodeTest.WebSite.Models;

namespace VT.CodeTest.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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
            try
            {
                ViewBag.EquationResult = Operation<IBinaryOperation, decimal>(equationParameters);
                ViewBag.SupportedOperators = SupportedOperators.GetSupportedOperatorsAsListItems();
            }
            catch (System.DivideByZeroException ex)
            {
                ViewBag.EquationResult = ex.Message;
            }

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

        private TResponse Operation<T, TResponse>(T operation)
            where T : IBinaryOperation
        {

            var be = Expression.MakeBinary(operation.BinaryOperator, operation.LeftHandSide, operation.RightHandSide);
            Expression<Func<TResponse>> le = Expression.Lambda<Func<TResponse>>(be);
            return le.Compile()();
        }

    }
}
