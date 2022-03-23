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
        [TestCase("English", "Hungarian", "English", "Hungarian")]
        [TestCase("English", "Hungarian", "enGliSh", "Hungarian")]
        [TestCase("English", "Hungarian", "Last Name", "Vezetéknév")]
        public void GetTranslation_WhenMethodCalledWithExistingWord_ReturnsCorrectEnglishHungarianTranslation(string fromLanguage, string toLanguage, string phrase, string hungarianWord)
        {
            var okObjectResult = _controller.GetTranslation(fromLanguage, toLanguage, phrase) as OkObjectResult;
            var dictionaryEntry = okObjectResult.Value as string;
            Assert.AreEqual(hungarianWord, dictionaryEntry);

        }

        [Test]
        [TestCase("English", "Hungarian", "this one doesn't exist")]
        [TestCase("English", "Hungarian", "this one neither")]
        public void GetTranslation_WhenMethodCalledWithNonExistingWord_ReturnsNotFound(string fromLanguage, string toLanguage, string phrase)
        {
            var dictionaryEntry = _controller.GetTranslation(fromLanguage, toLanguage, phrase);
            Assert.IsInstanceOf<NotFoundObjectResult>(dictionaryEntry);
        }

        [Test]
        [TestCase("English", "Hungarian", "this one doesn't exist")]
        [TestCase("English", "Hungarian", "this one neither")]
        public void GetTranslation_WhenMethodCalledWithNonExistingWord_ReturnsCorrectErrorMessage(string fromLanguage, string toLanguage, string phrase)
        {
            var dictionaryEntry = _controller.GetTranslation(fromLanguage, toLanguage, phrase);
            var notFound = dictionaryEntry as NotFoundObjectResult;

            Assert.AreEqual($"Word or phrase not found in dictionary: {phrase}", notFound.Value);
        }
    }
}