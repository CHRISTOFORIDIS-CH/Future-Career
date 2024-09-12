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
    public partial class UI_test : Form
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
        public UI_test(String UserNamePassed)
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
                    comm.CommandText = "INSERT INTO test_grades (user_id,ui) VALUES(@USER_ID,  @UI)";
                    comm.Parameters.AddWithValue("@USER_ID", id);
                    comm.Parameters.AddWithValue("@UI", percentage);
                    comm2.CommandText = "UPDATE test_grades SET ui = '" + percentage + "' WHERE user_id = '" + id + "';";

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
                    richTextBox1.Text = "Τι είναι η UML?" + Environment.NewLine +
                        "1) Μια γλώσσα προγραμματισμού" + Environment.NewLine +
                        "2) Μια γλώσσα μοντελοποίησης" + Environment.NewLine +
                        "3) Μια μεθοδολογία ανάπτυξης" + Environment.NewLine +
                        "4) Ένα εργαλείο διαχείρισης έργου";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 2;
                    break;
                case 2:
                    richTextBox1.Text = "Τι παρέχει η UML για ανάλυση και σχεδίαση;" + Environment.NewLine +
                        "1) Επισήμανση σύνταξης" + Environment.NewLine +
                        "2) Δημιουργία κώδικα" + Environment.NewLine +
                        "3) Σύμβολα και σημειολογία " + Environment.NewLine +
                        "4) Δυνατότητες αποσφαλμάτωσης";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 3;
                    break;
                case 3:
                    richTextBox1.Text = "Ποιος επιβεβαίωσε τη UML ως βιομηχανικό πρότυπο;" + Environment.NewLine +
                          "1) W3C (World Wide Web Consortium)" + Environment.NewLine +
                          "2) IEEE (Institute of Electrical and Electronics Engineers)" + Environment.NewLine +
                          "3) OMG (Object Management Group)" + Environment.NewLine +
                          "4) ISO (International Organization for Standardization)";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 3;
                    break;
                case 4:
                    richTextBox1.Text = "Τι είναι η Rational Unified Process (RUP);" + Environment.NewLine +
                        "από έναν πίνακα με όνομα 'Persons';" + Environment.NewLine +
                          "1) Μια μεθοδολογία ανάπτυξης λογισμικού" + Environment.NewLine +
                          "2) Ένα εργαλείο διαγραμματισμού UML" + Environment.NewLine +
                          "3) Ένα πλαίσιο διαχείρισης έργου Agile" + Environment.NewLine +
                          "4) Μια γλώσσα προγραμματισμού";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 1;
                    break;
                case 5:
                    richTextBox1.Text = "Πώς απεικονίζονται οι συγχρονισμοί στα διαγράμματα δραστηριοτήτων;" + Environment.NewLine +
                           "1) Ορθογώνια" + Environment.NewLine +
                           "2) Κύκλοι" + Environment.NewLine +
                           "3) Ράβδοι" + Environment.NewLine +
                           "4) Βέλη";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 3;
                    break;

            }
        }
        private void UI_test_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connectionString);
            TotalQuestions = 6;
            QuestionNum = 1;
            askQuestion(QuestionNum);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Απαντήστε τις ερωτήσεις. Στο τέλος του τεστ θα σας ανακοινωθεί " +
       "το ποσοστό επιτυχίας σας. Μπορείτε να κάνετε το τεστ όσες φορές θέλετε εσείς!");
        }
    }
}
