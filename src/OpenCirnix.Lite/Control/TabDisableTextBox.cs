using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCirnix.Lite
{
    public class TabDisableTextBox : TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Tab) return true;

            return base.IsInputKey(keyData);
        }
    }
}
