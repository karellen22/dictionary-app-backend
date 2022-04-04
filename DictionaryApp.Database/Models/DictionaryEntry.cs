using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DictionaryApp.Database.Models
{
    public class DictionaryEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Guid { get; set; }
        public string English { get; set; }
        public string Hungarian { get; set; }
        public string Spanish { get; set; }
        public string Chinese { get; set; }
        public string Portugese { get; set; }
        public override string ToString()
        {
            return $"Guid: {Guid}, English: {English}, Hungarian: {Hungarian}, Spanish: {Spanish}, Chinese: {Chinese}, Portugese: {Portugese}";
        }
    }
}
