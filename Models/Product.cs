using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootCamp.ApiSpfx.Models
{
    public class Product
    {
        public Product(string _title, string _model, string _ano)
        {
            this.Title = _title;
            this.Model = _model;
            this.Ano = _ano;
        }

        public string Title { get; set; }
        public string Model { get; set; }
        public string Ano { get; set; }


    }
}