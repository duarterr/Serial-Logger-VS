/* -------------------------------------------------------------------------------------------------------------------- */
// Used namespaces
/* -------------------------------------------------------------------------------------------------------------------- */

// Code defines
using Code_Defines;

// System namespaces
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

/* -------------------------------------------------------------------------------------------------------------------- */
// Main code
/* -------------------------------------------------------------------------------------------------------------------- */

namespace Serial_Logger
{
    /* ---------------------------------------------------------------------------------------------------------------- */
    // Main class
    /* ---------------------------------------------------------------------------------------------------------------- */

    public partial class Form1 : Form
    {
        /* ------------------------------------------------------------------------------------------------------------ */
        // C# controller - Controller properties - Use to handle events
        /* ------------------------------------------------------------------------------------------------------------ */

        // Serial port open flag - Private
        private static bool _Serial_Port_Open = false;

        // New message received flag - Public property
        public bool Serial_Port_Open
        {
            get
            {
                // Return value of private flag
                return _Serial_Port_Open;
            }

            set
            {
                // Set value of private flag
                _Serial_Port_Open = value;

                // Call function to deal with variable change
                Controller_Serial_Changed();
            }
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // C# controller - Objetcs from other classes
        /* ------------------------------------------------------------------------------------------------------------ */

        // Connection variables - Initialized after FormMain components initialization
        private Connection_Class Connection;

        /* ------------------------------------------------------------------------------------------------------------ */
        // Global variables
        /* ------------------------------------------------------------------------------------------------------------ */

        // Real time log filepath
        private string _RTLog_File = null;
        public string RTLog_File
        {
            get
            {
                return _RTLog_File;
            }

            set 
            {
                _RTLog_File = value;

                if (value == null)
                {
                    RTLog_Checkbox_Enable.Enabled = false;
                    RTLog_Checkbox_Enable.Checked = false;
                }
                else
                    RTLog_Checkbox_Enable.Enabled = true;
            }
        }

        // Real time log enable flag
        public bool RTLog_Enabled = false;

        /* ---------------------------------------------------------------------------------------------------------------- */
        // Connection class
        /* ---------------------------------------------------------------------------------------------------------------- */

        private class Connection_Class
        {
            /* ------------------------------------------------------------------------------------------------------------ */
            // Variables
            /* ------------------------------------------------------------------------------------------------------------ */

            public char[] RX_Message;   // RX message buffer
            public char[] TX_Message;   // TX message buffer
            public uint RX_Total_I;     // RX messages counter - Integer format
            public uint TX_Total_I;     // TX messages counter - Integer format
            public DateTime RX_Last_I;  // Time of the last RX - Datetime format
            public DateTime TX_Last_I;  // Time of the last TX - Datetime format

            /* ------------------------------------------------------------------------------------------------------------ */
            // Properties - Readonly - Used to get formatted values of device variables
            /* ------------------------------------------------------------------------------------------------------------ */

            // RX messages counter property - Readonly string format
            public string RX_Total_S
            {
                get
                {
                    return (RX_Total_I.ToString());
                }
            }

            // TX messages counter property - Readonly string format
            public string TX_Total_S
            {
                get
                {
                    return (TX_Total_I.ToString());
                }
            }

            // Time of the last RX property - Readonly string format
            public string RX_Last_S
            {
                get
                {
                    if (RX_Last_I == DateTime.MinValue)
                        return "No data";
                    else
                        return Convert.ToString(RX_Last_I);
                }
            }

            // Time of the last TX property - Readonly string format
            public string TX_Last_S
            {
                get
                {
                    if (TX_Last_I == DateTime.MinValue)
                        return "No data";
                    else
                        return Convert.ToString(TX_Last_I);
                }
            }

            /* ------------------------------------------------------------------------------------------------------------ */
            // Constructor
            /* ------------------------------------------------------------------------------------------------------------ */

            public Connection_Class()
            {
                RX_Message = new char[Defines.RX_SIZE]; // RX message buffer
                TX_Message = new char[Defines.TX_SIZE]; // TX message buffer
                RX_Total_I = 0;                         // RX messages counter
                TX_Total_I = 0;                         // TX messages counter
                RX_Last_I = DateTime.MinValue;          // Time of the last RX
                TX_Last_I = DateTime.MinValue;          // Time of the last TX
            }
        }


        /* ------------------------------------------------------------------------------------------------------------ */
        // Main form initialization
        /* ------------------------------------------------------------------------------------------------------------ */

        public Form1()
        {
            // Initialize all components of form
            InitializeComponent();

            // Define '.' as decimal separator
            System.Globalization.CultureInfo customCulture =
                (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            // TODO: Make functions thread safe
            // Disable CrossThread check
            Control.CheckForIllegalCrossThreadCalls = false;

            /* -------------------------------------------------------------------------------------------------------- */
            
            // Search for COM ports and fill Connection_ComboBox_Port
            Connection_Button_Refresh_Click(this, new EventArgs());

            // Fill Connection_ComboBox_Baud
            Connection_ComboBox_Baud.Items.AddRange(Defines.BAUDS);
            Connection_ComboBox_Baud.SelectedItem = "115200";

            // Initialize Connection object
            Connection = new Connection_Class();

            /* -------------------------------------------------------------------------------------------------------- */

            Controller_Update_Connection();

            /* -------------------------------------------------------------------------------------------------------- */

            // Change window title
            this.Text = Defines.CODE_NAME;
            this.Text += " - v";
            this.Text += Defines.CODE_VERSION;
            this.Text += " - ";
            this.Text += "Not connected";
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Main form close
        /* ------------------------------------------------------------------------------------------------------------ */

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Serial port is open
            if (serialPort.IsOpen)
            {
                // Discard input buffer
                serialPort.DiscardInBuffer();

                // Close serial port
                serialPort.Close();
            }
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Connection_Button_Refresh button action
        /* ------------------------------------------------------------------------------------------------------------ */

        private void Connection_Button_Refresh_Click(object sender, EventArgs e)
        {
            // Remove all items from ComboBox_Ports
            Connection_ComboBox_Port.Items.Clear();

            // Search for available COM ports - Get port names and save in a list
            string[] Serial_Ports = SerialPort.GetPortNames();

            // Put each port in ComboBoxPorts
            foreach (string Port in Serial_Ports)
                Connection_ComboBox_Port.Items.Add(Port);

            // COM ports found
            if (Connection_ComboBox_Port.Items.Count > 0)
            {
                // Select first in the list
                Connection_ComboBox_Port.SelectedIndex = 0;

                // Enable connect button
                Connection_Button_Connect.Enabled = true;
            }

            // No COM ports found
            else
                // Disable button_Connect
                Connection_Button_Connect.Enabled = false;
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Connection_Button_Connect action
        /* ------------------------------------------------------------------------------------------------------------ */

        private void Connection_Button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                // If not connected
                if (!serialPort.IsOpen)
                {
                    // Check serial port definition
                    if (Connection_ComboBox_Port.Text == "")
                    {
                        // Show warning message
                        MessageBox.Show("Choose serial port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    // Define serial port
                    serialPort.PortName = Connection_ComboBox_Port.Text;

                    // Define baud rate
                    serialPort.BaudRate = Convert.ToInt32(Connection_ComboBox_Baud.Items[Connection_ComboBox_Baud.SelectedIndex]);

                    // Open serial port
                    serialPort.Open();

                    // Save port status
                    Serial_Port_Open = serialPort.IsOpen;
                }

                /* ---------------------------------------------------------------------------------------------------- */

                // Close connection if port is open
                else
                {
                    // Discard input buffer
                    serialPort.DiscardInBuffer();

                    // Close serial port
                    serialPort.Close();

                    // Save port status
                    Serial_Port_Open = serialPort.IsOpen;
                }
            }

            // Error
            catch (Exception MSG)
            {
                // Show warning message
                MessageBox.Show(MSG.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Serial changed function - Called every time "Serial_Port_Open" value is set
        /* ------------------------------------------------------------------------------------------------------------ */

        public void Controller_Serial_Changed()
        {
            // Serial port opended
            if (Serial_Port_Open == true)
            {
                // Disable Connection_Button_Refresh
                Connection_Button_Refresh.Enabled = false;

                // Disable Connection_ComboBox_Port
                Connection_ComboBox_Port.Enabled = false;

                // Disable Connection_ComboBox_Baud
                Connection_ComboBox_Baud.Enabled = false;

                // Change Connection_Button_Connect text
                Connection_Button_Connect.Text = "Disconnect";

                // Enable Cmd_Button_Send
                Cmd_Button_Send.Enabled = true;

                // Change window title
                this.Text = Defines.CODE_NAME;
                this.Text += " - v";
                this.Text += Defines.CODE_VERSION;
                this.Text += " - ";
                this.Text += "Connected - ";
                this.Text += serialPort.PortName;
            }

            // Serial port closed
            else
            {
                // Enable Connection_Button_Refresh
                Connection_Button_Refresh.Enabled = true;

                // Enable Connection_ComboBox_Port
                Connection_ComboBox_Port.Enabled = true;

                // Enable Connection_ComboBox_Baud
                Connection_ComboBox_Baud.Enabled = true;

                // Change Connection_Button_Connect text
                Connection_Button_Connect.Text = "Connect";

                // Disable Cmd_Button_Send
                Cmd_Button_Send.Enabled = false;

                // Change window title
                this.Text = Defines.CODE_NAME;
                this.Text += " - v";
                this.Text += Defines.CODE_VERSION;
                this.Text += " - ";
                this.Text += "Not connected";
            }
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Update view - Connection_groupBox
        /* ------------------------------------------------------------------------------------------------------------ */

        private void Controller_Update_Connection()
        {
            // Update RX textBoxes values
            Connection_TextBox_RX_Total.Text = Connection.RX_Total_S;
            Connection_TextBox_RX_Last.Text = Connection.RX_Last_S;

            // Update TX textBoxes values
            Connection_TextBox_TX_Total.Text = Connection.TX_Total_S;
            Connection_TextBox_TX_Last.Text = Connection.TX_Last_S;
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Data_Button_Erase action
        /* ------------------------------------------------------------------------------------------------------------ */

        private void Data_Button_Erase_Click(object sender, EventArgs e)
        {
            // Nothing to erase
            if ((Connection.RX_Total_I == 0) && (Connection.TX_Total_I == 0))
            {
                // Show warning message
                MessageBox.Show("No data to erase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // There is data to erase
            else
            {
                // Display confirmation message
                if (MessageBox.Show("Are you sure?", "Erase data", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Reset connection variables
                    Connection = new Connection_Class();

                    // Update view - Connection variables
                    Controller_Update_Connection();

                    /* ------------------------------------------------------------------------------------------------ */

                    // Erase log
                    Graph_RichTextBox_Log.Text = "";
                }
            }
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Data_Button_Export action
        /* ------------------------------------------------------------------------------------------------------------ */

        private void Data_Button_Export_Click(object sender, EventArgs e)
        {
            // Nothing to export
            if ((Connection.RX_Total_I == 0) && (Connection.TX_Total_I == 0))
            {
                // Show warning message
                MessageBox.Show("No data to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            // There is data to export
            else
            {
                // Prompt user to choose file
                SaveFileDialog Dialog = new SaveFileDialog
                {
                    Filter = "CSV files|*.csv",
                    Title = "Save data as csv file",
                    FileName = "Log.csv"
                };

                // Path path and filename are valid
                if ((Dialog.ShowDialog() == DialogResult.OK) && !string.IsNullOrWhiteSpace(Dialog.FileName))
                {
                    // Get export path and filename
                    string Export_File = Dialog.FileName;

                    // Try to export log
                    try
                    {
                        // Export log
                        System.IO.File.WriteAllLines(Export_File, Graph_RichTextBox_Log.Lines);

                        // Show warning message
                        MessageBox.Show("Data exported.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception MSG)
                    {
                        // Show warning message
                        MessageBox.Show(MSG.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Path or filename are invalid
                else
                    return;
            }
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // RTLog_Button_SetFile action
        /* ------------------------------------------------------------------------------------------------------------ */

        private void RTLog_Button_SetFile_Click(object sender, EventArgs e)
        {
            // Prompt user to choose file
            SaveFileDialog Dialog = new SaveFileDialog
            {
                Filter = "TXT files|*.txt",
                Title = "Save data as txt file",
                FileName = "Log.txt"
            };

            // Path path and filename are valid
            if ((Dialog.ShowDialog() == DialogResult.OK) && !string.IsNullOrWhiteSpace(Dialog.FileName))
            {
                // Get export path and filename
                RTLog_File = Dialog.FileName;
            }

            // Path or filename are invalid
            else
                RTLog_File = null;
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // RTLog_Checkbox_Enable_CheckedChanged action
        /* ------------------------------------------------------------------------------------------------------------ */

        private void RTLog_Checkbox_Enable_CheckedChanged(object sender, EventArgs e)
        {
            // Set real time log enable flag
            RTLog_Enabled = RTLog_Checkbox_Enable.Checked;
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Cmd_Button_Send action
        /* ------------------------------------------------------------------------------------------------------------ */

        private void Cmd_Button_Send_Click(object sender, EventArgs e)
        {
            // There is something to sent
            if (Cmd_TextBox.Text != "")
            {
                // Send data
                serialPort.Write(Cmd_TextBox.Text);

                // Grab TX time
                Connection.TX_Last_I = DateTime.Now;

                // Increase TX total message counter
                Connection.TX_Total_I++;

                // Update view - Connection_groupBox
                Controller_Update_Connection();

                // Update view - Log
                Controller_Update_Log("TX", Cmd_TextBox.Text);

                // Clear Cmd_TextBox
                Cmd_TextBox.Text = "";
            }

            // Textbox is empty
            else
            {
                // Show warning message
                MessageBox.Show("Nothing to send!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Cmd_Button_Clear action
        /* ------------------------------------------------------------------------------------------------------------ */

        private void Cmd_Button_Clear_Click(object sender, EventArgs e)
        {
            // Clear Cmd_TextBox
            Cmd_TextBox.Text = "";
        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Update view - Log
        /* ------------------------------------------------------------------------------------------------------------ */

        private void Controller_Update_Log(string Type, string Message)
        {
            string lineToAppend = null;

            // Log received message
            if (Type == "RX")
            {
                lineToAppend = "[" + Connection_TextBox_RX_Last.Text + " RX] ";

                // Append header to richTextBox_Log
                Graph_RichTextBox_Log.SelectionColor = Color.DodgerBlue;
                Graph_RichTextBox_Log.AppendText("[" + Connection_TextBox_RX_Last.Text + " RX] ");
            }

            // Log sent message
            else if (Type == "TX")
            {
                lineToAppend = "[" + Connection_TextBox_TX_Last.Text + " TX] ";

                // Append header to richTextBox_Log
                Graph_RichTextBox_Log.SelectionColor = Color.LimeGreen;
                Graph_RichTextBox_Log.AppendText("[" + Connection_TextBox_TX_Last.Text + " TX] ");
            }

            if (Message[Message.Length - 1] != '\n')
                Message += '\n';

            lineToAppend += Message;

            // Append message to richTextBox_Log
            Graph_RichTextBox_Log.SelectionColor = Color.Black;
            Graph_RichTextBox_Log.AppendText(Message);

            if (RTLog_Enabled)
            {
                try
                {
                    // Append last line of Connection_TextBox_RX_Last to RTLog_File
                    System.IO.File.AppendAllText(RTLog_File, lineToAppend);
                }
                catch (Exception MSG)
                {
                    // Show warning message
                    MessageBox.Show(MSG.Message, "Error appending data to log file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        /* ------------------------------------------------------------------------------------------------------------ */
        // Connection_SerialPort_DataReceived function
        /* ------------------------------------------------------------------------------------------------------------ */

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                // Read a line of serial buffer
                string Message = serialPort.ReadLine();

                // Grab RX time
                Connection.RX_Last_I = DateTime.Now;

                // Increase RX message counter
                Connection.RX_Total_I++;

                // Update view - Connection_groupBox
                Controller_Update_Connection();

                // Update view - Log
                Controller_Update_Log("RX", String.Concat(Message, "\r\n"));
            }
            catch (Exception MSG)
            {
                // Show warning message
                MessageBox.Show(MSG.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }
    }
}
