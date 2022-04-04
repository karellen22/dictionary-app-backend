using DictionaryApp.Database.Models;
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
            try
            {
                _logger.Log(LogLevel.Information, "GetDictionaryEntries was called");
                return Ok(_dictionaryServices.GetDictionaryEntries());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(); 
            }
        }

        // M: Returns single dictionary entry.
        [HttpGet("entry")]
        public IActionResult GetDictionaryEntry(string guid)
        {
            try
            {
                _logger.Log(LogLevel.Information, "GetDictionaryEntry was called with guid: {0}.", guid);
                return Ok(_dictionaryServices.GetDictionaryEntry(guid));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem();
            }
        }

        // M: Put single dictionary entry.
        [HttpPut("entry")]
        public IActionResult PutDictionaryEntry(DictionaryEntry dictionaryEntry)
        {
            try
            {
                _logger.Log(LogLevel.Information, "PutDictionaryEntry was called with parameters: {0}", dictionaryEntry.ToString());
                return Ok(_dictionaryServices.EditDictionaryEntry(dictionaryEntry));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem();
            }
        }

        // M: Post new dictionary entry.
        [HttpPost("entry")]
        public IActionResult PostDictionaryEntry(DictionaryEntry dictionaryEntry)
        {
            try
            {
                _logger.Log(LogLevel.Information, "PostDictionaryEntry was called with parameters: {0}", dictionaryEntry.ToString());
                return Ok(_dictionaryServices.PostDictionaryEntry(dictionaryEntry));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem();
            }
        }

        // M: Returns translation.
        [HttpGet("{fromLanguage}/{toLanguage}/{phrase}", Name = "GetTranslation")]
        public IActionResult GetTranslation(string fromLanguage, string toLanguage, string phrase)
        {
            try
            {
                _logger.Log(LogLevel.Information, "GetTranslation was called with parameters: {0}, {1}, {2}", fromLanguage, toLanguage, phrase);
                var entry = _dictionaryServices.GetTranslation(fromLanguage, toLanguage, phrase);
                if (entry != default)
                    return Ok(entry);
                return NotFound($"Word or phrase not found in dictionary: {phrase}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem();
            }
        }
    }
}
