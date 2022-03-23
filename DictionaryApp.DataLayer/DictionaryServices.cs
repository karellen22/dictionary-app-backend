using DictionaryApp.Database;
using DictionaryApp.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryApp.DataLayer
{
    public class DictionaryServices : IDictionaryServices
    {
        private readonly AppDbContext _context;

        public DictionaryServices(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public List<DictionaryEntry> GetDictionaryEntries()
        {
            return _context.DictionaryEntries.ToList();
        }

        public string GetTranslation(string fromLanguage, string toLanguage, string phrase)
        {
            var dictionaryEntry = new DictionaryEntry();

            switch (fromLanguage)
            {
                case "English":
                    dictionaryEntry = _context.DictionaryEntries.FirstOrDefault(entry => entry.English.ToLower() == phrase.ToLower());
                    break;
                case "Hungarian":
                    dictionaryEntry = _context.DictionaryEntries.FirstOrDefault(entry => entry.Hungarian.ToLower() == phrase.ToLower());
                    break;
                case "Spanish":
                    dictionaryEntry = _context.DictionaryEntries.FirstOrDefault(entry => entry.Spanish.ToLower() == phrase.ToLower());
                    break;
                case "Chinese":
                    dictionaryEntry = _context.DictionaryEntries.FirstOrDefault(entry => entry.Chinese.ToLower() == phrase.ToLower());
                    break;
                case "Portugese":
                    dictionaryEntry = _context.DictionaryEntries.FirstOrDefault(entry => entry.Portugese.ToLower() == phrase.ToLower());
                    break;
                default:
                    break;
            }

            if (dictionaryEntry == default)
                return default;

            switch (toLanguage)
            {
                case "English":
                    return dictionaryEntry.English;
                case "Hungarian":
                    return dictionaryEntry.Hungarian;
                case "Spanish":
                    return dictionaryEntry.Spanish;
                case "Chinese":
                    return dictionaryEntry.Chinese;
                case "Portugese":
                    return dictionaryEntry.Portugese;
                default:
                    return default;
            }
        }
    }
}
