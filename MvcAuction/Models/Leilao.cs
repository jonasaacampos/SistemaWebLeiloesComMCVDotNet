using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAuction.Models
{
    public class Leilao
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CategoriaItens { get; set; }

        [Required]
        [Display(Name = "Nome do Leilão")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, MinimumLength = 5)]  //pq inverter dá ruim?
        public string NomeLeilao { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="Data de Início")]
        public DateTime TimeStarts { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Encerramento")]
        public DateTime TimeEnds { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Preço inicial")]
        public decimal PrecoInicial { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor último lance")]
        public decimal? PrecoAtual { get; set; }

        public virtual Collection<Lance> Lances { get; private set; }

        public int LanceContador
        {
            get { return Lances.Count; }
        }

        public Leilao()
        {
            Lances = new Collection<Lance>();
        }



    }
}