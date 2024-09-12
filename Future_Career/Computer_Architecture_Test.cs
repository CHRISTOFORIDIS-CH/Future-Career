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
    public partial class Computer_Architecture_Test : Form
    {
        //Για το insert στη βαση
        int id_Check = 0;
        string UserName;
        int id = 0;
        String connectionString = "Server=localhost;Port=5432;User Id=postgres;Password="+ConnectionString.password+";Database=Future_Career_DB;";
        NpgsqlConnection conn;
        // για το quiz  
        int QuestionNum;
        int correctAnswer;
        int score;
        int percentage;
        int TotalQuestions;
        public Computer_Architecture_Test(string UserNamePassed)
        {
            UserName = UserNamePassed;
            InitializeComponent();
        }

        private void Computer_Architecture_Test_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connectionString);
            TotalQuestions = 6;
            QuestionNum = 1;
            askQuestion(QuestionNum);
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
                    comm.CommandText = "INSERT INTO test_grades (user_id,ca) VALUES(@USER_ID,  @DATAARCH)";
                    comm.Parameters.AddWithValue("@USER_ID", id);
                    comm.Parameters.AddWithValue("@DATAARCH", percentage);
                    comm2.CommandText = "UPDATE test_grades SET ca = '" + percentage + "' WHERE user_id = '" + id + "';";

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
                    richTextBox1.Text = "To σύνολο εντολών του επεξεργαστή MIPS επιτρέπει την πρόθεση:" + Environment.NewLine +
                        "1)Eνός καταχωρητή και μίας σταθεράς" + Environment.NewLine +
                        "2)Eνός καταχωρητή και μίας θέσης μνήμης" + Environment.NewLine +
                        "3)Mίας θέσης μνήμης και μίας σταθεράς" + Environment.NewLine +
                        "4)Όλα τα παραπάνω";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 1;
                    break;
                case 2:
                    richTextBox1.Text = "Η μεταγλώττιση της σύνθετης εντολής f = 2*(a+b) + c σε συμβολική γλώσσα MIPS παράγει" + Environment.NewLine +
                        "(εάν θεωρήσουμε ότι οι μεταβλητές f,a,b,c βρίσκονται στην μνήμη):" + Environment.NewLine +
                        "1) 3 εντολές" + Environment.NewLine +
                        "2) 5 εντολές" + Environment.NewLine +
                        "3) 7 εντολές" + Environment.NewLine +
                        "4) 9 εντολές";
                    button1.Text = "Απάντηση 1";
                    button2.Text = "Απάντηση 2";
                    button3.Text = "Απάντηση 3";
                    button4.Text = "Απάντηση 4";
                    correctAnswer = 3;
                    break;
                case 3:
                    richTextBox1.Text = "Έστω ότι ο καταχωρητής $t1 περιέχει την τιμή 10. Τι τιμή θα περιέχει ο καταχωρητής $t0 μετά" + Environment.NewLine +
                       "την εκτέλεση της εντολής sll $t0,$t1,5:";
                    button1.Text = "100000";
                    button2.Text = "100";
                    button3.Text = "320 ";
                    button4.Text = "640";
                    correctAnswer = 1;
                    break;
                case 4:
                    richTextBox1.Text = "Θεωρήστε έναν επεξεργαστή P με ρολόι συχνότητας 100 MHz. Το σύνολο εντολών του επεξεργαστή" + Environment.NewLine +
                        "εριλαμβάνει 3 κατηγορίες εντολών A,B και C με CPI 1,2 και 3 αντίστοιχα. Ένα πρόγραμμα Χ περιέχει" + Environment.NewLine +
                        "εντολές εκ των οποίων το 50% είναι εντολες της κατηγορίας Α, το 30% εντολές της κατηγορίας Β" + Environment.NewLine +
                        "το 20% εντολές της κατηγορίας C. Ποιός είναι ο χρόνος εκτέλεσης του προγράμματος;";
                    button1.Text = "19 ms";
                    button2.Text = "19 sec";
                    button3.Text = "17 ms ";
                    button4.Text = "17 sec";
                    correctAnswer = 3;
                    break;
                case 5:
                    richTextBox1.Text = " Ποιός δεκαδικός αριθμός αναπαρίσταται από τον αριθμό κινητής υποδιαστολής 1 01111110 010000000000000"+Environment.NewLine+
                        "(ο αριθμός είναι σε μορφή IEEE 754 απλής ακρίβειας);";

                    button1.Text = "-0.375";
                    button2.Text = "+0.375";
                    button3.Text = "-0.625";
                    button4.Text = "+0.625";
                    correctAnswer = 3;
                    break;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Απαντήστε τις ερωτήσεις. Στο τέλος του τεστ θα σας ανακοινωθεί " +
                "το ποσοστό επιτυχίας σας. Μπορείτε να κάνετε το τεστ όσες φορές θέλετε εσείς!");
        }
    }
}
