using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCaja.Capa_de_Negocio
{
    class Controlador
    {
        
        public bool AlgoritmoCombinacionSegura(string vr)
        {
            bool mayuscula = false;
            bool minuscula = false;
            bool numero = false;
            for (int i = 0; i < vr.Length; i++)
            {
                if (char.IsUpper(vr, i))
                {
                    mayuscula = true;
                }
                if (char.IsLower(vr, i))
                {
                    minuscula = true;
                }
                if (char.IsDigit(vr, i))
                {
                    numero = true;
                }
            }
            if (!mayuscula || !minuscula || !numero)
            {
                return false;
            }
            return true;

        }
    }
}
