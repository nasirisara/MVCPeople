using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPeople.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        
        [Required]
        [StringLength(80, MinimumLength = 1)]
        [Display(Name = "Language name")]
        public string LanguageName { get; set; }
    }
}
