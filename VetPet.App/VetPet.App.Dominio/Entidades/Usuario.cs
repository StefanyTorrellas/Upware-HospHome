using System;
using System.ComponentModel.DataAnnotations;

namespace VetPet.App.Dominio 
{
    public class Usuario
    {
        public int id {get; set;}
        [Required(ErrorMessage = "El nombre de usuario es requerido."),RegularExpression(@"^\S*$", ErrorMessage = "No se permiten espacios")]
	public string username {get; set;}
        [Required(ErrorMessage = "El email es requerido."),EmailAddress(ErrorMessage = "El dato debe ser un email")]
        public string email {get; set;}
        [Required(ErrorMessage = "La contraseña es requerida."),DataType(DataType.Password),StringLength(100,MinimumLength=6,ErrorMessage="La contraseña debe tener mínimo 6 carácteres")]
        public string password {get; set;}
    }
}
