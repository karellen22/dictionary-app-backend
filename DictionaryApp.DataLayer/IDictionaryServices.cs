using DictionaryApp.Database.Models;
using System.Collections.Generic;

namespace DictionaryApp.DataLayer
{
    public interface IDictionaryServices
    {
        List<DictionaryEntry> GetDictionaryEntries();
        string GetTranslation(string fromLanguage, string toLanguage, string wordToLookFor);
    }
}
