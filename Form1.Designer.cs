
using System;

namespace Half_interval
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
			this.button1 = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.button2 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 107);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(292, 42);
			this.button1.TabIndex = 0;
			this.button1.Text = "Уточнить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 3;
			this.numericUpDown1.Location = new System.Drawing.Point(101, 1);
			this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(195, 29);
			this.numericUpDown1.TabIndex = 13;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.DecimalPlaces = 3;
			this.numericUpDown2.Location = new System.Drawing.Point(101, 37);
			this.numericUpDown2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(195, 29);
			this.numericUpDown2.TabIndex = 2;
			this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(15, 14);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(675, 630);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.DecimalPlaces = 10;
			this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numericUpDown3.Location = new System.Drawing.Point(101, 72);
			this.numericUpDown3.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(194, 29);
			this.numericUpDown3.TabIndex = 5;
			this.numericUpDown3.ThousandsSeparator = true;
			this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 21);
			this.label1.TabIndex = 6;
			this.label1.Text = "Максимум";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 21);
			this.label2.TabIndex = 7;
			this.label2.Text = "Минимум";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 21);
			this.label3.TabIndex = 8;
			this.label3.Text = "Ошибка";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 479);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(76, 21);
			this.label4.TabIndex = 9;
			this.label4.Text = "Масштаб";
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.Location = new System.Drawing.Point(102, 479);
			this.numericUpDown4.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(194, 29);
			this.numericUpDown4.TabIndex = 10;
			this.numericUpDown4.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(3, 514);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(292, 42);
			this.button2.TabIndex = 11;
			this.button2.Text = "Рисовать";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.HorizontalScrollbar = true;
			this.listBox1.ItemHeight = 21;
			this.listBox1.Location = new System.Drawing.Point(4, 190);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(292, 130);
			this.listBox1.TabIndex = 12;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(0, 155);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(292, 29);
			this.textBox1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button6);
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.trackBar1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.listBox1);
			this.panel1.Controls.Add(this.numericUpDown4);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.numericUpDown1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.numericUpDown2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.numericUpDown3);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(696, 14);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(302, 630);
			this.panel1.TabIndex = 14;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(76, 356);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(36, 31);
			this.button6.TabIndex = 18;
			this.button6.Text = "button6";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(76, 326);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(36, 31);
			this.button5.TabIndex = 17;
			this.button5.Text = "button5";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(112, 356);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(36, 31);
			this.button4.TabIndex = 16;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(44, 356);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(36, 31);
			this.button3.TabIndex = 15;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// trackBar1
			// 
			this.trackBar1.LargeChange = 6;
			this.trackBar1.Location = new System.Drawing.Point(2, 412);
			this.trackBar1.Maximum = 30;
			this.trackBar1.Minimum = 2;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(290, 61);
			this.trackBar1.SmallChange = 2;
			this.trackBar1.TabIndex = 14;
			this.trackBar1.TickFrequency = 2;
			this.trackBar1.Value = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1010, 664);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);

		}



		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
	}
}

