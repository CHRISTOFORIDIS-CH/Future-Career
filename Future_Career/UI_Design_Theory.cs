using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Future_Career
{
    public partial class UI_Design_Theory : Form
    {
        string UserName;
        public UI_Design_Theory(string UserNamePassed)
        {
            UserName = UserNamePassed;
            InitializeComponent();
        }

        // go to ui/ux test page
        private void button1_Click(object sender, EventArgs e)
        {
            UI_test uit = new UI_test(UserName);
            uit.ShowDialog(); // Shows the next form
        }

        private void UI_Design_Theory_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = Path.GetFullPath("ui-ux.pdf"); // προβολή της θεωρίας
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
