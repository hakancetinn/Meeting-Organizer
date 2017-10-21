using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MeetingOrganizer.Models
{
    public class Toplanti
    {
        public int Id { get; set; }

        [Display(Name = "Toplantı Konusu")]
        public string ToplantiKonusu { get; set; }

        [Display(Name = "Tarih")]
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }

        [Display(Name = "Baslangic Zamani")]
        public string Baslanngic_Zamani { get; set; }

        [Display(Name = "Bitis Zamani")]
        public string Bitis_Zamani { get; set; }

        [Display(Name = "Katilimcilar")]
        public string Katilimcilar { get; set; }
    }
}