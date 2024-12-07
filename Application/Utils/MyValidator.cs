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
        // Patrón para validar correos electrónicos
        private static readonly string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private static readonly Regex EmailRegex = new Regex(EmailPattern, RegexOptions.Compiled);

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



        /// <summary>
        /// Valida si un texto cumple con el formato de un correo electrónico.
        /// </summary>
        /// <param name="email">Texto a validar.</param>
        /// <returns>true si el texto es un correo electrónico válido; de lo contrario, false.</returns>
        public bool IsValidEmail(string email)
        {

            if (string.IsNullOrWhiteSpace(email))
            {
                return false; // Retorna false si el texto está vacío o es nulo
            }

            return EmailRegex.IsMatch(email); // Valida el texto contra el patrón
        }
    }
}
