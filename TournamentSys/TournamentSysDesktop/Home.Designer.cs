namespace TournamentSysDesktop
{
    partial class Home
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
            this.manageUsersBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.AddTournament = new System.Windows.Forms.Button();
            this.SholGamesBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.TournamentsLb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // manageUsersBtn
            // 
            this.manageUsersBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.manageUsersBtn.Location = new System.Drawing.Point(603, 76);
            this.manageUsersBtn.Name = "manageUsersBtn";
            this.manageUsersBtn.Size = new System.Drawing.Size(148, 57);
            this.manageUsersBtn.TabIndex = 0;
            this.manageUsersBtn.Text = "Manage Users";
            this.manageUsersBtn.UseVisualStyleBackColor = true;
            this.manageUsersBtn.Click += new System.EventHandler(this.manageUsersBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "All Tournaments";
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editBtn.Location = new System.Drawing.Point(603, 139);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(148, 57);
            this.editBtn.TabIndex = 0;
            this.editBtn.Text = "Edit ";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // AddTournament
            // 
            this.AddTournament.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddTournament.Location = new System.Drawing.Point(603, 202);
            this.AddTournament.Name = "AddTournament";
            this.AddTournament.Size = new System.Drawing.Size(148, 57);
            this.AddTournament.TabIndex = 0;
            this.AddTournament.Text = "Add Tournament";
            this.AddTournament.UseVisualStyleBackColor = true;
            this.AddTournament.Click += new System.EventHandler(this.AddTournament_Click);
            // 
            // SholGamesBtn
            // 
            this.SholGamesBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SholGamesBtn.Location = new System.Drawing.Point(603, 312);
            this.SholGamesBtn.Name = "SholGamesBtn";
            this.SholGamesBtn.Size = new System.Drawing.Size(148, 57);
            this.SholGamesBtn.TabIndex = 0;
            this.SholGamesBtn.Text = "Show Games";
            this.SholGamesBtn.UseVisualStyleBackColor = true;
            this.SholGamesBtn.Click += new System.EventHandler(this.ShowGamesBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.refreshBtn.Location = new System.Drawing.Point(603, 375);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(148, 57);
            this.refreshBtn.TabIndex = 0;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // TournamentsLb
            // 
            this.TournamentsLb.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TournamentsLb.FormattingEnabled = true;
            this.TournamentsLb.ItemHeight = 19;
            this.TournamentsLb.Location = new System.Drawing.Point(12, 165);
            this.TournamentsLb.Name = "TournamentsLb";
            this.TournamentsLb.Size = new System.Drawing.Size(511, 213);
            this.TournamentsLb.TabIndex = 5;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TournamentsLb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.SholGamesBtn);
            this.Controls.Add(this.AddTournament);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.manageUsersBtn);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button manageUsersBtn;
        private Label label1;
        private Button editBtn;
        private Button AddTournament;
        private Button SholGamesBtn;
        private Button refreshBtn;
        private ListBox TournamentsLb;
    }
}