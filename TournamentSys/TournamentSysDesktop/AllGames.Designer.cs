namespace TournamentSysDesktop
{
    partial class AllGames
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
            this.label1 = new System.Windows.Forms.Label();
            this.firstPlayerScore = new System.Windows.Forms.TextBox();
            this.SecondPlayerScore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addScore = new System.Windows.Forms.Button();
            this.Gameslb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tournament Games";
            // 
            // firstPlayerScore
            // 
            this.firstPlayerScore.Location = new System.Drawing.Point(659, 175);
            this.firstPlayerScore.Name = "firstPlayerScore";
            this.firstPlayerScore.Size = new System.Drawing.Size(100, 23);
            this.firstPlayerScore.TabIndex = 2;
            // 
            // SecondPlayerScore
            // 
            this.SecondPlayerScore.Location = new System.Drawing.Point(659, 228);
            this.SecondPlayerScore.Name = "SecondPlayerScore";
            this.SecondPlayerScore.Size = new System.Drawing.Size(100, 23);
            this.SecondPlayerScore.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(513, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "First player score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(512, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Second Player score";
            // 
            // addScore
            // 
            this.addScore.Location = new System.Drawing.Point(647, 351);
            this.addScore.Name = "addScore";
            this.addScore.Size = new System.Drawing.Size(112, 40);
            this.addScore.TabIndex = 4;
            this.addScore.Text = "Add Score";
            this.addScore.UseVisualStyleBackColor = true;
            this.addScore.Click += new System.EventHandler(this.addScore_Click);
            // 
            // Gameslb
            // 
            this.Gameslb.FormattingEnabled = true;
            this.Gameslb.ItemHeight = 15;
            this.Gameslb.Location = new System.Drawing.Point(22, 207);
            this.Gameslb.Name = "Gameslb";
            this.Gameslb.Size = new System.Drawing.Size(427, 184);
            this.Gameslb.TabIndex = 5;
            // 
            // AllGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Gameslb);
            this.Controls.Add(this.addScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SecondPlayerScore);
            this.Controls.Add(this.firstPlayerScore);
            this.Controls.Add(this.label1);
            this.Name = "AllGames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Games";
            this.Load += new System.EventHandler(this.GamesRobinRound_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox firstPlayerScore;
        private TextBox SecondPlayerScore;
        private Label label2;
        private Label label3;
        private Button addScore;
        private ListBox Gameslb;
    }
}