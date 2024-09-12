using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using AxAcroPDFLib;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Future_Career
{
    public partial class Python_Theory : Form
    {
        string UserName;
        public Python_Theory(string UserNamePassed)
        {
            UserName = UserNamePassed;
            InitializeComponent();
        }

        // go to python test page
        private void button1_Click(object sender, EventArgs e)
        {
            Python_Test pat = new Python_Test(UserName);
            pat.ShowDialog(); // Shows the next form
        }

        private void Python_Theory_Load(object sender, EventArgs e)
        {
           
            axAcroPDF1.src = Path.GetFullPath("Py.pdf");         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Επιστροφή στο αρχικό μενού
            Main_Menu obj = new Main_Menu(UserName);
            this.Hide(); // Hides the current form
            obj.ShowDialog(); // Shows the next form
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Μελετήστε την θεωρία. Ύστερα, σας δίνεται η δυνατότητα να δοκιμάσετε τις γνώσεις" +
                "σας σε ένα τεστ πάνω σε όλη την ύλη.");
        }
    }
}
