using System;
using System.ComponentModel.DataAnnotations;

namespace DictionaryApp.Database.Models
{
    public class DictionaryEntry
    {
        [Key]
        public Guid Guid { get; set; }
        public string English { get; set; }
        public string Hungarian { get; set; }
        public string Spanish { get; set; }
        public string Chinese { get; set; }
        public string Portugese { get; set; }
    }
}
