using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrador_2
{
    public partial class SoloDNI : TextBox
    {
        public Boolean Validar()
        {
            //return Regex.IsMatch(base.Text, @"^[0-9]{8}$");
            return true;
        }
    }
}
