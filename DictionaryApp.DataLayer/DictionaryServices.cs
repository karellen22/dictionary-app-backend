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

        public DictionaryEntry EditDictionaryEntry(DictionaryEntry dictionaryEntry)
        {
            var entryToEdit = _context.DictionaryEntries.FirstOrDefault(x => x.Guid == dictionaryEntry.Guid);
            if (entryToEdit == default)
                return null;

            entryToEdit.English = dictionaryEntry.English;
            entryToEdit.Hungarian = dictionaryEntry.Hungarian;
            entryToEdit.Spanish = dictionaryEntry.Spanish;
            entryToEdit.Chinese = dictionaryEntry.Chinese;
            entryToEdit.Portugese = dictionaryEntry.Portugese;

            _context.SaveChanges();

            return entryToEdit;
        }

        public List<DictionaryEntry> GetDictionaryEntries()
        {
            return _context.DictionaryEntries.ToList();
        }

        public DictionaryEntry GetDictionaryEntry(string guid)
        {
            return _context.DictionaryEntries.FirstOrDefault(x => x.Guid.ToString() == guid);
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

            return toLanguage switch
            {
                "English" => dictionaryEntry.English,
                "Hungarian" => dictionaryEntry.Hungarian,
                "Spanish" => dictionaryEntry.Spanish,
                "Chinese" => dictionaryEntry.Chinese,
                "Portugese" => dictionaryEntry.Portugese,
                _ => default,
            };
        }

        public DictionaryEntry PostDictionaryEntry(DictionaryEntry dictionaryEntry)
        {
            dictionaryEntry.Guid = Guid.NewGuid();
            _context.DictionaryEntries.Add(dictionaryEntry);
            _context.SaveChanges();

            return dictionaryEntry;
        }
    }
}
