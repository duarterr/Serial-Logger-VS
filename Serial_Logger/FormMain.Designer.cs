
namespace Serial_Logger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Connection_groupBox = new System.Windows.Forms.GroupBox();
            this.Connection_Label_Baud = new System.Windows.Forms.Label();
            this.Connection_ComboBox_Baud = new System.Windows.Forms.ComboBox();
            this.Connection_Label_TX_Last = new System.Windows.Forms.Label();
            this.Connection_TextBox_TX_Last = new System.Windows.Forms.TextBox();
            this.Connection_Label_RX_Last = new System.Windows.Forms.Label();
            this.Connection_TextBox_RX_Last = new System.Windows.Forms.TextBox();
            this.Connection_Label_TX_Total = new System.Windows.Forms.Label();
            this.Connection_TextBox_TX_Total = new System.Windows.Forms.TextBox();
            this.Connection_Label_RX_Total = new System.Windows.Forms.Label();
            this.Connection_TextBox_RX_Total = new System.Windows.Forms.TextBox();
            this.Connection_Label_Port = new System.Windows.Forms.Label();
            this.Connection_Button_Refresh = new System.Windows.Forms.Button();
            this.Connection_ComboBox_Port = new System.Windows.Forms.ComboBox();
            this.Connection_Button_Connect = new System.Windows.Forms.Button();
            this.Cmd_GroupBox = new System.Windows.Forms.GroupBox();
            this.Cmd_TextBox = new System.Windows.Forms.TextBox();
            this.Cmd_Button_Clear = new System.Windows.Forms.Button();
            this.Cmd_Button_Send = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.Graph_RichTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.Data_GroupBox = new System.Windows.Forms.GroupBox();
            this.Data_Button_Erase = new System.Windows.Forms.Button();
            this.Data_Button_Export = new System.Windows.Forms.Button();
            this.Log_GroupBox_Log = new System.Windows.Forms.GroupBox();
            this.Connection_groupBox.SuspendLayout();
            this.Cmd_GroupBox.SuspendLayout();
            this.Data_GroupBox.SuspendLayout();
            this.Log_GroupBox_Log.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connection_groupBox
            // 
            this.Connection_groupBox.Controls.Add(this.Connection_Label_Baud);
            this.Connection_groupBox.Controls.Add(this.Connection_ComboBox_Baud);
            this.Connection_groupBox.Controls.Add(this.Connection_Label_TX_Last);
            this.Connection_groupBox.Controls.Add(this.Connection_TextBox_TX_Last);
            this.Connection_groupBox.Controls.Add(this.Connection_Label_RX_Last);
            this.Connection_groupBox.Controls.Add(this.Connection_TextBox_RX_Last);
            this.Connection_groupBox.Controls.Add(this.Connection_Label_TX_Total);
            this.Connection_groupBox.Controls.Add(this.Connection_TextBox_TX_Total);
            this.Connection_groupBox.Controls.Add(this.Connection_Label_RX_Total);
            this.Connection_groupBox.Controls.Add(this.Connection_TextBox_RX_Total);
            this.Connection_groupBox.Controls.Add(this.Connection_Label_Port);
            this.Connection_groupBox.Controls.Add(this.Connection_Button_Refresh);
            this.Connection_groupBox.Controls.Add(this.Connection_ComboBox_Port);
            this.Connection_groupBox.Controls.Add(this.Connection_Button_Connect);
            this.Connection_groupBox.Location = new System.Drawing.Point(12, 12);
            this.Connection_groupBox.Name = "Connection_groupBox";
            this.Connection_groupBox.Size = new System.Drawing.Size(520, 75);
            this.Connection_groupBox.TabIndex = 1;
            this.Connection_groupBox.TabStop = false;
            this.Connection_groupBox.Text = "Connection";
            // 
            // Connection_Label_Baud
            // 
            this.Connection_Label_Baud.AutoSize = true;
            this.Connection_Label_Baud.Location = new System.Drawing.Point(6, 51);
            this.Connection_Label_Baud.Name = "Connection_Label_Baud";
            this.Connection_Label_Baud.Size = new System.Drawing.Size(35, 13);
            this.Connection_Label_Baud.TabIndex = 35;
            this.Connection_Label_Baud.Text = "Baud:";
            // 
            // Connection_ComboBox_Baud
            // 
            this.Connection_ComboBox_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Connection_ComboBox_Baud.FormattingEnabled = true;
            this.Connection_ComboBox_Baud.Location = new System.Drawing.Point(41, 46);
            this.Connection_ComboBox_Baud.Name = "Connection_ComboBox_Baud";
            this.Connection_ComboBox_Baud.Size = new System.Drawing.Size(80, 21);
            this.Connection_ComboBox_Baud.TabIndex = 34;
            // 
            // Connection_Label_TX_Last
            // 
            this.Connection_Label_TX_Last.AutoSize = true;
            this.Connection_Label_TX_Last.Location = new System.Drawing.Point(318, 51);
            this.Connection_Label_TX_Last.Name = "Connection_Label_TX_Last";
            this.Connection_Label_TX_Last.Size = new System.Drawing.Size(47, 13);
            this.Connection_Label_TX_Last.TabIndex = 33;
            this.Connection_Label_TX_Last.Text = "Last TX:";
            // 
            // Connection_TextBox_TX_Last
            // 
            this.Connection_TextBox_TX_Last.BackColor = System.Drawing.SystemColors.Window;
            this.Connection_TextBox_TX_Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connection_TextBox_TX_Last.Location = new System.Drawing.Point(371, 48);
            this.Connection_TextBox_TX_Last.Name = "Connection_TextBox_TX_Last";
            this.Connection_TextBox_TX_Last.ReadOnly = true;
            this.Connection_TextBox_TX_Last.Size = new System.Drawing.Size(140, 20);
            this.Connection_TextBox_TX_Last.TabIndex = 32;
            this.Connection_TextBox_TX_Last.TabStop = false;
            this.Connection_TextBox_TX_Last.Text = "NaN";
            this.Connection_TextBox_TX_Last.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Connection_Label_RX_Last
            // 
            this.Connection_Label_RX_Last.AutoSize = true;
            this.Connection_Label_RX_Last.Location = new System.Drawing.Point(317, 20);
            this.Connection_Label_RX_Last.Name = "Connection_Label_RX_Last";
            this.Connection_Label_RX_Last.Size = new System.Drawing.Size(48, 13);
            this.Connection_Label_RX_Last.TabIndex = 29;
            this.Connection_Label_RX_Last.Text = "Last RX:";
            // 
            // Connection_TextBox_RX_Last
            // 
            this.Connection_TextBox_RX_Last.BackColor = System.Drawing.SystemColors.Window;
            this.Connection_TextBox_RX_Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connection_TextBox_RX_Last.Location = new System.Drawing.Point(371, 17);
            this.Connection_TextBox_RX_Last.Name = "Connection_TextBox_RX_Last";
            this.Connection_TextBox_RX_Last.ReadOnly = true;
            this.Connection_TextBox_RX_Last.Size = new System.Drawing.Size(140, 20);
            this.Connection_TextBox_RX_Last.TabIndex = 28;
            this.Connection_TextBox_RX_Last.TabStop = false;
            this.Connection_TextBox_RX_Last.Text = "NaN";
            this.Connection_TextBox_RX_Last.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Connection_Label_TX_Total
            // 
            this.Connection_Label_TX_Total.AutoSize = true;
            this.Connection_Label_TX_Total.Location = new System.Drawing.Point(214, 51);
            this.Connection_Label_TX_Total.Name = "Connection_Label_TX_Total";
            this.Connection_Label_TX_Total.Size = new System.Drawing.Size(47, 13);
            this.Connection_Label_TX_Total.TabIndex = 24;
            this.Connection_Label_TX_Total.Text = "TX total:";
            // 
            // Connection_TextBox_TX_Total
            // 
            this.Connection_TextBox_TX_Total.BackColor = System.Drawing.SystemColors.Window;
            this.Connection_TextBox_TX_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connection_TextBox_TX_Total.Location = new System.Drawing.Point(267, 48);
            this.Connection_TextBox_TX_Total.Name = "Connection_TextBox_TX_Total";
            this.Connection_TextBox_TX_Total.ReadOnly = true;
            this.Connection_TextBox_TX_Total.Size = new System.Drawing.Size(45, 20);
            this.Connection_TextBox_TX_Total.TabIndex = 25;
            this.Connection_TextBox_TX_Total.TabStop = false;
            this.Connection_TextBox_TX_Total.Text = "NaN";
            this.Connection_TextBox_TX_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Connection_Label_RX_Total
            // 
            this.Connection_Label_RX_Total.AutoSize = true;
            this.Connection_Label_RX_Total.Location = new System.Drawing.Point(213, 20);
            this.Connection_Label_RX_Total.Name = "Connection_Label_RX_Total";
            this.Connection_Label_RX_Total.Size = new System.Drawing.Size(48, 13);
            this.Connection_Label_RX_Total.TabIndex = 22;
            this.Connection_Label_RX_Total.Text = "RX total:";
            // 
            // Connection_TextBox_RX_Total
            // 
            this.Connection_TextBox_RX_Total.BackColor = System.Drawing.SystemColors.Window;
            this.Connection_TextBox_RX_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connection_TextBox_RX_Total.Location = new System.Drawing.Point(267, 17);
            this.Connection_TextBox_RX_Total.Name = "Connection_TextBox_RX_Total";
            this.Connection_TextBox_RX_Total.ReadOnly = true;
            this.Connection_TextBox_RX_Total.Size = new System.Drawing.Size(45, 20);
            this.Connection_TextBox_RX_Total.TabIndex = 23;
            this.Connection_TextBox_RX_Total.TabStop = false;
            this.Connection_TextBox_RX_Total.Text = "NaN";
            this.Connection_TextBox_RX_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Connection_Label_Port
            // 
            this.Connection_Label_Port.AutoSize = true;
            this.Connection_Label_Port.Location = new System.Drawing.Point(6, 20);
            this.Connection_Label_Port.Name = "Connection_Label_Port";
            this.Connection_Label_Port.Size = new System.Drawing.Size(29, 13);
            this.Connection_Label_Port.TabIndex = 2;
            this.Connection_Label_Port.Text = "Port:";
            // 
            // Connection_Button_Refresh
            // 
            this.Connection_Button_Refresh.Location = new System.Drawing.Point(127, 14);
            this.Connection_Button_Refresh.Name = "Connection_Button_Refresh";
            this.Connection_Button_Refresh.Size = new System.Drawing.Size(80, 25);
            this.Connection_Button_Refresh.TabIndex = 1;
            this.Connection_Button_Refresh.Text = "Refresh";
            this.Connection_Button_Refresh.UseVisualStyleBackColor = true;
            this.Connection_Button_Refresh.Click += new System.EventHandler(this.Connection_Button_Refresh_Click);
            // 
            // Connection_ComboBox_Port
            // 
            this.Connection_ComboBox_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Connection_ComboBox_Port.FormattingEnabled = true;
            this.Connection_ComboBox_Port.Location = new System.Drawing.Point(41, 16);
            this.Connection_ComboBox_Port.Name = "Connection_ComboBox_Port";
            this.Connection_ComboBox_Port.Size = new System.Drawing.Size(80, 21);
            this.Connection_ComboBox_Port.TabIndex = 0;
            // 
            // Connection_Button_Connect
            // 
            this.Connection_Button_Connect.Enabled = false;
            this.Connection_Button_Connect.Location = new System.Drawing.Point(127, 44);
            this.Connection_Button_Connect.Name = "Connection_Button_Connect";
            this.Connection_Button_Connect.Size = new System.Drawing.Size(80, 25);
            this.Connection_Button_Connect.TabIndex = 2;
            this.Connection_Button_Connect.Text = "Connect";
            this.Connection_Button_Connect.UseVisualStyleBackColor = true;
            this.Connection_Button_Connect.Click += new System.EventHandler(this.Connection_Button_Connect_Click);
            // 
            // Cmd_GroupBox
            // 
            this.Cmd_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_GroupBox.Controls.Add(this.Cmd_TextBox);
            this.Cmd_GroupBox.Controls.Add(this.Cmd_Button_Clear);
            this.Cmd_GroupBox.Controls.Add(this.Cmd_Button_Send);
            this.Cmd_GroupBox.Location = new System.Drawing.Point(638, 12);
            this.Cmd_GroupBox.Name = "Cmd_GroupBox";
            this.Cmd_GroupBox.Size = new System.Drawing.Size(178, 75);
            this.Cmd_GroupBox.TabIndex = 5;
            this.Cmd_GroupBox.TabStop = false;
            this.Cmd_GroupBox.Text = "Send data";
            // 
            // Cmd_TextBox
            // 
            this.Cmd_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_TextBox.Location = new System.Drawing.Point(7, 16);
            this.Cmd_TextBox.Name = "Cmd_TextBox";
            this.Cmd_TextBox.Size = new System.Drawing.Size(164, 20);
            this.Cmd_TextBox.TabIndex = 0;
            // 
            // Cmd_Button_Clear
            // 
            this.Cmd_Button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_Button_Clear.Location = new System.Drawing.Point(6, 44);
            this.Cmd_Button_Clear.Name = "Cmd_Button_Clear";
            this.Cmd_Button_Clear.Size = new System.Drawing.Size(80, 25);
            this.Cmd_Button_Clear.TabIndex = 42;
            this.Cmd_Button_Clear.Text = "Clear";
            this.Cmd_Button_Clear.UseVisualStyleBackColor = true;
            this.Cmd_Button_Clear.Click += new System.EventHandler(this.Cmd_Button_Clear_Click);
            // 
            // Cmd_Button_Send
            // 
            this.Cmd_Button_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_Button_Send.Enabled = false;
            this.Cmd_Button_Send.Location = new System.Drawing.Point(92, 44);
            this.Cmd_Button_Send.Name = "Cmd_Button_Send";
            this.Cmd_Button_Send.Size = new System.Drawing.Size(80, 25);
            this.Cmd_Button_Send.TabIndex = 2;
            this.Cmd_Button_Send.Text = "Send";
            this.Cmd_Button_Send.UseVisualStyleBackColor = true;
            this.Cmd_Button_Send.Click += new System.EventHandler(this.Cmd_Button_Send_Click);
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // Graph_RichTextBox_Log
            // 
            this.Graph_RichTextBox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Graph_RichTextBox_Log.BackColor = System.Drawing.SystemColors.Window;
            this.Graph_RichTextBox_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Graph_RichTextBox_Log.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Graph_RichTextBox_Log.HideSelection = false;
            this.Graph_RichTextBox_Log.Location = new System.Drawing.Point(6, 19);
            this.Graph_RichTextBox_Log.Name = "Graph_RichTextBox_Log";
            this.Graph_RichTextBox_Log.ReadOnly = true;
            this.Graph_RichTextBox_Log.Size = new System.Drawing.Size(791, 281);
            this.Graph_RichTextBox_Log.TabIndex = 40;
            this.Graph_RichTextBox_Log.Text = "";
            // 
            // Data_GroupBox
            // 
            this.Data_GroupBox.Controls.Add(this.Data_Button_Erase);
            this.Data_GroupBox.Controls.Add(this.Data_Button_Export);
            this.Data_GroupBox.Location = new System.Drawing.Point(538, 12);
            this.Data_GroupBox.Name = "Data_GroupBox";
            this.Data_GroupBox.Size = new System.Drawing.Size(94, 75);
            this.Data_GroupBox.TabIndex = 41;
            this.Data_GroupBox.TabStop = false;
            this.Data_GroupBox.Text = "Data control";
            // 
            // Data_Button_Erase
            // 
            this.Data_Button_Erase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Data_Button_Erase.Location = new System.Drawing.Point(7, 14);
            this.Data_Button_Erase.Name = "Data_Button_Erase";
            this.Data_Button_Erase.Size = new System.Drawing.Size(80, 25);
            this.Data_Button_Erase.TabIndex = 1;
            this.Data_Button_Erase.Text = "Erase all data";
            this.Data_Button_Erase.UseVisualStyleBackColor = true;
            this.Data_Button_Erase.Click += new System.EventHandler(this.Data_Button_Erase_Click);
            // 
            // Data_Button_Export
            // 
            this.Data_Button_Export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Data_Button_Export.Location = new System.Drawing.Point(7, 44);
            this.Data_Button_Export.Name = "Data_Button_Export";
            this.Data_Button_Export.Size = new System.Drawing.Size(80, 25);
            this.Data_Button_Export.TabIndex = 2;
            this.Data_Button_Export.Text = "Export data";
            this.Data_Button_Export.UseVisualStyleBackColor = true;
            this.Data_Button_Export.Click += new System.EventHandler(this.Data_Button_Export_Click);
            // 
            // Log_GroupBox_Log
            // 
            this.Log_GroupBox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_GroupBox_Log.Controls.Add(this.Graph_RichTextBox_Log);
            this.Log_GroupBox_Log.Location = new System.Drawing.Point(13, 93);
            this.Log_GroupBox_Log.Name = "Log_GroupBox_Log";
            this.Log_GroupBox_Log.Size = new System.Drawing.Size(804, 306);
            this.Log_GroupBox_Log.TabIndex = 42;
            this.Log_GroupBox_Log.TabStop = false;
            this.Log_GroupBox_Log.Text = "Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 411);
            this.Controls.Add(this.Log_GroupBox_Log);
            this.Controls.Add(this.Data_GroupBox);
            this.Controls.Add(this.Cmd_GroupBox);
            this.Controls.Add(this.Connection_groupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Connection_groupBox.ResumeLayout(false);
            this.Connection_groupBox.PerformLayout();
            this.Cmd_GroupBox.ResumeLayout(false);
            this.Cmd_GroupBox.PerformLayout();
            this.Data_GroupBox.ResumeLayout(false);
            this.Log_GroupBox_Log.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Connection_groupBox;
        private System.Windows.Forms.Label Connection_Label_TX_Last;
        private System.Windows.Forms.TextBox Connection_TextBox_TX_Last;
        private System.Windows.Forms.Label Connection_Label_RX_Last;
        private System.Windows.Forms.TextBox Connection_TextBox_RX_Last;
        private System.Windows.Forms.Label Connection_Label_TX_Total;
        private System.Windows.Forms.TextBox Connection_TextBox_TX_Total;
        private System.Windows.Forms.Label Connection_Label_RX_Total;
        private System.Windows.Forms.TextBox Connection_TextBox_RX_Total;
        private System.Windows.Forms.Label Connection_Label_Port;
        private System.Windows.Forms.Button Connection_Button_Refresh;
        private System.Windows.Forms.ComboBox Connection_ComboBox_Port;
        private System.Windows.Forms.Button Connection_Button_Connect;
        private System.Windows.Forms.GroupBox Cmd_GroupBox;
        private System.Windows.Forms.TextBox Cmd_TextBox;
        private System.Windows.Forms.Button Cmd_Button_Clear;
        private System.Windows.Forms.Button Cmd_Button_Send;
        public System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.RichTextBox Graph_RichTextBox_Log;
        private System.Windows.Forms.GroupBox Data_GroupBox;
        private System.Windows.Forms.Button Data_Button_Erase;
        private System.Windows.Forms.Button Data_Button_Export;
        private System.Windows.Forms.Label Connection_Label_Baud;
        private System.Windows.Forms.ComboBox Connection_ComboBox_Baud;
        private System.Windows.Forms.GroupBox Log_GroupBox_Log;
    }
}

