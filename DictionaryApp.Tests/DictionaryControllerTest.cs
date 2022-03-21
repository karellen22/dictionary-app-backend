using DictionaryApp.Database.Models;
using DictionaryApp.DataLayer;
using DictionaryApp.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryApp.Tests
{
    public class Tests
    {
        private readonly DictionaryController _controller;
        private readonly IDictionaryServices _service;

        public Tests()
        {
            _service = new DictionaryServicesFake();
            var mock = new Mock<ILogger<DictionaryController>>();
            ILogger<DictionaryController> logger = mock.Object;
            _controller = new DictionaryController(logger, _service);
        }

        [Test]
        public void Get_WhenMethodCalled_ReturnsOk()
        {
            var dictionary = _controller.GetDictionaryEntries();
            var okObjectResult = dictionary as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
        }

        [Test]
        public void Get_WhenMethodCalled_ReturnsDictionaryEntries()
        {
            var dictionary = _controller.GetDictionaryEntries();
            var okObjectResult = dictionary as OkObjectResult;
            var dictionaryEntries = okObjectResult.Value as IEnumerable<DictionaryEntry>;
            Assert.IsNotNull(dictionaryEntries);
        }

        [Test]
        public void Get_WhenMethodCalled_ReturnsEveryEntry()
        {
            var dictionary = _controller.GetDictionaryEntries();
            var okObjectResult = dictionary as OkObjectResult;
            var dictionaryEntries = okObjectResult.Value as IEnumerable<DictionaryEntry>;
            Assert.AreEqual(5, dictionaryEntries.ToList().Count);
        }
    }
}