using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GtecClinica.Web.ViewModel.Teste
{
    public class TesteCriarOuEditarVm : TesteLabelVm
    {
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}
