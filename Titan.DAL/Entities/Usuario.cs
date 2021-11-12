using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Titan.DAL.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        
        public int ProvinciaId { get; set; }

        [ForeignKey("ProvinciaId")]
        public Provincia Provincia { get; set; }
    }
}
