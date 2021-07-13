using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GtecClinica.Web.ViewModel.Comum
{
    public class ComumLabelVm
    {
        [Display(Name = "Consultar")]
        public string LblBotaoConsultar { get; set; }

        [Display(Name = "Salvar")]
        public string LblBotaoSalvar { get; set; }

        [Display(Name = "Cancelar")]
        public string LblBotaoCancelar { get; set; }
    }
}
