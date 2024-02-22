using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.TERMINAL.Forms
{
    public partial class CustomMonthCalendar : Form
    {
        public CustomMonthCalendar()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = e.Start.ToLongDateString();
            textBox1.Text = monthCalendar1.SelectionStart.ToLongDateString();
        }
    }
}
