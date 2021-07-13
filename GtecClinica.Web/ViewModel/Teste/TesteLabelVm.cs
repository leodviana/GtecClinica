using GtecClinica.Web.ViewModel.Comum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GtecClinica.Web.ViewModel.Teste
{
    public class TesteLabelVm : ComumLabelVm
    {
        [Display(Name = "Consulta Teste")]
        public string LblTituloConsulta { get; set; }

        [Display(Name = "Manutenção Teste")]
        public string LblTituloCriacaoEdicao { get; set; }

        [Display(Name = "ID")]
        public string LblId { get; set; }

        [Display(Name = "Nome")]
        public string LblNome { get; set; }
    }
}
