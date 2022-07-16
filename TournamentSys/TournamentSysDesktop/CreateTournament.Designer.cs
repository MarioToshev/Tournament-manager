namespace TournamentSysDesktop
{
    partial class CreateTournament
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LocationTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.decrTb = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.minPlayersNum = new System.Windows.Forms.NumericUpDown();
            this.maxPlayerNm = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.SystemTb = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minPlayersNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPlayerNm)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(571, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // startDate
            // 
            this.startDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startDate.Location = new System.Drawing.Point(125, 124);
            this.startDate.MinDate = new System.DateTime(2022, 6, 7, 22, 43, 5, 0);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 27);
            this.startDate.TabIndex = 3;
            this.startDate.Value = new System.DateTime(2022, 6, 7, 22, 43, 5, 0);
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.endDate.Location = new System.Drawing.Point(125, 166);
            this.endDate.MinDate = new System.DateTime(2022, 6, 7, 0, 0, 0, 0);
            this.endDate.MinimumSize = new System.Drawing.Size(1, 0);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 27);
            this.endDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(31, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(389, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description";
            // 
            // LocationTb
            // 
            this.LocationTb.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LocationTb.Location = new System.Drawing.Point(125, 208);
            this.LocationTb.Name = "LocationTb";
            this.LocationTb.Size = new System.Drawing.Size(200, 27);
            this.LocationTb.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(25, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Location";
            // 
            // decrTb
            // 
            this.decrTb.Location = new System.Drawing.Point(490, 144);
            this.decrTb.Name = "decrTb";
            this.decrTb.Size = new System.Drawing.Size(199, 122);
            this.decrTb.TabIndex = 4;
            this.decrTb.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minimum player count";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(25, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Max player count";
            // 
            // minPlayersNum
            // 
            this.minPlayersNum.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minPlayersNum.Location = new System.Drawing.Point(205, 293);
            this.minPlayersNum.Name = "minPlayersNum";
            this.minPlayersNum.Size = new System.Drawing.Size(120, 27);
            this.minPlayersNum.TabIndex = 5;
            // 
            // maxPlayerNm
            // 
            this.maxPlayerNm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxPlayerNm.Location = new System.Drawing.Point(205, 340);
            this.maxPlayerNm.Name = "maxPlayerNm";
            this.maxPlayerNm.Size = new System.Drawing.Size(120, 27);
            this.maxPlayerNm.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(269, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 28);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tournament";
            // 
            // SystemTb
            // 
            this.SystemTb.FormattingEnabled = true;
            this.SystemTb.Location = new System.Drawing.Point(125, 252);
            this.SystemTb.Name = "SystemTb";
            this.SystemTb.Size = new System.Drawing.Size(200, 23);
            this.SystemTb.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(25, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "System";
            // 
            // CreateTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 411);
            this.Controls.Add(this.SystemTb);
            this.Controls.Add(this.maxPlayerNm);
            this.Controls.Add(this.minPlayersNum);
            this.Controls.Add(this.decrTb);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LocationTb);
            this.Controls.Add(this.button1);
            this.Name = "CreateTournament";
            this.Text = "Create Tournament";
            ((System.ComponentModel.ISupportInitialize)(this.minPlayersNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPlayerNm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private DateTimePicker startDate;
        private DateTimePicker endDate;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox LocationTb;
        private Label label5;
        private RichTextBox decrTb;
        private Label label1;
        private Label label6;
        private NumericUpDown minPlayersNum;
        private NumericUpDown maxPlayerNm;
        private Label label7;
        private ComboBox SystemTb;
        private Label label8;
    }
}