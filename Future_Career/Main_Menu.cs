using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Future_Career.ConnectionString;

namespace Future_Career
{
    // this is the main menu of or software, in this form, user can select a lesson and read it's theory
    public partial class Main_Menu : Form
    {
        int id = 0;
        int id_Check =0;
        bool flag = false;
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=" + ConnectionString.password + ";Database=Future_Career_DB;";
        NpgsqlConnection conn;
        string UserName;

        public Main_Menu()
        {
            InitializeComponent();
        }

        public Main_Menu(string UserNamePassed)
        {
            UserName = UserNamePassed;
            InitializeComponent();
        }

        // go to python theory section
        private void button1_Click(object sender, EventArgs e)
        {
            Python_Theory python = new Python_Theory(UserName);
            this.Hide();
            python.ShowDialog(); // Shows the next form
            this.Close(); // Closes the current form
        }

        // go to computer architecture theory section
        private void button3_Click(object sender, EventArgs e)
        {
            Computer_Architecture_Theory ca = new Computer_Architecture_Theory(UserName);
            this.Hide();
            ca.ShowDialog(); // Shows the next form
            this.Close(); // Closes the current form
        }

        // go to data structures theory section
        private void button4_Click(object sender, EventArgs e)
        {
            Data_Structures_Theory ds = new Data_Structures_Theory(UserName);
            this.Hide();
            ds.ShowDialog(); // Shows the next form
            this.Close(); // Closes the current form
        }

        // go to UI/UX design theory section
        private void button2_Click(object sender, EventArgs e)
        {
            UI_Design_Theory ui = new UI_Design_Theory(UserName);
            this.Hide();
            ui.ShowDialog(); // Shows the next form
            this.Close(); // Closes the current form
        }

        // go to data analyutics theory section
        private void button5_Click(object sender, EventArgs e)
        {
            Data_Analytics_Theory da = new Data_Analytics_Theory(UserName);
            this.Hide();
            da.ShowDialog(); // Shows the next form
            this.Close(); // Closes the current form
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            List<string> test_results = new List<string>();
            conn = new NpgsqlConnection(connectionString);
            try
            {
                // Παίρνω το ID του χρήστη και ελέγχο αν υπάρχει
                conn.Open();
                string sql = "SELECT user_id FROM User_Table WHERE username = '" + UserName + "';";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    id = (int)cmd.ExecuteScalar();


                }
                //Να δω αν υπαρχει
                string sql2 = "SELECT count(*) FROM test_grades WHERE user_id = '" + id + "';";
                using (var cmd = new NpgsqlCommand(sql2, conn))
                {
                    id_Check = Convert.ToInt32(cmd.ExecuteScalar());
                }
                //Αν δεν έχει δόσει ποτέ κανένα τεστ, δεν υπάρχει δηλαδή το ID τότε όλα 0
                if (id_Check == 0)
                {
                    progressBar1.Value = 0;
                    progressBar2.Value = 0;
                    progressBar3.Value = 0;
                    progressBar4.Value = 0;
                    progressBar5.Value = 0;
                    flag = false;
                }
                else
                {
                    //Αν έχει δόσει έστω 1 τεστ τότε κάνουμε σελεκτ στο πίνακα των αποτελεσμάτων με το ID του
                    NpgsqlCommand comm = new NpgsqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "select da,ca,py,ui,ds from test_grades where user_id = '" + id + "'";
                    NpgsqlDataReader result = comm.ExecuteReader();
                    while (result.Read())
                    {
                        //  str.Add(result.GetValue(0).ToString());
                        //Data analytics
                        test_results.Add(result.GetValue(0).ToString());
                        //Comp.Arch
                        test_results.Add(result.GetValue(1).ToString());
                        //Python
                        test_results.Add(result.GetValue(2).ToString());
                        //Ui/Ux Design
                        test_results.Add(result.GetValue(3).ToString());
                        //Data Base
                        test_results.Add(result.GetValue(4).ToString());
                    }
                    //Data analytics
                    if (string.IsNullOrEmpty(test_results[0]))
                    {
                        progressBar3.Value = 0;
                        flag = false;
                    }
                    else 
                    {
                        progressBar3.Value = Convert.ToInt32(test_results[0]);
                        flag = true;
                    }
                    //Comp.Arch
                    if (string.IsNullOrEmpty(test_results[1]))
                    {
                        progressBar4.Value = 0;
                        flag = false;
                    }
                    else
                    {
                        progressBar4.Value = Convert.ToInt32(test_results[1]);
                        flag = true;
                    }
                    //Python
                    if (string.IsNullOrEmpty(test_results[2]))
                    {
                        progressBar1.Value = 0;
                        flag = false;
                    }
                    else
                    {
                        progressBar1.Value = Convert.ToInt32(test_results[2]);
                        flag = true;
                    }
                    //Ui/Ux Design
                    if (string.IsNullOrEmpty(test_results[3]))
                    {
                        progressBar2.Value = 0;
                        flag = false;
                    }
                    else
                    {
                        progressBar2.Value = Convert.ToInt32(test_results[3]);
                        flag = true;
                    }
                    //Data Base
                    if (string.IsNullOrEmpty(test_results[4]))
                    {
                        progressBar5.Value = 0;
                        flag = false;
                    }
                    else
                    {
                        progressBar5.Value = Convert.ToInt32(test_results[4]);
                        flag = true;
                    }

                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally 
            {
                conn.Close();
            }
            //Λάμπελς ένδειξης ποσοτού ολοκλήρωσης
            label10.Text = progressBar1.Value.ToString() +"%";
            label9.Text = progressBar2.Value.ToString() + "%";
            label11.Text = progressBar3.Value.ToString() + "%";
            label12.Text = progressBar4.Value.ToString() + "%";
            label13.Text = progressBar5.Value.ToString() + "%";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Επιλέξτε ένα από τα 5 διαθέσιμα μαθήματα. Για κάθε ένα μάθημα που θα διαλέξετε, διαβάστε την θεωρία που δίνεται και ύστερα ολοκληρώστε το μικρό quiz που απορρέει από την θεωρία. Καλή τύχη!");
        }

        // πήγαινε στην φόρμα με τα αποτελέσματα
        private void button7_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                if ((progressBar1.Value > 0) & (progressBar2.Value > 0) & (progressBar3.Value > 0) & (progressBar4.Value > 0) & (progressBar5.Value > 0))
                {
                    string best = "";

                    // find the max mark (progress)
                    int maxNumber = Math.Max(progressBar1.Value, Math.Max(progressBar2.Value, Math.Max(progressBar3.Value, Math.Max(progressBar4.Value, progressBar5.Value))));

                    if (progressBar1.Value >= maxNumber) 
                    {
                        maxNumber = progressBar1.Value;
                        best = String.Concat(best, " Python");
                    }

                    if (progressBar2.Value >= maxNumber)
                    {
                        maxNumber = progressBar2.Value;
                        best = String.Concat(best, " UI/UX");
                    }

                    if (progressBar3.Value >= maxNumber) 
                    {
                        maxNumber = progressBar3.Value;
                        best = String.Concat(best, " Data_Analytics");
                    }

                    if (progressBar4.Value >= maxNumber) 
                    {
                        maxNumber = progressBar4.Value;
                        best = String.Concat(best, " Computer_Architecture");
                    }

                    if (progressBar5.Value >= maxNumber)
                    {
                        maxNumber = progressBar5.Value;
                        best = String.Concat(best, " Data_Structures");
                    }

                    Results re = new Results(best,UserName);
                    this.Hide();
                    re.ShowDialog(); // Shows the next form
                    this.Close(); // Closes the current form
                }
                else
                {
                    MessageBox.Show("Για να σας παρέχουμε αποτελέσματα, θα πρέπει να έχετε σημέιώσει ποσοστό επιτυχίας πάνω από 0% σε όλα τα τεστ!");
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ ολοκήρώστε όλα τα μαθήματα, για να σας παρέχουμε τα αποτελέσματα.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Επιστροφή στο Login 
            Login log = new Login();
            this.Hide(); // Hides the current form
            log.ShowDialog(); // Shows the next form
        }
    }
}
