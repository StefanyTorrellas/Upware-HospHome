using System;
using System.ComponentModel.DataAnnotations;

namespace VetPet.App.Dominio
{
    public class Persona 
    {
        public int id {get; set;}
        [Required(ErrorMessage="La cedula es requerida"),Range(0,int.MaxValue,ErrorMessage="La cedula debe ser mayor que 0")]
	public int cedula {get; set;}
        public string nombre {get; set;}
	public string apellido {get; set;}
        [Required(ErrorMessage="El nombre es requerido"),Range(0,150,ErrorMessage="La edad debe estar entre 0 y 150")]
	public int edad {get; set;}
        public Genero genero {get; set;}
    }
}
