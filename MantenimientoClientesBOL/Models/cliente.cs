namespace MantenimientoClientesBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bdcliente.cliente")]
    public partial class Cliente
    {
        [Key]
        public int? idcliente { get; set; }

        public Cliente()
        {
        }

        public Cliente(int? idcliente, string apellido, string nombre, string dni, string sexo, string edad, string nivelestudios, string telefono)
        {
            this.idcliente = idcliente;
            Apellido = apellido;
            Nombre = nombre;
            Dni = dni;
            Sexo = sexo;
            Edad = edad;
            Nivelestudios = nivelestudios;
            Telefono = telefono;
        }

        [Required]
        [StringLength(25)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(9)]
        public string Dni { get; set; }

        [Required]
        [StringLength(12)]
        public string Sexo { get; set; }

        [Required]
        [StringLength(2)]
        public string Edad { get; set; }

        [Required]
        [StringLength(20)]
        public string Nivelestudios { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }
    }
}
