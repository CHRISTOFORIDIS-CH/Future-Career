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

namespace Future_Career
{
    public partial class Data_Analytics_Test : Form
    {
        //Για το insert στη βαση
        int id_Check = 0;
        string UserName;
        int id = 0;
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=" + ConnectionString.password + ";Database=Future_Career_DB;";
        NpgsqlConnection conn;
        // για το quiz  
        int QuestionNum;
        int correctAnswer;
        int score;
        int percentage;
        int TotalQuestions;
        public Data_Analytics_Test(string UserNamePassed)
        {
            UserName = UserNamePassed;
            InitializeComponent();
        }
        private void checkAnswerEvent(object sender, EventArgs e)
        {
            //κάθε φορα που κλικάρω κουμπί θα ενεργοποιείται αυτό το event
            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);
            if (buttonTag == correctAnswer)
            {
                score++;
            }
            if (QuestionNum == TotalQuestions)
            {
                //Υπολογίζω ποσοστό στο τέλος
                percentage = (int)Math.Round((double)(score * 100) / TotalQuestions);
                //Προσθήκη στη βάση (ποσοστού στα 100)
                //GET THE USERS ID FOR FK IN Test_Grades
                try
                {
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

                    //αν υπάρχει κανε UPDATE αλλιως κανε INSERT
                    NpgsqlCommand comm = new NpgsqlCommand(); //INSERT COMMAND
                    NpgsqlCommand comm2 = new NpgsqlCommand(); //UPDATE COMMAND
                    comm.Connection = conn;
                    comm2.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm2.CommandType = CommandType.Text;
                    comm.CommandText = "INSERT INTO test_grades (user_id,da) VALUES(@USER_ID,  @DATAANAL)";
                    comm.Parameters.AddWithValue("@USER_ID", id);
                    comm.Parameters.AddWithValue("@DATAANAL", percentage);
                    comm2.CommandText = "UPDATE test_grades SET da = '" + percentage + "' WHERE user_id = '" + id + "';";

                    if (id_Check == 0)
                    {
                        //Αν δεν υπάρχει εγγραφή
                        comm.ExecuteScalar();
                    }
                    else
                    {
                        //Αν υπάρχει κάνω ενημέρωση
                        comm2.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    MessageBox.Show("Πρόβλημα με τη βάση!");
                }
                finally
                {
                    conn.Close();
                }
                //Τέλος Τεστ
                MessageBox.Show("Το Quiz ολοκληρώθηκε. Τα αποτελέσματά σας έχουν αποθηκευτεί!" + Environment.NewLine
                    + "To ποσοστό επιτυχίας σας είναι: " + percentage.ToString() + "%" + Environment.NewLine +
                    "Πατήστε οκ για να γυρίσετε πίσω στην θεωρία");
                
                //γυρνάω πίσω στη θεωρία
                this.Close();

            }
            QuestionNum++;
            askQuestion(QuestionNum);
        }
        private void askQuestion(int QestionNum)
        {
            switch (QestionNum)
            {
                case 1:
                    richTextBox1.Text = "Ποια από τις ακόλουθες γλώσσες χρησιμοποιείται στην επιστήμη των δεδομένων;" + Environment.NewLine +
                        "1) Java" + Environment.NewLine +
                        "2) C" + Environment.NewLine +
                        "3) C++" + Environment.NewLine +
                        "4) Python";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 4;
                    break;
                case 2:
                    richTextBox1.Text = "Ποια από τα παρακάτω είναι πηγές δεδομένων στην επιστήμη των δεδομένων;" + Environment.NewLine+
                        "1) Structured" + Environment.NewLine +
                        "2) UnStructured" + Environment.NewLine +
                        "3) και το 1) και το 2) " + Environment.NewLine +
                        "4) κανένα από τα παραπάνω";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 3;
                    break;
                case 3:
                    richTextBox1.Text = "Ποιο/α από τα ακόλουθα είναι το σωστό/ά συστατικό/ά για την επιστήμη των δεδομένων;" + Environment.NewLine +
                        "1) Domain expertise" + Environment.NewLine +
                        "2) Data Engineering" + Environment.NewLine +
                        "3) Advanced Computing " + Environment.NewLine +
                        "4) Όλα τα παραπάνω ";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 4;
                    break;
                case 4:
                    richTextBox1.Text = "Ποια από τις ακόλουθες είναι μια από τις βασικές δεξιότητες της επιστήμης των δεδομένων;" + Environment.NewLine +
                       "1) Statistics" + Environment.NewLine +
                       "2) Machine Learning " + Environment.NewLine +
                       "3) Data Visualization " + Environment.NewLine +
                       "4) Όλα τα παραπάνω ";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 4;
                    break;
                case 5:
                    richTextBox1.Text = "Ποιο από τα ακόλουθα δεν αποτελεί μέρος της διαδικασίας της επιστήμης των δεδομένων;" + Environment.NewLine +
                      "1) Discovery" + Environment.NewLine +
                      "2) Operationalization" + Environment.NewLine +
                      "3) Model Planning" + Environment.NewLine +
                      "4) Communication Building";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 4;
                    break;

            }
        }
        private void Data_Analytics_Test_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connectionString);
            TotalQuestions = 6;
            QuestionNum = 1;
            askQuestion(QuestionNum);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Απαντήστε τις ερωτήσεις. Στο τέλος του τεστ θα σας ανακοινωθεί " +
               "το ποσοστό επιτυχίας σας. Μπορείτε να κάνετε το τεστ όσες φορές θέλετε εσείς!");
        }
    }
}
