using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualBasic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq.Expressions;
using VT.CodeTest.WebSite.Controllers;
using VT.CodeTest.WebSite.Models;

namespace VT.Code.Test.WebSite.NUnitTests
{
    public class Tests
    {
        HomeController _controller;
        EquationParameters _equationParms;


        [SetUp]
        public void Setup()
        {
            _controller = new HomeController(new NullLogger<HomeController>());
            _equationParms = new EquationParameters()
            {
                Number1 = 8,
                Number2 = 4
            };
        }

        [Test]
        public void AddOperatorTest()
        {
            _equationParms.Operator = ExpressionType.Add;
            var result = _controller.Index(_equationParms) as ViewResult;
            var anw = result.ViewData["EquationResult"] as decimal?;
            Assert.AreEqual((result.ViewData["EquationResult"] as decimal?), _equationParms.Number1+_equationParms.Number2);
        }

        [Test]
        public void SubtractOperatorTest()
        {
            _equationParms.Operator = ExpressionType.Subtract;
            var result = _controller.Index(_equationParms) as ViewResult;
            var anw = result.ViewData["EquationResult"] as decimal?;
            Assert.AreEqual((result.ViewData["EquationResult"] as decimal?), _equationParms.Number1 - _equationParms.Number2);
        }

        [Test]
        public void MultiplyOperatorTest()
        {
            _equationParms.Operator = ExpressionType.Multiply;
            var result = _controller.Index(_equationParms) as ViewResult;
            Assert.AreEqual((result.ViewData["EquationResult"] as decimal?), _equationParms.Number1 * _equationParms.Number2);
        }

        [Test]
        public void DivideOperatorTest()
        {
            _equationParms.Operator = ExpressionType.Divide;
            var result = _controller.Index(_equationParms) as ViewResult;
            Assert.AreEqual((result.ViewData["EquationResult"] as decimal?), _equationParms.Number1 / _equationParms.Number2);
        }

        [Test]
        public void ModuloOperatorTest()
        {
            _equationParms.Operator = ExpressionType.Modulo;
            var result = _controller.Index(_equationParms) as ViewResult;
            Assert.AreEqual((result.ViewData["EquationResult"] as decimal?), _equationParms.Number1 % _equationParms.Number2);
        }

        [Test]
        public void GreaterThanOperatorTest()
        {
            _equationParms.Operator = ExpressionType.GreaterThan;
            Assert.Throws<System.NotSupportedException>(() => _controller.Index(_equationParms));
        }

    }
}
   