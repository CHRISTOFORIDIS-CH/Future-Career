using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Future_Career
{
    public partial class Results : Form
    {
        String UserName;
        public Results(string best,string UserNamePassed)
        {
            InitializeComponent();

            UserName = UserNamePassed;

            string[] b_lessons = best.Split(' ');

            string text1 = "", text2 = "", text3 = "", text4= "", text5 = "";

            foreach (string item in b_lessons)
            {
                if (item.Equals("Python"))
                {
                     text1 = "Εφόσον είστε καλός στην Python, μπορείτε να κάνετε ένα από τα επόμενα επαγγέλματα:"+
                        "Software Developer/Engineer, Data Scientist, Python Backend Developer και Cybersecurity Professional."+ Environment.NewLine;
                }

                if (item.Equals("UI/UX"))
                {
                    text2 = "Εφόσον είστε καλός στον σχεδιασμό προγραμμάτων, μπορείτε να κάνετε ένα από τα επόμενα επαγγέλματα:" +
                    "UI/UX Designer, UX Researcher, Information Architect, Visual Designer, UI Developer/Front-end Developer και Usability Analyst." + Environment.NewLine;
                }

                if (item.Equals("Data_Analytics"))
                {
                    text3 = "Εφόσον είστε καλός στην ανάλυση δεδομένων, μπορείτε να κάνετε ένα από τα επόμενα επαγγέλματα:" +
                        "Data AnAlyst, Data Engineer, Data Architect, Data Visualization Specialist, Market Research Analyst και Data Scientist." + Environment.NewLine;
                }

                if (item.Equals("Computer_Architecture"))
                {
                     text4 = "Εφόσον είστε καλός στην σχεδίαση υλικού υπολογιστών, μπορείτε να κάνετε ένα από τα επόμενα επαγγέλματα:" +
                        "Computer Architect, Performance Engineer, Verification Engineer και Embedded Systems Engineer." + Environment.NewLine;
                }

                if (item.Equals("Data_Structures"))
                {
                     text5 = "Εφόσον είστε καλός στις βάσεις δεδομένων, μπορείτε να κάνετε ένα από τα επόμενα επαγγέλματα:" +
                        "Data Engineer, Data Scientist, Database Administrator, Systems Engineer, Data Analyst και Data Architect." + Environment.NewLine;
                }
            }

            // show the results in a rich text box
            richTextBox1.Text = text1 + Environment.NewLine + text2 + Environment.NewLine + text3 + Environment.NewLine + text4 + Environment.NewLine+ text5;

        }

        // κουμπί για βοήθεια
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Στο παράθυρο αυτό μπορείτε να δείτε ενδεικτικά επαγγέλματα που αφορούν στον κλάδο που κατέχετε καλύτερα!");
        }

        // επιστροφή στο αρχικό μενού
        private void button1_Click(object sender, EventArgs e)
        {
            //Επιστροφή στο αρχικό μενού
            Main_Menu obj = new Main_Menu();
            this.Hide(); // Hides the current form
            obj.ShowDialog(); // Shows the next form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Επιστροφή στο Login 
            Login log = new Login();
            this.Hide(); // Hides the current form
            log.ShowDialog(); // Shows the next form
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //επιστροφή στο αρχικό μενού
            Main_Menu obj = new Main_Menu(UserName);
            this.Hide();
            obj.ShowDialog();
            
        }
    }
}
