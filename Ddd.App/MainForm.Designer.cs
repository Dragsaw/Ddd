﻿namespace Ddd.App
{
    partial class MainForm
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.rotateGroup = new System.Windows.Forms.GroupBox();
            this.rotateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.angleZ = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.angleY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.angleX = new System.Windows.Forms.NumericUpDown();
            this.createGroup = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.interpolationN = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.radius = new System.Windows.Forms.NumericUpDown();
            this.drawButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.length = new System.Windows.Forms.NumericUpDown();
            this.moveGroup = new System.Windows.Forms.GroupBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.moveZ = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.moveY = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.moveX = new System.Windows.Forms.NumericUpDown();
            this.scaleGroup = new System.Windows.Forms.GroupBox();
            this.scaleButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.scaleZ = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.scaleY = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.scaleX = new System.Windows.Forms.NumericUpDown();
            this.controlsTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.rotateGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleX)).BeginInit();
            this.createGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interpolationN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.length)).BeginInit();
            this.moveGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveX)).BeginInit();
            this.scaleGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).BeginInit();
            this.controlsTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(462, 415);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // rotateGroup
            // 
            this.rotateGroup.Controls.Add(this.rotateButton);
            this.rotateGroup.Controls.Add(this.label3);
            this.rotateGroup.Controls.Add(this.angleZ);
            this.rotateGroup.Controls.Add(this.label2);
            this.rotateGroup.Controls.Add(this.angleY);
            this.rotateGroup.Controls.Add(this.label1);
            this.rotateGroup.Controls.Add(this.angleX);
            this.rotateGroup.Location = new System.Drawing.Point(6, 109);
            this.rotateGroup.Name = "rotateGroup";
            this.rotateGroup.Size = new System.Drawing.Size(235, 74);
            this.rotateGroup.TabIndex = 1;
            this.rotateGroup.TabStop = false;
            this.rotateGroup.Text = "Поворот";
            // 
            // rotateButton
            // 
            this.rotateButton.Location = new System.Drawing.Point(147, 45);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(75, 23);
            this.rotateButton.TabIndex = 6;
            this.rotateButton.Text = "Повернуть";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.Rotate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z:";
            // 
            // angleZ
            // 
            this.angleZ.Location = new System.Drawing.Point(175, 19);
            this.angleZ.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.angleZ.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.angleZ.Name = "angleZ";
            this.angleZ.Size = new System.Drawing.Size(47, 20);
            this.angleZ.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y:";
            // 
            // angleY
            // 
            this.angleY.Location = new System.Drawing.Point(99, 19);
            this.angleY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.angleY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.angleY.Name = "angleY";
            this.angleY.Size = new System.Drawing.Size(47, 20);
            this.angleY.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:";
            // 
            // angleX
            // 
            this.angleX.Location = new System.Drawing.Point(26, 19);
            this.angleX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.angleX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.angleX.Name = "angleX";
            this.angleX.Size = new System.Drawing.Size(47, 20);
            this.angleX.TabIndex = 0;
            // 
            // createGroup
            // 
            this.createGroup.Controls.Add(this.label8);
            this.createGroup.Controls.Add(this.interpolationN);
            this.createGroup.Controls.Add(this.label7);
            this.createGroup.Controls.Add(this.radius);
            this.createGroup.Controls.Add(this.drawButton);
            this.createGroup.Controls.Add(this.label4);
            this.createGroup.Controls.Add(this.height);
            this.createGroup.Controls.Add(this.label5);
            this.createGroup.Controls.Add(this.width);
            this.createGroup.Controls.Add(this.label6);
            this.createGroup.Controls.Add(this.length);
            this.createGroup.Location = new System.Drawing.Point(6, 6);
            this.createGroup.Name = "createGroup";
            this.createGroup.Size = new System.Drawing.Size(235, 97);
            this.createGroup.TabIndex = 7;
            this.createGroup.TabStop = false;
            this.createGroup.Text = "Создание";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "n:";
            // 
            // interpolationN
            // 
            this.interpolationN.Location = new System.Drawing.Point(175, 42);
            this.interpolationN.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.interpolationN.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.interpolationN.Name = "interpolationN";
            this.interpolationN.Size = new System.Drawing.Size(47, 20);
            this.interpolationN.TabIndex = 9;
            this.interpolationN.Value = global::Ddd.App.Properties.Settings.Default.DefaultInterpolationN;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(126, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Радиус:";
            // 
            // radius
            // 
            this.radius.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Ddd.App.Properties.Settings.Default, "DefaultRadius", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.radius.Location = new System.Drawing.Point(175, 16);
            this.radius.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.radius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radius.Name = "radius";
            this.radius.Size = new System.Drawing.Size(47, 20);
            this.radius.TabIndex = 7;
            this.radius.Value = global::Ddd.App.Properties.Settings.Default.DefaultRadius;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(129, 68);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(93, 23);
            this.drawButton.TabIndex = 6;
            this.drawButton.Text = "Нарисовать";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.Create);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Высота:";
            // 
            // height
            // 
            this.height.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Ddd.App.Properties.Settings.Default, "DefaultHeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.height.Location = new System.Drawing.Point(58, 68);
            this.height.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(47, 20);
            this.height.TabIndex = 4;
            this.height.Value = global::Ddd.App.Properties.Settings.Default.DefaultHeight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ширина:";
            // 
            // width
            // 
            this.width.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Ddd.App.Properties.Settings.Default, "DefaultWidth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.width.Location = new System.Drawing.Point(58, 42);
            this.width.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(47, 20);
            this.width.TabIndex = 2;
            this.width.Value = global::Ddd.App.Properties.Settings.Default.DefaultWidth;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Длина:";
            // 
            // length
            // 
            this.length.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::Ddd.App.Properties.Settings.Default, "DefaultLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.length.Location = new System.Drawing.Point(58, 16);
            this.length.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.length.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(47, 20);
            this.length.TabIndex = 0;
            this.length.Value = global::Ddd.App.Properties.Settings.Default.DefaultLength;
            // 
            // moveGroup
            // 
            this.moveGroup.Controls.Add(this.moveButton);
            this.moveGroup.Controls.Add(this.label9);
            this.moveGroup.Controls.Add(this.moveZ);
            this.moveGroup.Controls.Add(this.label10);
            this.moveGroup.Controls.Add(this.moveY);
            this.moveGroup.Controls.Add(this.label11);
            this.moveGroup.Controls.Add(this.moveX);
            this.moveGroup.Location = new System.Drawing.Point(6, 189);
            this.moveGroup.Name = "moveGroup";
            this.moveGroup.Size = new System.Drawing.Size(235, 74);
            this.moveGroup.TabIndex = 7;
            this.moveGroup.TabStop = false;
            this.moveGroup.Text = "Перемещение";
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(129, 45);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(93, 23);
            this.moveButton.TabIndex = 6;
            this.moveButton.Text = "Переместить";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.Shift);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Z:";
            // 
            // moveZ
            // 
            this.moveZ.Location = new System.Drawing.Point(175, 19);
            this.moveZ.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.moveZ.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.moveZ.Name = "moveZ";
            this.moveZ.Size = new System.Drawing.Size(47, 20);
            this.moveZ.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Y:";
            // 
            // moveY
            // 
            this.moveY.Location = new System.Drawing.Point(99, 19);
            this.moveY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.moveY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.moveY.Name = "moveY";
            this.moveY.Size = new System.Drawing.Size(47, 20);
            this.moveY.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "X:";
            // 
            // moveX
            // 
            this.moveX.Location = new System.Drawing.Point(26, 19);
            this.moveX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.moveX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.moveX.Name = "moveX";
            this.moveX.Size = new System.Drawing.Size(47, 20);
            this.moveX.TabIndex = 0;
            // 
            // scaleGroup
            // 
            this.scaleGroup.Controls.Add(this.scaleButton);
            this.scaleGroup.Controls.Add(this.label12);
            this.scaleGroup.Controls.Add(this.scaleZ);
            this.scaleGroup.Controls.Add(this.label13);
            this.scaleGroup.Controls.Add(this.scaleY);
            this.scaleGroup.Controls.Add(this.label14);
            this.scaleGroup.Controls.Add(this.scaleX);
            this.scaleGroup.Location = new System.Drawing.Point(6, 269);
            this.scaleGroup.Name = "scaleGroup";
            this.scaleGroup.Size = new System.Drawing.Size(235, 74);
            this.scaleGroup.TabIndex = 8;
            this.scaleGroup.TabStop = false;
            this.scaleGroup.Text = "Масштаб";
            // 
            // scaleButton
            // 
            this.scaleButton.Location = new System.Drawing.Point(129, 45);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(93, 23);
            this.scaleButton.TabIndex = 6;
            this.scaleButton.Text = "Применить";
            this.scaleButton.UseVisualStyleBackColor = true;
            this.scaleButton.Click += new System.EventHandler(this.Scale);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(152, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Z:";
            // 
            // scaleZ
            // 
            this.scaleZ.DecimalPlaces = 1;
            this.scaleZ.Location = new System.Drawing.Point(175, 19);
            this.scaleZ.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.scaleZ.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.scaleZ.Name = "scaleZ";
            this.scaleZ.Size = new System.Drawing.Size(47, 20);
            this.scaleZ.TabIndex = 4;
            this.scaleZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(76, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Y:";
            // 
            // scaleY
            // 
            this.scaleY.DecimalPlaces = 1;
            this.scaleY.Location = new System.Drawing.Point(99, 19);
            this.scaleY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.scaleY.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.scaleY.Name = "scaleY";
            this.scaleY.Size = new System.Drawing.Size(47, 20);
            this.scaleY.TabIndex = 2;
            this.scaleY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "X:";
            // 
            // scaleX
            // 
            this.scaleX.DecimalPlaces = 1;
            this.scaleX.Location = new System.Drawing.Point(26, 19);
            this.scaleX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.scaleX.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.scaleX.Name = "scaleX";
            this.scaleX.Size = new System.Drawing.Size(47, 20);
            this.scaleX.TabIndex = 0;
            this.scaleX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // controlsTab
            // 
            this.controlsTab.Controls.Add(this.tabPage1);
            this.controlsTab.Controls.Add(this.tabPage2);
            this.controlsTab.Location = new System.Drawing.Point(480, 13);
            this.controlsTab.Name = "controlsTab";
            this.controlsTab.SelectedIndex = 0;
            this.controlsTab.Size = new System.Drawing.Size(255, 414);
            this.controlsTab.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.createGroup);
            this.tabPage1.Controls.Add(this.scaleGroup);
            this.tabPage1.Controls.Add(this.rotateGroup);
            this.tabPage1.Controls.Add(this.moveGroup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(247, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Рисование";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(247, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Проекции";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 439);
            this.Controls.Add(this.controlsTab);
            this.Controls.Add(this.canvas);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.rotateGroup.ResumeLayout(false);
            this.rotateGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleX)).EndInit();
            this.createGroup.ResumeLayout(false);
            this.createGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interpolationN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.length)).EndInit();
            this.moveGroup.ResumeLayout(false);
            this.moveGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveX)).EndInit();
            this.scaleGroup.ResumeLayout(false);
            this.scaleGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleX)).EndInit();
            this.controlsTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.GroupBox rotateGroup;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown angleZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown angleY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown angleX;
        private System.Windows.Forms.GroupBox createGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown interpolationN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown radius;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown length;
        private System.Windows.Forms.GroupBox moveGroup;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown moveZ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown moveY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown moveX;
        private System.Windows.Forms.GroupBox scaleGroup;
        private System.Windows.Forms.Button scaleButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown scaleZ;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown scaleY;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown scaleX;
        private System.Windows.Forms.TabControl controlsTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}