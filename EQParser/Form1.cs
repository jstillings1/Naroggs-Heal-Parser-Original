using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;




namespace EQParser
{// Writen by Jeremiah Stillings
 // Narogg Xegony Server
 // Version 1.0
 // May 28, 2016
 // jstillings1@nc.rr.com




    public partial class Form1 : Form
    {
        /// <summary>
        /// Parser variables
        /// </summary>
        private string _path;
        private int _healCount;
        private int _playerHealAmt;
        private int _totalHealAmt;
        private string _playerHeal;
        private string _encounterName;
        private string _userView1;
        private string _userView2;
        private string _healee;
        private string _spellNamefinal;
        private string _spellPlayerName;
        int _logLoadTimer = 0;
        AlertForm _alert;
        string _connetionString;
        SqlConnection _connection;
        DataSet _ds = new DataSet();
        string _sql;
        string _sql2;
        Stats _stats;



        /// <summary>
        /// End Parser variables
        /// </summary>
        public Form1()
        {

            InitializeComponent();
            //mandatory. Otherwise will throw an exception when calling ReportProgress method  
            backgroundWorker1.WorkerReportsProgress = true;

            //mandatory. Otherwise we would get an InvalidOperationException when trying to cancel the operation  
            backgroundWorker1.WorkerSupportsCancellation = true;
            
            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult eqlogfile = openFileDialog1.ShowDialog();
            _path = openFileDialog1.FileName;

            switch (eqlogfile)
            {
                case DialogResult.OK:
                    {

                        File.Copy(_path, "Working_file.txt", true);
                        MessageBox.Show("Done Log File Selection");
                        // enter the progress bar
                        if (backgroundWorker1.IsBusy != true)
                        {
                            // create a new instance of the alert form
                            _alert = new AlertForm();
                            _alert.Show();
                            // Start the asynchronous operation.
                            backgroundWorker1.RunWorkerAsync();
                        }
                        // This event handler cancels the backgroundworker, fired from Cancel button in AlertForm.

                        _alert.Canceled += new EventHandler<EventArgs>(buttonCancel_Click);
                        // start timer for load time
                        timer1.Interval = 1000;
                        timer1.Start();
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        MessageBox.Show("ALERT: File Selection exited!");


                        break;
                    }
            }

        }










        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                // Close the AlertForm
                _alert.Close();

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {













        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            ///connect to Database
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Database1.mdf ; Integrated Security = True; Connect Timeout = 30";

            using (SqlConnection openCon = new SqlConnection(connectionString))
            {

                try
                {
                    openCon.Open();

                    //MessageBox.Show("Database opened");
                }
                catch
                {
                    openCon.Close();
                    MessageBox.Show("Error opening database");

                }
                try
                {
                    /// clear heal table of old parses

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2 = new SqlCommand("TRUNCATE TABLE [TotalHeals]", openCon);
                    cmd2.ExecuteNonQuery();

                }
                catch
                {
                    MessageBox.Show("Error clearing old table data");
                }

                /// Stream Read the TXT File line by line


                int progress = 0;
                int percent = 0;
                _healCount = 0;

                using (StreamReader reader = new StreamReader("Working_file.Txt"))

                    while (reader.EndOfStream == false)
                    {
                        //if cancellation is pending, cancel work.  
                        if (backgroundWorker1.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }



                        string line = reader.ReadLine();
                        // fix for odd chance you type ... and hits in the same chat line
                        
                           
                       
                        // stuff for the loading bar
                        progress = progress + 1;
                        if (progress >= 20000)
                        {
                            percent = percent + 1;
                            progress = 0;
                            if (percent == 100)
                            {
                                percent = 0;
                                MessageBox.Show("Your log file needs maintence because it is getting to large. You may continue to wait or press cancel and use the log chunker button.");
                            }

                        }

                        worker.ReportProgress(percent);
                        // end stuff


                        if (line == null)
                            break;

                        /// Fix the time stamp issue
                        Regex yourRegex = new Regex(@"\[([^\}]+)\]");
                        string fixedline = yourRegex.Replace(line, "");
                        fixedline.Replace("'", "''");


                        /// Fix chat

                        string[] items = fixedline.Split('.');

                        foreach (string item in items)
                        {


                            if (item.IndexOf("tells") != -1)
                            {
                                fixedline = "";

                            }
                            if (item.IndexOf("say") != -1)
                            {
                                fixedline = "";
                            }
                            if (item.IndexOf("told") != -1)
                            {
                                fixedline = "";
                            }










                            /*   // this works on others spells not yours
                               ///get spell name Variable used is SpellNameFinal
                               if (item.IndexOf("begins to cast") != -1)
                               {
                                   string[] parts = Regex.Split(fixedline, ">");
                                   var list3 = new List<string>();
                                   for (int i = 0; i < parts.Length; i++)
                                   {
                                       if (parts[i].Contains("<"))
                                       {
                                           string[] parts2 = Regex.Split(parts[i], "<");

                                           SpellName = parts2[1];
                                           SpellNamefinal = SpellName.Replace("'", "''");
                                           // Create a list of spells cast for troubleshooting
                                           list3.Add(SpellNamefinal);


                                       }
                                   }

                                   */

                            // get healers actual heals Variable used Is PlayerHealAMT
                            if (item.IndexOf("You begin casting") != -1)
                            {

                                // add code to find spell name cast
                                string[] parts2 = Regex.Split(fixedline, "casting");
                                _spellNamefinal = parts2[1];
                                if (_spellNamefinal.Contains("'"))
                                {
                                    _spellNamefinal = _spellNamefinal.Replace("'", " ");
                                }
                                if (_spellNamefinal.Contains("."))
                                {
                                    _spellNamefinal = _spellNamefinal.Replace(".", "");
                                }

                                _healCount++;



                                // add hunt for your landing heals loop here.
                                while (line.Contains("You begin casting"))
                                {

                                    string line2 = reader.ReadLine();
                                                                      

                                    if (line2 == null)
                                    {
                                        break;
                                    }
                                    /// Fix the time stamp issue line 2
                                    Regex yourRegex2 = new Regex(@"\[([^\}]+)\]");
                                    string fixedline2 = yourRegex2.Replace(line2, "");
                                    fixedline2.Replace("'", "''");

                                    // code to detect Tunare's Grace special aa Heal
                                    string[] items3 = Regex.Split(fixedline2, "points");
                                    foreach (string item3 in items3)
                                    {
                                        if (item3.IndexOf("Tunare's Grace") != -1)
                                        {
                                            string[] parts3 = Regex.Split(fixedline2, "points");
                                            for (int i = 0; i < parts3.Length; i++)
                                            {
                                                if (parts3[i].Contains("for"))
                                                {
                                                    string[] parts4 = Regex.Split(parts3[i], "for");

                                                    _playerHeal = parts4[1];
                                                }
                                            }

                                            _playerHealAmt = int.Parse(_playerHeal);
                                            _totalHealAmt = _totalHealAmt + _playerHealAmt;
                                            _spellPlayerName = "You";
                                            _healee = "You";
                                            _spellNamefinal = "Tunares Grace";
                                            // create columns for healed
                                            // TO DO check to see if column exists instead of throwing error
                                            SqlCommand cmd5 = new SqlCommand();
                                            cmd5 = new SqlCommand("Select count(*) from INFORMATION_SCHEMA.columns where table_name = 'TotalHeals'and column_name = '" + _healee + "'", openCon);
                                            int output = Convert.ToInt32(cmd5.ExecuteScalar());
                                            if (output > 0)
                                            {
                                                // column already present....handle that case..
                                            }
                                            else
                                            {   //alter your table to add the column
                                                try
                                                {
                                                    SqlCommand cmd6 = new SqlCommand();
                                                    cmd6 = new SqlCommand("ALTER TABLE TotalHeals ADD " + _healee + " INT", openCon);
                                                    cmd6.ExecuteNonQuery();
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Error adding column to database:" + _healee);

                                                }

                                            }
                                            try
                                            {

                                                SqlCommand cmd4 = new SqlCommand();
                                                //write heals

                                                cmd4 = new SqlCommand("INSERT INTO TotalHeals(TotalHeal,TotalHealCT,PlayerName,SpellName,Encounter,EachHeal,Healee," + _healee + ") VALUES ('" + _totalHealAmt + "','" + _healCount + "','" + _spellPlayerName + "','" + _spellNamefinal + "','" + _encounterName + "','" + _playerHealAmt + "','" + _healee + "','" + _playerHealAmt + "')", openCon);
                                                cmd4.ExecuteNonQuery();




                                            }
                                            catch
                                            {

                                                MessageBox.Show("Error Writing :" + _totalHealAmt + "','" + _healCount + "','" + _spellPlayerName + "','" + _spellNamefinal + "','" + _encounterName + "','" + _playerHealAmt + "','" + _healee + "','" + _playerHealAmt + "Press ok to continue");
                                            }

                                        }

                                    }

                                    /// Fix chat line 2
                                   
                                   


                                    string[] items2 = fixedline2.Split('.');

                                    foreach (string item2 in items2)
                                    {


                                        if (item2.IndexOf("tells") != -1)
                                        {
                                            fixedline2 = "";

                                        }
                                        if (item2.IndexOf("say") != -1)
                                        {
                                            fixedline2 = "";
                                        }
                                        if (item2.IndexOf("told") != -1)
                                        {
                                            fixedline2 = "";
                                        }
                                        ///get encounter name Variable used is EncounterName - 
                                        if (fixedline2 != "")
                                        {
                                            if (item2.Contains("hits"))
                                            {
                                                if (item2.Contains("pet"))
                                                {

                                                }
                                                else
                                                {
                                                    if (item2.Contains("hits the floor"))
                                                    {

                                                    }
                                                    else
                                                    {
                                                        if (item2.Contains("hits the cold cavern floor "))
                                                        {

                                                        }
                                                        else
                                                        {
                                                            if (item2.Contains("The suit of armor makes a loud clanking sound as it"))
                                                            {
                                                            }
                                                            else
                                                            {
                                                                if (item2.Contains("tell"))
                                                                {

                                                                }
                                                                else
                                                                {
                                                                    if (item2.Contains("told"))
                                                                    {

                                                                    }
                                                                    else
                                                                    {
                                                                        if (item2.Contains("say"))
                                                                        {

                                                                        }
                                                                        else
                                                                        {
                                                                            if (item2.Contains("thuds as it"))
                                                                            {
                                                                            }
                                                                            else
                                                                            {
                                                                                _encounterName = fixedline2.Substring(0, item2.IndexOf("hits"));
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                            }
                                        }

                                        // Look for the heal number
                                        if (item2.IndexOf("You have healed") != -1)
                                        {
                                            _playerHeal = Regex.Match(item2, @"\d+").Value;
                                            _playerHealAmt = int.Parse(_playerHeal);
                                            _totalHealAmt = _totalHealAmt + _playerHealAmt;
                                            _spellPlayerName = "You";
                                            // add hunt for player healed here
                                            // code for locating healee's name                                    
                                            string[] parts3 = Regex.Split(fixedline2, "for");
                                            for (int i = 0; i < parts3.Length; i++)
                                            {
                                                if (parts3[i].Contains("healed"))
                                                {
                                                    string[] parts4 = Regex.Split(parts3[i], "healed");

                                                    _healee = parts4[1];
                                                }
                                            }

                                            // code to detect Copious Healing special aa Heal
                                            if (item2.Contains("Copious Healing"))
                                            {
                                                string[] parts4 = Regex.Split(fixedline2, ".");
                                                for (int i = 0; i < parts4.Length; i++)
                                                {
                                                    if (parts4[i].Contains("your"))
                                                    {
                                                        string[] parts5 = Regex.Split(parts4[i], "your");

                                                        _spellNamefinal = parts5[1];
                                                    }
                                                }

                                            }
                                            //fix for a Hireling as a healee
                                            if (_healee.Contains("hireling"))
                                            {
                                                _healee = "Merc";
                                            }
                                            // fix for aa pets being healee
                                            if (_healee.Contains("pet"))
                                            {
                                                _healee = "AAPet";
                                            }
                                            // fix for healee with more then 1 name
                                            _healee = _healee.Replace(" ", "");
                                            // bug fix 5-31-16 fix for warder's and familurs as healee
                                            _healee = _healee.Replace("`", "");


                                            // code to check for healee's with spaces in name
                                            SqlCommand cmd2 = new SqlCommand();
                                            SqlCommand cmd3 = new SqlCommand();
                                            // create columns for healed
                                            // TO DO check to see if column exists instead of throwing error
                                            cmd3 = new SqlCommand("Select count(*) from INFORMATION_SCHEMA.columns where table_name = 'TotalHeals'and column_name = '" + _healee + "'", openCon);
                                            int output = Convert.ToInt32(cmd3.ExecuteScalar());
                                            if (output > 0)
                                            {
                                                // column already present....handle that case..
                                            }
                                            else
                                            {   //alter your table to add the column
                                                try
                                                {
                                                    cmd2 = new SqlCommand("ALTER TABLE TotalHeals ADD " + _healee + " INT", openCon);
                                                    cmd2.ExecuteNonQuery();
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Error adding column to database:" + _healee);

                                                }

                                            }



                                            try
                                            {

                                                SqlCommand cmd = new SqlCommand();
                                                if (_healee == null)
                                                {
                                                    _healee = "No Target";
                                                }



                                                //write heals
                                                cmd = new SqlCommand("INSERT INTO TotalHeals(TotalHeal,TotalHealCT,PlayerName,SpellName,Encounter,EachHeal,Healee," + _healee + ") VALUES ('" + _totalHealAmt + "','" + _healCount + "','" + _spellPlayerName + "','" + _spellNamefinal + "','" + _encounterName + "','" + _playerHealAmt + "','" + _healee + "','" + _playerHealAmt + "')", openCon);
                                                cmd.ExecuteNonQuery();




                                            }
                                            catch
                                            {

                                                MessageBox.Show("Error Writing :" + _totalHealAmt + "','" + _healCount + "','" + _spellPlayerName + "','" + _spellNamefinal + "','" + _encounterName + "','" + _playerHealAmt + "','" + _healee + "','" + _playerHealAmt + "Press ok to continue");
                                            }





                                        }

                                    }
                                    if (line2.Contains("You begin casting"))
                                    {
                                        break;
                                    }



                                }
                            }
                        }
                    }
                openCon.Close();
            }

        }











        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Show the progress in main form (GUI)
            labelResult.Text = (e.ProgressPercentage.ToString() + "%");
            // Pass the progress to AlertForm label and progressbar
            _alert.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
            _alert.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                labelResult.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                labelResult.Text = "Error: " + e.Error.Message;
            }
            else
            {

                labelResult.Text = "Log Loaded in: " + _logLoadTimer + " Seconds";
            }
            // Close the AlertForm
            timer1.Stop();
            _alert.Close();
            MessageBox.Show(" Done Parse");


            // this displays the main data table

            SqlDataAdapter totalHealsTableAdapter1 = new SqlDataAdapter();
            DataSet database1DataSet1 = new DataSet();


            _sql = "select * from TotalHeals";
            _connetionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Database1.mdf; Integrated Security = True; Connect Timeout = 30";
            _connection = new SqlConnection(_connetionString);
            try
            {
                _connection.Open();
                totalHealsTableAdapter1 = new SqlDataAdapter(_sql, _connection);
                totalHealsTableAdapter1.Fill(database1DataSet1);
                _connection.Close();
                dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView2.MultiSelect = false;
                dataGridView2.DataSource = database1DataSet1.Tables[0];
                this.totalHealsTableAdapter1.Fill(this.database1DataSet1.TotalHeals);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            // this displays the encounter table
            SqlDataAdapter totalHealsTableAdapter = new SqlDataAdapter();
            DataSet database1DataSet = new DataSet();


            _sql = "select Encounter from TotalHeals";
            _connetionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Database1.mdf; Integrated Security = True; Connect Timeout = 30";
            _connection = new SqlConnection(_connetionString);
            try
            {
                _connection.Open();
                totalHealsTableAdapter = new SqlDataAdapter(_sql, _connection);
                totalHealsTableAdapter.Fill(database1DataSet);
                _connection.Close();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.DataSource = database1DataSet1.Tables[0];
                this.totalHealsTableAdapter.Fill(this.database1DataSet.TotalHeals);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }




        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            _logLoadTimer = _logLoadTimer + 1;

        }

       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                
                    _userView1 = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " Selected");
                    // this displays the filtered data

                    SqlDataAdapter totalHealsTableAdapter1 = new SqlDataAdapter();
                    DataSet database1DataSet1 = new DataSet();


                    _sql = "select * from TotalHeals where Encounter = '" + _userView1 + "'";
                    _connetionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Database1.mdf; Integrated Security = True; Connect Timeout = 30";
                    _connection = new SqlConnection(_connetionString);
                    try
                    {
                        _connection.Open();
                        totalHealsTableAdapter1 = new SqlDataAdapter(_sql, _connection);
                        totalHealsTableAdapter1.Fill(database1DataSet1);
                        _connection.Close();
                        dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        dataGridView2.MultiSelect = false;
                        dataGridView2.DataSource = database1DataSet1.Tables[0];
                        this.totalHealsTableAdapter1.Fill(this.database1DataSet1.TotalHeals);
                        labelResult.Text = "Sorting by" + _userView1;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
            }
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {

                    _userView2 = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    MessageBox.Show(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " Selected");
                    // this displays the filtered data

                    SqlDataAdapter totalHealsTableAdapter1 = new SqlDataAdapter();
                    DataSet database1DataSet1 = new DataSet();


                    _sql = "select * from TotalHeals where Encounter = '" + _userView1 + "'AND Healee = '" + _userView2 + "'";
                    _connetionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Database1.mdf; Integrated Security = True; Connect Timeout = 30";

                    _connection = new SqlConnection(_connetionString);
                    try
                    {
                        _connection.Open();
                        totalHealsTableAdapter1 = new SqlDataAdapter(_sql, _connection);
                        totalHealsTableAdapter1.Fill(database1DataSet1);
                        _connection.Close();
                        dataGridView2.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        dataGridView2.MultiSelect = false;
                        dataGridView2.DataSource = database1DataSet1.Tables[0];
                        this.totalHealsTableAdapter1.Fill(this.database1DataSet1.TotalHeals);

                        labelResult.Text = "Sorting by" + _userView1 + " and " + _userView2;
                       /* //add stats window here
                        stats.Healee = UserView2;
                        stats.Encounter = UserView1;
                        stats = new Stats();
                        SqlDataAdapter totalHealsTableAdapter3 = new SqlDataAdapter();
                        DataSet database1DataSet4 = new DataSet();


                        Sql2 = "select * from TotalHeals where Encounter = '" + UserView1 + "'AND Healee = '" + UserView2 + "'";
                        connetionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\Database1.mdf; Integrated Security = True; Connect Timeout = 30";

                        connection = new SqlConnection(connetionString);

                        connection.Open();
                        totalHealsTableAdapter3 = new SqlDataAdapter(Sql2, connection);
                        totalHealsTableAdapter3.Fill(database1DataSet4);
                        connection.Close();
                        stats.dataGridView3.DataSource = database1DataSet4.Tables[0];
                        stats.totalHealsTableAdapter3.Fill(stats.database1DataSet4.TotalHeals);
                        stats.Show();
                        */
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    
                        

                   








               
                }
            }
            
        }
        // Log Chunker code
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Log Chunking will create numerous 25 MB new logs of your currently selected log file. It will leave the original log intact. ");
            DialogResult eqlogfile2 = openFileDialog2.ShowDialog();
            _path = openFileDialog2.FileName;

            switch (eqlogfile2)
            {
                case DialogResult.OK:
                    {

                        string sourceFileName = _path;

                        string destFileLocation = Path.GetDirectoryName(_path); ;

                        int index = 0;

                        long maxFileSize = 26214400;

                        byte[] buffer = new byte[65536];



                        using (System.IO.Stream source = File.OpenRead(sourceFileName))

                        {

                            while (source.Position < source.Length)

                            {

                                index++;



                                // Create a new sub File, and read into it

                                string newFileName = Path.Combine(destFileLocation, Path.GetFileNameWithoutExtension(sourceFileName));

                                newFileName += index.ToString() + Path.GetExtension(sourceFileName);

                                using (System.IO.Stream destination = File.OpenWrite(newFileName))

                                {

                                    while (destination.Position < maxFileSize)

                                    {

                                        // Work out how many bytes to read

                                        int bytes = source.Read(buffer, 0, (int)Math.Min(maxFileSize, buffer.Length));

                                        destination.Write(buffer, 0, bytes);



                                        // Are we at the end of the file?

                                        if (bytes < Math.Min(maxFileSize, buffer.Length))

                                        {

                                            break;

                                        }

                                    }

                                }

                            }
                        }
                            MessageBox.Show("Done Log Chunking");

                            break;
                        }
                    
                case DialogResult.Cancel:
                    {
                        MessageBox.Show("ALERT: Log Chunker Exited!");


                        break;
                    }
            }

        }
    }
    }




