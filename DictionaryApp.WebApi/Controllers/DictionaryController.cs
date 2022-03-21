using DictionaryApp.DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DictionaryController : ControllerBase
    {
        private readonly ILogger<DictionaryController> _logger;
        private readonly IDictionaryServices _dictionaryServices;

        public DictionaryController(ILogger<DictionaryController> logger, IDictionaryServices dictionaryServices)
        {
            _logger = logger;
            _dictionaryServices = dictionaryServices;
        }

        // M: Returns all the available dictionary entries.
        [HttpGet]
        public IActionResult GetDictionaryEntries()
        {
            return Ok(_dictionaryServices.GetDictionaryEntries());
        }

        // M: Returns Hungarian translation.
        [HttpGet("{englishWord}", Name = "GetEnglishHungarianTranslation")]
        public IActionResult GetEnglishHungarianTranslation(string englishWord)
        {
            var entry = _dictionaryServices.GetEnglishHungarianTranslation(englishWord);
            if (entry != default)
                return Ok(entry.Hungarian);
            return BadRequest($"Word not found in dictionary: {englishWord}");
        }
    }
}
