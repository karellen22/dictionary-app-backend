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
        public void GetDictionaryEntries_WhenMethodCalled_ReturnsOk()
        {
            var dictionary = _controller.GetDictionaryEntries();
            var okObjectResult = dictionary as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
        }

        [Test]
        public void GetDictionaryEntries_WhenMethodCalled_ReturnsDictionaryEntries()
        {
            var dictionary = _controller.GetDictionaryEntries();
            var okObjectResult = dictionary as OkObjectResult;
            var dictionaryEntries = okObjectResult.Value as IEnumerable<DictionaryEntry>;
            Assert.IsNotNull(dictionaryEntries);
        }

        [Test]
        public void GetDictionaryEntries_WhenMethodCalled_ReturnsEveryEntry()
        {
            var dictionary = _controller.GetDictionaryEntries();
            var okObjectResult = dictionary as OkObjectResult;
            var dictionaryEntries = okObjectResult.Value as IEnumerable<DictionaryEntry>;
            Assert.AreEqual(5, dictionaryEntries.ToList().Count);
        }

        [Test]
        [TestCase("English", "Hungarian")]
        [TestCase("enGliSh", "Hungarian")]
        [TestCase("Last Name", "Vezetéknév")]
        public void GetEnglishHungarianTranslation_WhenMethodCalledWithExistingWord_ReturnsCorrectEntry(string englishWord, string hungarianWord)
        {
            var okObjectResult = _controller.GetEnglishHungarianTranslation(englishWord) as OkObjectResult;
            var dictionaryEntry = okObjectResult.Value as string;
            Assert.AreEqual(hungarianWord, dictionaryEntry);

        }

        [Test]
        [TestCase("this one doesn't exist")]
        [TestCase("this one neither")]
        public void GetEnglishHungarianTranslation_WhenMethodCalledWithNonExistingWord_ReturnsNonOk(string englishWord)
        {
            var dictionaryEntry = _controller.GetEnglishHungarianTranslation(englishWord);
            Assert.IsInstanceOf<BadRequestObjectResult>(dictionaryEntry);
        }

        [Test]
        [TestCase("this one doesn't exist")]
        [TestCase("this one neither")]
        public void GetEnglishHungarianTranslation_WhenMethodCalledWithNonExistingWord_ReturnsCorrectErrorMessage(string englishWord)
        {
            var dictionaryEntry = _controller.GetEnglishHungarianTranslation(englishWord);
            var okResult = dictionaryEntry as BadRequestObjectResult;

            Assert.AreEqual($"Word not found in dictionary: {englishWord}", okResult.Value);
        }
    }
}