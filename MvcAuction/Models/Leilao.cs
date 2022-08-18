using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAuction.Models
{
    public class Leilao
    {
        public long Id { get; set; }
        public string NomeLeilao { get; set; }
        public string Descricao { get; set; }
        public string ImageUrl { get; set; }

        public DateTime TimeStarts { get; set; }
        public DateTime TimeEnds { get; set; }

        public decimal PrecoInicial { get; set; }
        public decimal? PrecoAtual { get; set; }
        

    }
}