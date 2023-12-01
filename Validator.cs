using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrackEZ
{
    internal class Validator
    {
        public static bool ValidateTextBox(TextBox textBox, int key)
        {
            string lettersPattern = @"^[a-zA-Zа-яА-ЯіІїЇґҐ]+$";
            string numbersPattern = @"^-?\d+([.,]\d+)?$";

            string inputText = textBox.Text.Trim();

            if (key == 1) // Перевірка на букви
            {
                if (Regex.IsMatch(inputText, lettersPattern))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (key == 2) // Перевірка на числа
            {  

                if (Regex.IsMatch(inputText, numbersPattern))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
        
    

