using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//db 
using System.Data.OleDb;


namespace Geo
{
    public partial class Form1 : Form
    {
        //db connection 
        static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\DB.accdb";
        OleDbConnection conn = new OleDbConnection(connectionString);


        private List <Participants> players = new List<Participants>();
        private string answer_key, tie_breaker;
        private string final_score;
      

        public Form1()
        {
            InitializeComponent();
        }



        private void Btn_import_Click(object sender, EventArgs e)
        {
            //code to import
            //open csv => read lines=> store in objects=> add to list

            int counter = 0;
            string line;
            
            string[] items = new string[5];

            try
            {
                // Read the file and display it line by line.  
                StreamReader file = new StreamReader("test.txt");
                //retrieving ans key string
                string answer_key_line = file.ReadLine();
                string[] answer_key_line_list = answer_key_line.Split(',');
                answer_key = answer_key_line_list[4];
                //retriving tie breaker string
                string tie_breaker_line = file.ReadLine();
                string[] tie_breaker_line_list = tie_breaker_line.Split(',');
                tie_breaker = tie_breaker_line_list[4];

                while ((line = file.ReadLine()) != null)
                {
                    Participants p = new Participants();
                    items = line.Split(',');

                    p.setLastname(items[0].ToString());
                    p.setFirstname(items[1].ToString());
                    //2 char
                    int class_id = Int32.Parse(items[2]);
                    p.setClassid(class_id);
                    //6 char
                    int school_id = Int32.Parse(items[3]);
                    p.setSchoolid(school_id);

                    //validate str answers
                    bool invalid_input = false;
                    string temp= items[4].ToString();
                    foreach (var answer in temp) {
                        int a= (int)Char.GetNumericValue(answer);

                        if (answer != '*' && a > 6){
                           MessageBox.Show("Input file has invalid characters!");
                            Application.Exit();
                            invalid_input = true;                      
                        }
                    }

                string player_ans = items[4].ToString();
                p.setStrAnswers(items[4]);
          
                calculate_scores(player_ans);
                p.setfinal_scores(final_score);

                //adding participants obkects to array list 
                players.Add(p);

                counter++;
            }

            file.Close();
            }
            catch (Exception ei)
            {
                MessageBox.Show("Error unable to read/write to the file.");
            }

            //adding rows to database
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();           
            foreach (var pl in players)
            {
                //setting cmd property
                cmd.Connection = conn;
                cmd.CommandText = "INSERT into tbl_records(final_score,lname,fname,class_id,school_id,strAnswers) " +
                                  "values(@score,@ln,@fn,@c_id,@s_id,@strAnswers);";
                //declaring sql variables
                cmd.Parameters.Add("@score", OleDbType.VarChar);
                cmd.Parameters.Add("@ln", OleDbType.VarChar);
                cmd.Parameters.Add("@fn",OleDbType.VarChar);
                cmd.Parameters.Add("@c_id", OleDbType.Integer);
                cmd.Parameters.Add("@s_id", OleDbType.Integer);
                
                cmd.Parameters.Add("@strAnswers", OleDbType.VarChar);

                //initialize vals to sql variables
                cmd.Parameters["@fn"].Value = pl.getFirstName();
                cmd.Parameters["@ln"].Value = pl.getLastName();
                cmd.Parameters["@c_id"].Value = pl.getClassid();
                cmd.Parameters["@s_id"].Value = pl.getSchoolid();
                
                cmd.Parameters["@score"].Value = pl.getfinal_scores();
                cmd.Parameters["@strAnswers"].Value = pl.getstrAnswers();

                cmd.ExecuteNonQuery();
              
            }      
            conn.Close();

            //add to db messgaebox
            MessageBox.Show("Scores sucessfully calculated!!");
            Btn_display_tbl.Enabled = true;
            Btn_import.Enabled = false;

        }

        private void Btn_display_tbl_Click(object sender, EventArgs e)
        {

            try
            {
                //code to bind data grid to database    
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM tbl_records";

                //data adpater used to bind access to datagridtable
                OleDbDataAdapter d = new OleDbDataAdapter(cmd);
                DataTable table = new DataTable();
                d.Fill(table);
                dataGridView1.DataSource = table;
                //close connection
                conn.Close();
            }
            catch(Exception ei) {
                MessageBox.Show("Unable to read/write to database");
            }

            //enable export button
            Btn_ex_individual.Enabled = true;
            Btn_exp_group.Enabled = true;
            btn_exp_all_team.Enabled = true;
            Btn_display_tbl.Enabled = false;

        }

        private void Btn_ex_individual_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("individual_report.txt");
                //Write a line of text
                sw.WriteLine("         Northwoods University");
                sw.WriteLine("Junior Division Scores With Tiebreakers");
                sw.WriteLine("----------------------------------------");
                //Write a second line of text
                sw.WriteLine("         1111111111222222222233333333334");
                sw.WriteLine("1234567890123456789012345678901234567890");
                sw.WriteLine("");

                foreach (var pl in players)
                {
                    sw.WriteLine(pl.getfinal_scores() + "\t" + pl.getLastName() + "\t" + pl.getFirstName() + "\t" 
                                 + pl.getClassid()+ "\t" + pl.getSchoolid() +"\t"+pl.getstrAnswers());
                }

                MessageBox.Show("Individual Report Sucessfully Exported !!!");
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error unable to read/write to the file.");
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }
        private void btn_exp_all_team_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.CreateText("Group_all_report.txt"))
            {
                //Write a line of text
                sw.WriteLine("         Northwoods University");
                sw.WriteLine("Junior Division Scores With Tiebreakers");
                sw.WriteLine("----------------------------------------");

            //setting up school arraylist
            //int arraylist
            ArrayList s_id= new ArrayList();
            foreach (var pl in players)
            {
                if (!s_id.Contains(pl.getSchoolid())) {
                    s_id.Add(pl.getSchoolid());
                }
            }

            int teamscore = 0;
            List<int> top3s = new List<int>();
            foreach (var school in s_id)
            {
                sw.WriteLine(school);
                sw.WriteLine("======");
                foreach (var pl in players)
                {
                    if (pl.getSchoolid() == (int)school)
                    {
                        string tempScore = pl.getfinal_scores().Substring(0, 2);
                        //add to top3s
                        //top3s.Add(Int32.Parse(tempScore));
                        teamscore = teamscore + Int32.Parse(tempScore);
                        sw.WriteLine(tempScore + " " + pl.getFirstName() + ", " + pl.getLastName());
                    }
                    //sort and get top 3
                    //top3s.Sort();
                    //write to file
                }
                sw.WriteLine("Team Score: " + teamscore+"\n");
                teamscore = 0; //resetting teamscore
            }
            }
            MessageBox.Show("Group Report Sucessfully Exported !!!");

        }

        private void Btn_exp_group_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.CreateText("Group_report.txt"))
            {
                //Write a line of text
                sw.WriteLine("         Northwoods University");
                sw.WriteLine("Junior Division Scores With Tiebreakers");
                sw.WriteLine("----------------------------------------");      
            }

            using (StreamWriter sww = File.AppendText("Group_report.txt"))
            {
                //take label text and calculate new score
                //loop in players if == to label text then take 
                //1st 2 chars to score , convert to int and sumit up
                int teamscore = 0;
                string s_id=txt_school_id.Text.ToString();
                sww.WriteLine(s_id);
                sww.WriteLine("======");
                foreach (var pl in players) {
                    if (pl.getSchoolid().ToString() == s_id) {
                        string tempScore=pl.getfinal_scores().Substring(0,2);
                        teamscore = teamscore + Int32.Parse(tempScore);
                        sww.WriteLine(tempScore+" "+pl.getFirstName() +", "+ pl.getLastName());
                    }
                }
                sww.WriteLine("Team Score: " + teamscore);
                teamscore = 0; //resetting teamscore
            }

            MessageBox.Show("Group Report Sucessfully Exported !!!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Btn_display_tbl.Enabled = false;
            Btn_ex_individual.Enabled = false;
            Btn_exp_group.Enabled = false;
            btn_exp_all_team.Enabled = false;
        }

        private void tbl_recordsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

  

        public void calculate_scores(string player_answer) {

            int SIZE = player_answer.Length;

            int totalscore = 0, tie1score = 0, tie2score = 0;
            char[] scoresArray = new char[3];

            char[] answer_key_array = answer_key.ToCharArray();
            char[] tie_breaker_array = tie_breaker.ToCharArray();
            char[] playerAnswer_array = player_answer.ToCharArray();

            int[] tiebreaker1_index = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                if (answer_key_array[i] == playerAnswer_array[i])
                {
                    totalscore++;
                }
            }
            //--------------------------------------------correct total score

            //find tie breaker index
            int[] pos1 = new int[SIZE];
            int[] pos2 = new int[SIZE];
            
            for (int i = 0; i < SIZE; i++)
            {
                if (tie_breaker_array[i] == '1')
                {
                    pos1[i] = i;
                    pos2[i] = -1;
                }
                else if (tie_breaker_array[i] == '2')
                {
                    pos2[i] = i;
                    pos1[i] = -1;
                }
                else
                {
                    pos1[i] = -1;
                    pos2[i] = -1;
                }

            }
            //--------------------------------------correct tie_breaker_index

            foreach (var index in pos1)
            {
                if ((index != -1) && (answer_key_array[index] == playerAnswer_array[index]))
                {
                    tie1score++;
                }
            }

            foreach (var index in pos2)
            {
                if ((index != -1) && (answer_key_array[index] == playerAnswer_array[index]))
                {
                    tie2score++;
                }
            }
            //----------------------------------------correct tie breaker scores

            Console.WriteLine("\nTotal score: " + totalscore);
            Console.WriteLine("\nTie 1 score: " + tie1score);
            Console.WriteLine("\nTie 2 score: " + tie2score);

            //generate final score
            string ftotalscore ="", ftie1score="", ftie2score="";
            if (totalscore < 9)
            {
                ftotalscore = "0" + totalscore.ToString();
            }
            else {
                ftotalscore = totalscore.ToString();
            }

            if (tie1score < 9)
            {
                ftie1score = "0" + tie1score.ToString();
            }
            else {
                ftie1score = tie1score.ToString();
            }

            if (totalscore < 9)
            {
                ftie2score = "0" + tie2score.ToString();
            }
            else {
                ftie2score = tie2score.ToString();
            }

            final_score = ftotalscore + ftie1score + ftie2score;
        }
    
    }
    
}
