namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.buttonMelody = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.radioButtonSingleBell = new System.Windows.Forms.RadioButton();
            this.radioButtonSheduleBell = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.labelDateX = new System.Windows.Forms.Label();
            this.checkBoxWeekdays = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(299, 38);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(124, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Завести будильник";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.buttonStart.Enabled = !Form1.isStarted;
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(30, 83);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(157, 13);
            this.labelFilePath.TabIndex = 2;
            this.labelFilePath.Text = "Выберите сигнал будильника";
            // 
            // buttonMelody
            // 
            this.buttonMelody.Location = new System.Drawing.Point(299, 103);
            this.buttonMelody.Name = "buttonMelody";
            this.buttonMelody.Size = new System.Drawing.Size(124, 23);
            this.buttonMelody.TabIndex = 3;
            this.buttonMelody.Text = "Выбрать сигнал";
            this.buttonMelody.UseVisualStyleBackColor = true;
            this.buttonMelody.Click += new System.EventHandler(this.buttonMelody_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Пн",
            "Вт",
            "Ср",
            "Чт",
            "Пт",
            "Сб",
            "Вс"});
            this.checkedListBox1.Location = new System.Drawing.Point(33, 185);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(45, 109);
            this.checkedListBox1.TabIndex = 18;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Пн",
            "Вт",
            "Ср",
            "Чт",
            "Пт",
            "Сб",
            "Вс"});
            this.checkedListBox2.Location = new System.Drawing.Point(94, 185);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(45, 109);
            this.checkedListBox2.TabIndex = 19;
            // 
            // radioButtonSingleBell
            // 
            this.radioButtonSingleBell.AutoSize = true;
            this.radioButtonSingleBell.Checked = true;
            this.radioButtonSingleBell.Location = new System.Drawing.Point(33, 109);
            this.radioButtonSingleBell.Name = "radioButtonSingleBell";
            this.radioButtonSingleBell.Size = new System.Drawing.Size(120, 17);
            this.radioButtonSingleBell.TabIndex = 22;
            this.radioButtonSingleBell.TabStop = true;
            this.radioButtonSingleBell.Text = "Одиночный сигнал";
            this.radioButtonSingleBell.UseVisualStyleBackColor = true;
            // 
            // radioButtonSheduleBell
            // 
            this.radioButtonSheduleBell.AutoSize = true;
            this.radioButtonSheduleBell.Location = new System.Drawing.Point(33, 132);
            this.radioButtonSheduleBell.Name = "radioButtonSheduleBell";
            this.radioButtonSheduleBell.Size = new System.Drawing.Size(141, 17);
            this.radioButtonSheduleBell.TabIndex = 23;
            this.radioButtonSheduleBell.TabStop = true;
            this.radioButtonSheduleBell.Text = "Сигнал по расписанию";
            this.radioButtonSheduleBell.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(155, 32);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 24;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(205, 32);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown2.TabIndex = 25;
            // 
            // labelDateX
            // 
            this.labelDateX.AutoSize = true;
            this.labelDateX.Location = new System.Drawing.Point(190, 267);
            this.labelDateX.Name = "labelDateX";
            this.labelDateX.Size = new System.Drawing.Size(128, 13);
            this.labelDateX.TabIndex = 26;
            this.labelDateX.Text = "Задайте время сигнала";
            // 
            // checkBoxWeekdays
            // 
            this.checkBoxWeekdays.AutoSize = true;
            this.checkBoxWeekdays.Location = new System.Drawing.Point(94, 156);
            this.checkBoxWeekdays.Name = "checkBoxWeekdays";
            this.checkBoxWeekdays.Size = new System.Drawing.Size(89, 17);
            this.checkBoxWeekdays.TabIndex = 27;
            this.checkBoxWeekdays.Text = "Рабочие дни";
            this.checkBoxWeekdays.UseVisualStyleBackColor = true;
            this.checkBoxWeekdays.CheckedChanged += new System.EventHandler(this.checkBoxWeekdays_CheckedChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(299, 211);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(124, 23);
            this.buttonStop.TabIndex = 28;
            this.buttonStop.Text = "Сбросить будильник";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            this.buttonStop.Enabled = Form1.isStarted;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 348);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.checkBoxWeekdays);
            this.Controls.Add(this.labelDateX);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.radioButtonSheduleBell);
            this.Controls.Add(this.radioButtonSingleBell);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.buttonMelody);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Button buttonMelody;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton radioButtonSingleBell;
        private System.Windows.Forms.Label labelDateX;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.NumericUpDown numericUpDown2;
        public System.Windows.Forms.RadioButton radioButtonSheduleBell;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.CheckBox checkBoxWeekdays;
        private System.Windows.Forms.Button buttonStop;
    }
}

