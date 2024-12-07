using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Utils
{
    public class MyValidator
    {
        public bool ValidateZone(string input)
        {
            // Verifica si el texto es nulo o está vacío
            if (string.IsNullOrEmpty(input))
                return false;

            // Verifica si la longitud está entre 4 y 15 caracteres
            if (input.Length < 4 || input.Length > 15)
                return false;

            // Verifica que no tenga caracteres especiales (solo letras y números permitidos)
            // Expresión regular para validar que solo tenga letras y números para un rango de 4 a 15 caracteres, debe permitir las vocales con tilde
            string pattern = @"^[a-zA-Z0-9áéíóúÁÉÍÓÚ]{4,15}$";
            if (!Regex.IsMatch(input, pattern))
                return false;

            return true;
        }
    }
}
