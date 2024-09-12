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
    public partial class Python_Test : Form
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

        public Python_Test(string UserNamePassed)
        {
            UserName = UserNamePassed;
            InitializeComponent();
        }

        private void checkAnswerEvent(object sender, EventArgs e)
        {
            //κάθε φορα που κλικάρω κουμπί θα ενεργοποιείται αυτό το event
            var senderObject = (Button)sender;
            int buttonTag = Convert.ToInt32(senderObject.Tag);
            if (buttonTag == correctAnswer) {
                score++;
            }
            if (QuestionNum == TotalQuestions) {
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
                    comm.CommandText = "INSERT INTO test_grades (user_id,py) VALUES(@USER_ID,  @PYTHON)";
                    comm.Parameters.AddWithValue("@USER_ID", id);
                    comm.Parameters.AddWithValue("@PYTHON", percentage);
                    comm2.CommandText = "UPDATE test_grades SET py = '"+percentage+"' WHERE user_id = '"+id+"';";
                    
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
                MessageBox.Show("Το Quiz ολοκληρώθηκε. Τα αποτελέσματά σας έχουν αποθηκευτεί!"+Environment.NewLine
                    +"To ποσοστό επιτυχίας σας είναι: "+percentage.ToString()+"%"+Environment.NewLine+
                    "Πατήστε οκ για να γυρίσετε πίσω στην θεωρία");
                
                //γυρνάω πίσω στη θεωρία
                this.Close();

            }
           
            QuestionNum++;
            askQuestion(QuestionNum);
        }
        private void askQuestion(int QestionNum) {
            switch (QestionNum) {
                case 1:
                    richTextBox1.Text = "Ποιό είναι το αποτέλεσμα του παρακάτω κώδικα;"+Environment.NewLine +
                        "valueOne = 5 ** 2"+Environment.NewLine +
                        "valueTwo = 5 ** 3"+ Environment.NewLine+
                        "print(valueOne)" + Environment.NewLine +
                        "print(valueTwo)";
                    button1.Text = "Απάντηση 1: 10,15";
                    button2.Text = "Απάντηση 2: 25,125";
                    button3.Text = "Απάντηση 3: 7,8";
                    button4.Text = "Απάντηση 4: Error: invalid syntax";
                    correctAnswer = 2;
                    break;
                case 2:
                    richTextBox1.Text = "Ποιό είναι το αποτέλεσμα του παρακάτω κώδικα;" + Environment.NewLine +
                        "sampleList = [Jon,Kelly,Jessa]" + Environment.NewLine +
                        "sampleList.append(Scott)" + Environment.NewLine +
                        "print(sampleList)";
                    button1.Text = "Απάντηση 1:  [‘Jon’, ‘Kelly’, ‘Scott’, ‘Jessa’]";
                    button2.Text = "Απάντηση 2: [‘Jon’, ‘Kelly’, ‘Jessa’, ‘Scott’]";
                    button3.Text = "Απάντηση 3: [Jon, Kelly, 'Scott']";
                    button4.Text = "Απάντηση 4: Error: invalid syntax";
                    correctAnswer = 2;
                    break;
                case 3:
                    richTextBox1.Text = "Ποιό είναι το αποτέλεσμα του παρακάτω κώδικα;" + Environment.NewLine +
                       "var1 = 1" + Environment.NewLine +
                       "var2 = 2" + Environment.NewLine +
                       "var3 = '3'" + Environment.NewLine +
                       "print(var1 + var2 + var3)";
                    button1.Text = "Απάντηση 1:  6";
                    button2.Text = "Απάντηση 2: 33";
                    button3.Text = "Απάντηση 3: 123";
                    button4.Text = "Απάντηση 4: Error. Mixing operators between numbers and strings are not supported";
                    correctAnswer = 4;
                    break;
                case 4:
                    richTextBox1.Text = "Ποιά είναι η σωστή σύνταξη για την εκτύπωση του 'Hello World' στη Python;";
                     
                    button1.Text = "Απάντηση 1: echo('Hello World')";
                    button2.Text = "Απάντηση 2: p('Hello World')";
                    button3.Text = "Απάντηση 3: print('Hello World')";
                    button4.Text = "Απάντηση 4: print 'Hello World'";
                    correctAnswer = 3;
                    break;
                case 5:
                    richTextBox1.Text = "Πώς γίνεται η εισαγωγή σχόλιων στη Python;";

                    button1.Text = "Απάντηση 1: // This is a comment";
                    button2.Text = "Απάντηση 2: #This is a comment";
                    button3.Text = "Απάντηση 3: <'This is a comment'>)";
                    button4.Text = "Απάντηση 4: Η Python δεν έχει σχόλια";
                    correctAnswer = 2;
                    break;
                case 6:
                    richTextBox1.Text = "Πως δημιουργείται μία αριθμητική μεταβλητή x με την τιμή 5;";

                    button1.Text = "Απάντηση 1: int x = 5;";
                    button2.Text = "Απάντηση 2: x = 5;";
                    button3.Text = "Απάντηση 3: x = 5";
                    button4.Text = "Απάντηση 4: x = x+5";
                    correctAnswer = 3;
                    break;

            }
        }

        private void Python_Test_Load(object sender, EventArgs e)
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
