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
    public partial class Computer_Architecture_Theory : Form
    {
        string UserName;
        public Computer_Architecture_Theory(string UserNamePassed)
        {
            UserName = UserNamePassed;
            InitializeComponent();
        }

        // go to computer architecture test
        private void button1_Click(object sender, EventArgs e)
        {
            Computer_Architecture_Test cat = new Computer_Architecture_Test(UserName);
            cat.ShowDialog(); // Shows the next form
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Επιστροφή στο αρχικό μενού
            Main_Menu obj = new Main_Menu(UserName);
            this.Hide(); // Hides the current form
            obj.ShowDialog(); // Shows the next form
        }

        private void Computer_Architecture_Theory_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = Path.GetFullPath("computer_architecture_theory.pdf"); // προβολή της θεωρίας
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Μελετήστε την θεωρία. Ύστερα, σας δίνεται η δυνατότητα να δοκιμάσετε τις γνώσεις" +
                "σας σε ένα τεστ πάνω σε όλη την ύλη.");
        }
    }
}
