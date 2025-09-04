﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDespensa25.Shared.DTO
{
    public class CrearUsuarioDTO
    {
        [Required(ErrorMessage = "El Nombre Usuario es obligatorio")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La Clave es obligatorio")]
        [MaxLength(8, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Clave { get; set; }
    }
}
