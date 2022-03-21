using DictionaryApp.Database.Models;
using System.Collections.Generic;

namespace DictionaryApp.DataLayer
{
    public interface IDictionaryServices
    {
        List<DictionaryEntry> GetDictionaryEntries();
        DictionaryEntry GetEnglishHungarianTranslation(string wordToLookFor);
    }
}
