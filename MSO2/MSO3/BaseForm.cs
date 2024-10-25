using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO3
{
    public partial class BaseForm : Form
    {
        const string ApplicationName = "RoboLogic";

        public BaseForm()
        {
            Text = ApplicationName;
        }
    }
}
