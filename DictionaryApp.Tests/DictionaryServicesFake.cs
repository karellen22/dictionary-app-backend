using DictionaryApp.Database.Models;
using DictionaryApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryApp.Tests
{
    internal class DictionaryServicesFake : IDictionaryServices
    {
        private readonly List<DictionaryEntry> _dictionary;
        public DictionaryServicesFake()
        {
            _dictionary = new List<DictionaryEntry>()
            {
                new DictionaryEntry { Guid = Guid.Parse("fed5e007-b9cb-408e-b3df-00b6b5c1d78f"), English = "English", Hungarian = "Hungarian", Spanish = "Spanish", Chinese = "Chinese", Portugese = "Portugese" },
                new DictionaryEntry { Guid = Guid.Parse("838f049d-8570-4092-9292-4cbc949be4d2"), English = "Agency", Hungarian = "Ügynökség", Spanish = "Agencia", Chinese = "机构", Portugese = "Agência" },
                new DictionaryEntry { Guid = Guid.Parse("8c58b65a-154e-4406-9766-5e1e91e62597"), English = "Comment", Hungarian = "Megjegyzés", Spanish = "Comentario", Chinese = "备注", Portugese = "Comentário" },
                new DictionaryEntry { Guid = Guid.Parse("1fa67e0d-dd48-4797-9b10-6bb474d0c0dc"), English = "Comment:", Hungarian = "Megjegyzés:", Spanish = "Comentario:", Chinese = "备注：", Portugese = "Comentário:" },
                new DictionaryEntry { Guid = Guid.Parse("cbddc998-abbb-498e-b4c2-8619f5665d5d"), English = "Last Name", Hungarian = "Vezetéknév", Spanish = "Apellido", Chinese = "姓氏", Portugese = "Sobrenome" }
            };
        }

        public List<DictionaryEntry> GetDictionaryEntries()
        {
            return _dictionary;
        }

        public DictionaryEntry GetTranslation(string wordToLookFor)
        {
            return _dictionary.FirstOrDefault(entry => entry.English.ToLower() == wordToLookFor.ToLower());
        }

        public string GetTranslation(string fromLanguage, string toLanguage, string phrase)
        {
            var dictionaryEntry = new DictionaryEntry();

            switch (fromLanguage)
            {
                case "English":
                    dictionaryEntry = _dictionary.FirstOrDefault(entry => entry.English.ToLower() == phrase.ToLower());
                    break;
                case "Hungarian":
                    dictionaryEntry = _dictionary.FirstOrDefault(entry => entry.Hungarian.ToLower() == phrase.ToLower());
                    break;
                case "Spanish":
                    dictionaryEntry = _dictionary.FirstOrDefault(entry => entry.Spanish.ToLower() == phrase.ToLower());
                    break;
                case "Chinese":
                    dictionaryEntry = _dictionary.FirstOrDefault(entry => entry.Chinese.ToLower() == phrase.ToLower());
                    break;
                case "Portugese":
                    dictionaryEntry = _dictionary.FirstOrDefault(entry => entry.Portugese.ToLower() == phrase.ToLower());
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
