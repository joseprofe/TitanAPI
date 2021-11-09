using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Titan.DAL.Entities
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
