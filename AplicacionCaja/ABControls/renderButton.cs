using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionCaja.ABControls
{
    class renderButton
    {
        public Button CrearBoton()
        {
            Button newButton = new Button();
            newButton.BackColor = Color.FromArgb(235, 59, 69);
            newButton.Size = new Size(253, 65);
            newButton.ForeColor = Color.WhiteSmoke;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.Font = new Font("Microsoft Sans Serif", 20 ,FontStyle.Regular);
            newButton.FlatAppearance.BorderSize = 0;
            return newButton;

        }
    }
}
