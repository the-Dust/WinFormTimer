using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    partial class WinFormTimer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFormTimer));
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.buttonMelody = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.radioButtonSingleBell = new System.Windows.Forms.RadioButton();
            this.radioButtonSheduleBell = new System.Windows.Forms.RadioButton();
            this.labelDateX = new System.Windows.Forms.Label();
            this.checkBoxWeekdays = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.labelWeek1 = new System.Windows.Forms.Label();
            this.labelWeek2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(268, 161);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(124, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Завести будильник";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(6, 16);
            this.labelFilePath.MaximumSize = new System.Drawing.Size(400, 13);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(157, 13);
            this.labelFilePath.TabIndex = 2;
            this.labelFilePath.Text = "Выберите сигнал будильника";
            // 
            // buttonMelody
            // 
            this.buttonMelody.Location = new System.Drawing.Point(268, 119);
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
            this.checkedListBox1.Location = new System.Drawing.Point(12, 103);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(58, 109);
            this.checkedListBox1.TabIndex = 18;
            this.checkedListBox1.Visible = false;
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
            this.checkedListBox2.Location = new System.Drawing.Point(87, 103);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(58, 109);
            this.checkedListBox2.TabIndex = 19;
            this.checkedListBox2.Visible = false;
            // 
            // radioButtonSingleBell
            // 
            this.radioButtonSingleBell.AutoSize = true;
            this.radioButtonSingleBell.Checked = true;
            this.radioButtonSingleBell.Location = new System.Drawing.Point(12, 19);
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
            this.radioButtonSheduleBell.Location = new System.Drawing.Point(12, 42);
            this.radioButtonSheduleBell.Name = "radioButtonSheduleBell";
            this.radioButtonSheduleBell.Size = new System.Drawing.Size(141, 17);
            this.radioButtonSheduleBell.TabIndex = 23;
            this.radioButtonSheduleBell.TabStop = true;
            this.radioButtonSheduleBell.Text = "Сигнал по расписанию";
            this.radioButtonSheduleBell.UseVisualStyleBackColor = true;
            this.radioButtonSheduleBell.CheckedChanged += new System.EventHandler(this.radioButtonSheduleBell_CheckedChanged);
            // 
            // labelDateX
            // 
            this.labelDateX.AutoSize = true;
            this.labelDateX.Location = new System.Drawing.Point(7, 14);
            this.labelDateX.Name = "labelDateX";
            this.labelDateX.Size = new System.Drawing.Size(121, 13);
            this.labelDateX.TabIndex = 26;
            this.labelDateX.Text = "Будильник не заведен";
            // 
            // checkBoxWeekdays
            // 
            this.checkBoxWeekdays.AutoSize = true;
            this.checkBoxWeekdays.Location = new System.Drawing.Point(34, 65);
            this.checkBoxWeekdays.Name = "checkBoxWeekdays";
            this.checkBoxWeekdays.Size = new System.Drawing.Size(89, 17);
            this.checkBoxWeekdays.TabIndex = 27;
            this.checkBoxWeekdays.Text = "Рабочие дни";
            this.checkBoxWeekdays.UseVisualStyleBackColor = true;
            this.checkBoxWeekdays.Visible = false;
            this.checkBoxWeekdays.CheckedChanged += new System.EventHandler(this.checkBoxWeekdays_CheckedChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(268, 205);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(124, 23);
            this.buttonStop.TabIndex = 28;
            this.buttonStop.Text = "Сбросить будильник";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Будильник";
            // 
            // labelWeek1
            // 
            this.labelWeek1.AutoSize = true;
            this.labelWeek1.Location = new System.Drawing.Point(9, 86);
            this.labelWeek1.Name = "labelWeek1";
            this.labelWeek1.Size = new System.Drawing.Size(61, 13);
            this.labelWeek1.TabIndex = 29;
            this.labelWeek1.Text = "1-я неделя";
            this.labelWeek1.Visible = false;
            // 
            // labelWeek2
            // 
            this.labelWeek2.AutoSize = true;
            this.labelWeek2.Location = new System.Drawing.Point(84, 86);
            this.labelWeek2.Name = "labelWeek2";
            this.labelWeek2.Size = new System.Drawing.Size(61, 13);
            this.labelWeek2.TabIndex = 30;
            this.labelWeek2.Text = "2-я неделя";
            this.labelWeek2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "О программе";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox.Location = new System.Drawing.Point(11, 12);
            this.maskedTextBox.Mask = "00:00";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(102, 47);
            this.maskedTextBox.TabIndex = 32;
            this.maskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labelFilePath);
            this.groupBox1.Location = new System.Drawing.Point(11, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 35);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Мелодия сигнала";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonSingleBell);
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Controls.Add(this.checkedListBox2);
            this.groupBox2.Controls.Add(this.radioButtonSheduleBell);
            this.groupBox2.Controls.Add(this.checkBoxWeekdays);
            this.groupBox2.Controls.Add(this.labelWeek2);
            this.groupBox2.Controls.Add(this.labelWeek1);
            this.groupBox2.Location = new System.Drawing.Point(11, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 220);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расписание сигналов";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelDateX);
            this.groupBox3.Location = new System.Drawing.Point(130, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 47);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Статус будильника";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(398, 349);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonMelody);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.maskedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Будильник";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            this.Resize += this.Form_Resize;

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Button buttonMelody;
        public System.Windows.Forms.RadioButton radioButtonSheduleBell;
        public System.Windows.Forms.CheckedListBox checkedListBox1;
        public System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.CheckBox checkBoxWeekdays;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private Label labelWeek1;
        private Label labelWeek2;
        private Label label1;
        public MaskedTextBox maskedTextBox;
        public OpenFileDialog openFileDialog1;
        public Label labelDateX;
        public RadioButton radioButtonSingleBell;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}

