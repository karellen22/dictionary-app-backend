using DictionaryApp.Database.Models;
using System.Collections.Generic;

namespace DictionaryApp.DataLayer
{
    public interface IDictionaryServices
    {
        List<DictionaryEntry> GetDictionaryEntries();
        DictionaryEntry GetDictionaryEntry(string guid);
        DictionaryEntry PostDictionaryEntry(DictionaryEntry dictionaryEntry);
        DictionaryEntry EditDictionaryEntry(DictionaryEntry dictionaryEntry);

        string GetTranslation(string fromLanguage, string toLanguage, string wordToLookFor);
    }
}
