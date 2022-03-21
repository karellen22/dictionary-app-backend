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

        public DictionaryEntry GetEnglishHungarianTranslation(string wordToLookFor)
        {
            return _context.DictionaryEntries.First(entry => entry.English.ToLower() == wordToLookFor.ToLower());
        }
    }
}
