using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace MSO3
{
    [ExcludeFromCodeCoverage]
    public partial class BaseForm : Form
    {
        const string ApplicationName = "RoboLogic";

        public BaseForm()
        {
            Text = ApplicationName;
        }
    }
}
