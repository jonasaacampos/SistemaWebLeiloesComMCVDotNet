using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcAuction.Models
{
    public class Lance
    {
        public long Id { get; internal set; }

        public long LeilaoId { get; set; }

        public DateTime LogDataHora { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Valor { get; set; }

        public Lance()
        {
            LogDataHora = DateTime.Now;
        }


        public string UsuarioNome { get; set; }
    }
}