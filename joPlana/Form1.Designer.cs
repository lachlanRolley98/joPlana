namespace joPlana
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.recapText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hi = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.planText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.submitDayNow = new System.Windows.Forms.Button();
            this.submitDayDate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.viewDayButton = new System.Windows.Forms.Button();
            this.viewWeekButton = new System.Windows.Forms.Button();
            this.viewMonthButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            this.SuspendLayout();
            // 
            // recapText
            // 
            this.recapText.Location = new System.Drawing.Point(12, 124);
            this.recapText.Multiline = true;
            this.recapText.Name = "recapText";
            this.recapText.Size = new System.Drawing.Size(463, 201);
            this.recapText.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // hi
            // 
            this.hi.AutoSize = true;
            this.hi.Location = new System.Drawing.Point(407, 44);
            this.hi.Name = "hi";
            this.hi.Size = new System.Drawing.Size(50, 15);
            this.hi.TabIndex = 7;
            this.hi.Text = "initialise";
            this.hi.Click += new System.EventHandler(this.label2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(90, 494);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(259, 45);
            this.trackBar1.TabIndex = 12;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(487, 124);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Journal";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Recap";
            // 
            // planText
            // 
            this.planText.Location = new System.Drawing.Point(12, 375);
            this.planText.Multiline = true;
            this.planText.Name = "planText";
            this.planText.Size = new System.Drawing.Size(463, 58);
            this.planText.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 357);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tomorrow Plan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 494);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Exercise";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 545);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Diet";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 596);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Time Wasting";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 647);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Subs";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 698);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Fam";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(90, 545);
            this.trackBar2.Maximum = 4;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(259, 45);
            this.trackBar2.TabIndex = 23;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(90, 596);
            this.trackBar3.Maximum = 4;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(259, 45);
            this.trackBar3.TabIndex = 24;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(90, 647);
            this.trackBar4.Maximum = 4;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(259, 45);
            this.trackBar4.TabIndex = 25;
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(90, 698);
            this.trackBar5.Maximum = 4;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(259, 45);
            this.trackBar5.TabIndex = 26;
            // 
            // submitDayNow
            // 
            this.submitDayNow.Location = new System.Drawing.Point(509, 302);
            this.submitDayNow.Name = "submitDayNow";
            this.submitDayNow.Size = new System.Drawing.Size(75, 70);
            this.submitDayNow.TabIndex = 27;
            this.submitDayNow.Text = "Submit Today";
            this.submitDayNow.UseVisualStyleBackColor = true;
            this.submitDayNow.Click += new System.EventHandler(this.submitDayNow_Click);
            // 
            // submitDayDate
            // 
            this.submitDayDate.Location = new System.Drawing.Point(617, 302);
            this.submitDayDate.Name = "submitDayDate";
            this.submitDayDate.Size = new System.Drawing.Size(75, 70);
            this.submitDayDate.TabIndex = 28;
            this.submitDayDate.Text = "Submit Date";
            this.submitDayDate.UseVisualStyleBackColor = true;
            this.submitDayDate.Click += new System.EventHandler(this.submitDayDate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 749);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 15);
            this.label11.TabIndex = 29;
            this.label11.Text = "Anx";
            // 
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(90, 749);
            this.trackBar6.Maximum = 4;
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(259, 45);
            this.trackBar6.TabIndex = 30;
            // 
            // viewDayButton
            // 
            this.viewDayButton.Location = new System.Drawing.Point(509, 399);
            this.viewDayButton.Name = "viewDayButton";
            this.viewDayButton.Size = new System.Drawing.Size(183, 45);
            this.viewDayButton.TabIndex = 31;
            this.viewDayButton.Text = "View Day";
            this.viewDayButton.UseVisualStyleBackColor = true;
            this.viewDayButton.Click += new System.EventHandler(this.viewDayButton_Click);
            // 
            // viewWeekButton
            // 
            this.viewWeekButton.Location = new System.Drawing.Point(509, 530);
            this.viewWeekButton.Name = "viewWeekButton";
            this.viewWeekButton.Size = new System.Drawing.Size(183, 45);
            this.viewWeekButton.TabIndex = 32;
            this.viewWeekButton.Text = "View Week";
            this.viewWeekButton.UseVisualStyleBackColor = true;
            // 
            // viewMonthButton
            // 
            this.viewMonthButton.Location = new System.Drawing.Point(509, 464);
            this.viewMonthButton.Name = "viewMonthButton";
            this.viewMonthButton.Size = new System.Drawing.Size(183, 45);
            this.viewMonthButton.TabIndex = 33;
            this.viewMonthButton.Text = "View Month";
            this.viewMonthButton.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(355, 596);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 19);
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "Blue";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(355, 634);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(57, 19);
            this.checkBox2.TabIndex = 35;
            this.checkBox2.Text = "Green";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(355, 673);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(60, 19);
            this.checkBox3.TabIndex = 37;
            this.checkBox3.Text = "Yellow";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(355, 711);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(65, 19);
            this.checkBox4.TabIndex = 38;
            this.checkBox4.Text = "Orange";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(355, 749);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(46, 19);
            this.checkBox5.TabIndex = 39;
            this.checkBox5.Text = "Red";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1495, 818);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.viewMonthButton);
            this.Controls.Add(this.viewWeekButton);
            this.Controls.Add(this.viewDayButton);
            this.Controls.Add(this.trackBar6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.submitDayDate);
            this.Controls.Add(this.submitDayNow);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.planText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.hi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.recapText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox recapText;
        private Button button1;
        private Label hi;
        private TrackBar trackBar1;
        private MonthCalendar monthCalendar1;
        private Label label1;
        private Label label4;
        private TextBox planText;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private BindingSource bindingSource1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private TrackBar trackBar4;
        private TrackBar trackBar5;
        private Button submitDayNow;
        private Button submitDayDate;
        private Label label11;
        private TrackBar trackBar6;
        private Button viewDayButton;
        private Button viewWeekButton;
        private Button viewMonthButton;
        private ColorDialog colorDialog1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
    }
}