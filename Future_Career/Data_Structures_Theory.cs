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
    public partial class Data_Structures_Theory : Form
    {
        string UserName;
        public Data_Structures_Theory(string UserNamePassed)
        {
            UserName = UserNamePassed;
            InitializeComponent();
        }

        // go to data structures test page
        private void button1_Click(object sender, EventArgs e)
        {
            Data_Structures_Test dst = new Data_Structures_Test(UserName);
            dst.ShowDialog(); // Shows the next form
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Επιστροφή στο αρχικό μενού
            Main_Menu obj = new Main_Menu(UserName);
            this.Hide(); // Hides the current form
            obj.ShowDialog(); // Shows the next form
        }

        private void Data_Structures_Theory_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = Path.GetFullPath("data_structures.pdf"); // προβολή της θεωρίας
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Μελετήστε την θεωρία. Ύστερα, σας δίνεται η δυνατότητα να δοκιμάσετε τις γνώσεις" +
                "σας σε ένα τεστ πάνω σε όλη την ύλη.");
        }
    }
}
