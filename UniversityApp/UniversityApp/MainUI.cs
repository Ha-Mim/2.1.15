using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void entryButton_Click(object sender, EventArgs e)
        {
            EntryUI aEntryUi = new EntryUI();
            aEntryUi.Show();
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            UniversityUI aUniversityUi = new UniversityUI();
            aUniversityUi.Show();
        }
    }
}
