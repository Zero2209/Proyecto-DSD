using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarikeRest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public int Estado { get; set; }
    }
}