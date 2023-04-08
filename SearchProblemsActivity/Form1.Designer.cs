namespace SearchProblemsActivity
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
            this.Visualize = new System.Windows.Forms.Button();
            this.ClearBoard_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NoNode_label = new System.Windows.Forms.Label();
            this.VisitedCount_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Visualize button
            // 
            this.Visualize.BackColor = System.Drawing.Color.LavenderBlush;
            this.Visualize.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.Visualize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.Visualize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.Visualize.Location = new System.Drawing.Point(56, 27);
            this.Visualize.Margin = new System.Windows.Forms.Padding(2);
            this.Visualize.Name = "Visualize";
            this.Visualize.Size = new System.Drawing.Size(85, 22);
            this.Visualize.TabIndex = 2;
            this.Visualize.Text = "Start";
            this.Visualize.UseVisualStyleBackColor = false;
            this.Visualize.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // ClearBoard_button
            // 
            this.ClearBoard_button.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClearBoard_button.Location = new System.Drawing.Point(56, 53);
            this.ClearBoard_button.Margin = new System.Windows.Forms.Padding(2);
            this.ClearBoard_button.Name = "ClearBoard_button";
            this.ClearBoard_button.Size = new System.Drawing.Size(85, 22);
            this.ClearBoard_button.TabIndex = 3;
            this.ClearBoard_button.Text = "Clear Board";
            this.ClearBoard_button.UseVisualStyleBackColor = false;
            this.ClearBoard_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 112);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 240);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // NoNode_label
            // 
            this.NoNode_label.AutoSize = true;
            this.NoNode_label.Location = new System.Drawing.Point(231, 27);
            this.NoNode_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoNode_label.Name = "NoNode_label";
            this.NoNode_label.Size = new System.Drawing.Size(41, 13);
            this.NoNode_label.TabIndex = 10;
            this.NoNode_label.Text = "Nodes:";
            // 
            // VisitedCount_label
            // 
            this.VisitedCount_label.AutoSize = true;
            this.VisitedCount_label.Location = new System.Drawing.Point(231, 53);
            this.VisitedCount_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VisitedCount_label.Name = "VisitedCount_label";
            this.VisitedCount_label.Size = new System.Drawing.Size(41, 13);
            this.VisitedCount_label.TabIndex = 11;
            this.VisitedCount_label.Text = "Visited:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(495, 482);
            this.Controls.Add(this.VisitedCount_label);
            this.Controls.Add(this.NoNode_label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ClearBoard_button);
            this.Controls.Add(this.Visualize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "A* Path Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Visualize;
        private System.Windows.Forms.Button ClearBoard_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label NoNode_label;
        private System.Windows.Forms.Label VisitedCount_label;
        private System.Windows.Forms.Timer timer1;
    }
}

