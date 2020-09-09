using System;
using System.Collections.Generic;
using System.Text;

namespace IC.Utils.Validadores
{
    public static class ValidadorDeTipo
    {
        public static bool EhInteiro(string value)
        {
            return int.TryParse(value, out var _ );
        }
    }
}
