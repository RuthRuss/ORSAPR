namespace RocketProject
{
    partial class RocketForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buildButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.styleGroupBox = new System.Windows.Forms.GroupBox();
            this.colorRadioButton = new System.Windows.Forms.RadioButton();
            this.metalRadioButton = new System.Windows.Forms.RadioButton();
            this.noneRadioButton = new System.Windows.Forms.RadioButton();
            this.nozzleDiameterParameterControl = new RocketProject.RocketParameterControl();
            this.stabilizerWidthParameterControl = new RocketProject.RocketParameterControl();
            this.firstStabilizerCountParameterControl = new RocketProject.RocketParameterControl();
            this.secondStabilizerCountParameterControl = new RocketProject.RocketParameterControl();
            this.firstStabilizerSpanParameterControl = new RocketProject.RocketParameterControl();
            this.secondStabilizerSpanParameterControl = new RocketProject.RocketParameterControl();
            this.firstStageDiameterParameterControl = new RocketProject.RocketParameterControl();
            this.secondStageDiameterParameterControl = new RocketProject.RocketParameterControl();
            this.firstStageLengthParameterControl = new RocketProject.RocketParameterControl();
            this.secondStageLengthParameterControl = new RocketProject.RocketParameterControl();
            this.rocketLengthParameterControl = new RocketProject.RocketParameterControl();
            this.groupBox2.SuspendLayout();
            this.styleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(47, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Параметры построение модели ракеты  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(13, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 36);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(251, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 214);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(6, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Значение:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(353, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Макс. (мм)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(260, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Выбранное";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(163, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Мин. (мм)";
            // 
            // buildButton
            // 
            this.buildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildButton.Location = new System.Drawing.Point(272, 405);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(156, 50);
            this.buildButton.TabIndex = 14;
            this.buildButton.Text = "Построение";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(138, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "TAURUS-TOMAHAWK:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // styleGroupBox
            // 
            this.styleGroupBox.Controls.Add(this.colorRadioButton);
            this.styleGroupBox.Controls.Add(this.metalRadioButton);
            this.styleGroupBox.Controls.Add(this.noneRadioButton);
            this.styleGroupBox.Location = new System.Drawing.Point(12, 405);
            this.styleGroupBox.Name = "styleGroupBox";
            this.styleGroupBox.Size = new System.Drawing.Size(254, 50);
            this.styleGroupBox.TabIndex = 27;
            this.styleGroupBox.TabStop = false;
            this.styleGroupBox.Text = "Материал";
            // 
            // colorRadioButton
            // 
            this.colorRadioButton.AutoSize = true;
            this.colorRadioButton.Location = new System.Drawing.Point(184, 20);
            this.colorRadioButton.Name = "colorRadioButton";
            this.colorRadioButton.Size = new System.Drawing.Size(50, 17);
            this.colorRadioButton.TabIndex = 2;
            this.colorRadioButton.TabStop = true;
            this.colorRadioButton.Text = "Цвет";
            this.colorRadioButton.UseVisualStyleBackColor = true;
            // 
            // metalRadioButton
            // 
            this.metalRadioButton.AutoSize = true;
            this.metalRadioButton.Location = new System.Drawing.Point(115, 20);
            this.metalRadioButton.Name = "metalRadioButton";
            this.metalRadioButton.Size = new System.Drawing.Size(63, 17);
            this.metalRadioButton.TabIndex = 1;
            this.metalRadioButton.TabStop = true;
            this.metalRadioButton.Text = "Металл";
            this.metalRadioButton.UseVisualStyleBackColor = true;
            // 
            // noneRadioButton
            // 
            this.noneRadioButton.AutoSize = true;
            this.noneRadioButton.Checked = true;
            this.noneRadioButton.Location = new System.Drawing.Point(7, 20);
            this.noneRadioButton.Name = "noneRadioButton";
            this.noneRadioButton.Size = new System.Drawing.Size(102, 17);
            this.noneRadioButton.TabIndex = 0;
            this.noneRadioButton.TabStop = true;
            this.noneRadioButton.Text = "Без материала";
            this.noneRadioButton.UseVisualStyleBackColor = true;
            // 
            // nozzleDiameterParameterControl
            // 
            this.nozzleDiameterParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nozzleDiameterParameterControl.Location = new System.Drawing.Point(13, 379);
            this.nozzleDiameterParameterControl.Name = "nozzleDiameterParameterControl";
            this.nozzleDiameterParameterControl.Parameter = null;
            this.nozzleDiameterParameterControl.ParameterDescription = "Толщина сопла ракеты:";
            this.nozzleDiameterParameterControl.Size = new System.Drawing.Size(418, 20);
            this.nozzleDiameterParameterControl.TabIndex = 25;
            // 
            // stabilizerWidthParameterControl
            // 
            this.stabilizerWidthParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stabilizerWidthParameterControl.Location = new System.Drawing.Point(13, 352);
            this.stabilizerWidthParameterControl.Name = "stabilizerWidthParameterControl";
            this.stabilizerWidthParameterControl.Parameter = null;
            this.stabilizerWidthParameterControl.ParameterDescription = "Толщина стабилизаторов:";
            this.stabilizerWidthParameterControl.Size = new System.Drawing.Size(418, 20);
            this.stabilizerWidthParameterControl.TabIndex = 24;
            // 
            // firstStabilizerCountParameterControl
            // 
            this.firstStabilizerCountParameterControl.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.firstStabilizerCountParameterControl.Location = new System.Drawing.Point(13, 325);
            this.firstStabilizerCountParameterControl.Name = "firstStabilizerCountParameterControl";
            this.firstStabilizerCountParameterControl.Parameter = null;
            this.firstStabilizerCountParameterControl.ParameterDescription = "Кол-во стабил. первое ступени:";
            this.firstStabilizerCountParameterControl.Size = new System.Drawing.Size(418, 20);
            this.firstStabilizerCountParameterControl.TabIndex = 23;
            this.firstStabilizerCountParameterControl.Validating += new System.ComponentModel.CancelEventHandler(this.stabilizerCountParameterControl_Validating);
            // 
            // secondStabilizerCountParameterControl
            // 
            this.secondStabilizerCountParameterControl.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.secondStabilizerCountParameterControl.Location = new System.Drawing.Point(13, 299);
            this.secondStabilizerCountParameterControl.Name = "secondStabilizerCountParameterControl";
            this.secondStabilizerCountParameterControl.Parameter = null;
            this.secondStabilizerCountParameterControl.ParameterDescription = "Кол-во стабил. второй ступени:";
            this.secondStabilizerCountParameterControl.Size = new System.Drawing.Size(418, 20);
            this.secondStabilizerCountParameterControl.TabIndex = 22;
            this.secondStabilizerCountParameterControl.Validating += new System.ComponentModel.CancelEventHandler(this.stabilizerCountParameterControl_Validating);
            // 
            // firstStabilizerSpanParameterControl
            // 
            this.firstStabilizerSpanParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.firstStabilizerSpanParameterControl.Location = new System.Drawing.Point(13, 272);
            this.firstStabilizerSpanParameterControl.Name = "firstStabilizerSpanParameterControl";
            this.firstStabilizerSpanParameterControl.Parameter = null;
            this.firstStabilizerSpanParameterControl.ParameterDescription = "Размах стабил. первой ступени:";
            this.firstStabilizerSpanParameterControl.Size = new System.Drawing.Size(418, 20);
            this.firstStabilizerSpanParameterControl.TabIndex = 21;
            // 
            // secondStabilizerSpanParameterControl
            // 
            this.secondStabilizerSpanParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondStabilizerSpanParameterControl.Location = new System.Drawing.Point(13, 246);
            this.secondStabilizerSpanParameterControl.Name = "secondStabilizerSpanParameterControl";
            this.secondStabilizerSpanParameterControl.Parameter = null;
            this.secondStabilizerSpanParameterControl.ParameterDescription = "Размах стабил. второй ступени:";
            this.secondStabilizerSpanParameterControl.Size = new System.Drawing.Size(418, 20);
            this.secondStabilizerSpanParameterControl.TabIndex = 20;
            // 
            // firstStageDiameterParameterControl
            // 
            this.firstStageDiameterParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.firstStageDiameterParameterControl.Location = new System.Drawing.Point(13, 219);
            this.firstStageDiameterParameterControl.Name = "firstStageDiameterParameterControl";
            this.firstStageDiameterParameterControl.Parameter = null;
            this.firstStageDiameterParameterControl.ParameterDescription = "Диаметр первой ступени:";
            this.firstStageDiameterParameterControl.Size = new System.Drawing.Size(418, 20);
            this.firstStageDiameterParameterControl.TabIndex = 19;
            // 
            // secondStageDiameterParameterControl
            // 
            this.secondStageDiameterParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondStageDiameterParameterControl.Location = new System.Drawing.Point(13, 193);
            this.secondStageDiameterParameterControl.Name = "secondStageDiameterParameterControl";
            this.secondStageDiameterParameterControl.Parameter = null;
            this.secondStageDiameterParameterControl.ParameterDescription = "Диаметр второй ступени:";
            this.secondStageDiameterParameterControl.Size = new System.Drawing.Size(418, 20);
            this.secondStageDiameterParameterControl.TabIndex = 18;
            // 
            // firstStageLengthParameterControl
            // 
            this.firstStageLengthParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.firstStageLengthParameterControl.Location = new System.Drawing.Point(13, 167);
            this.firstStageLengthParameterControl.Name = "firstStageLengthParameterControl";
            this.firstStageLengthParameterControl.Parameter = null;
            this.firstStageLengthParameterControl.ParameterDescription = "Высота первой ступени:";
            this.firstStageLengthParameterControl.Size = new System.Drawing.Size(418, 20);
            this.firstStageLengthParameterControl.TabIndex = 17;
            // 
            // secondStageLengthParameterControl
            // 
            this.secondStageLengthParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.secondStageLengthParameterControl.Location = new System.Drawing.Point(13, 140);
            this.secondStageLengthParameterControl.Name = "secondStageLengthParameterControl";
            this.secondStageLengthParameterControl.Parameter = null;
            this.secondStageLengthParameterControl.ParameterDescription = "Высота второй ступени:";
            this.secondStageLengthParameterControl.Size = new System.Drawing.Size(418, 20);
            this.secondStageLengthParameterControl.TabIndex = 16;
            // 
            // rocketLengthParameterControl
            // 
            this.rocketLengthParameterControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rocketLengthParameterControl.Location = new System.Drawing.Point(13, 113);
            this.rocketLengthParameterControl.Name = "rocketLengthParameterControl";
            this.rocketLengthParameterControl.Parameter = null;
            this.rocketLengthParameterControl.ParameterDescription = "Высота ракеты:";
            this.rocketLengthParameterControl.Size = new System.Drawing.Size(418, 20);
            this.rocketLengthParameterControl.TabIndex = 15;
            // 
            // RocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 467);
            this.Controls.Add(this.styleGroupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nozzleDiameterParameterControl);
            this.Controls.Add(this.stabilizerWidthParameterControl);
            this.Controls.Add(this.firstStabilizerCountParameterControl);
            this.Controls.Add(this.secondStabilizerCountParameterControl);
            this.Controls.Add(this.firstStabilizerSpanParameterControl);
            this.Controls.Add(this.secondStabilizerSpanParameterControl);
            this.Controls.Add(this.firstStageDiameterParameterControl);
            this.Controls.Add(this.secondStageDiameterParameterControl);
            this.Controls.Add(this.firstStageLengthParameterControl);
            this.Controls.Add(this.secondStageLengthParameterControl);
            this.Controls.Add(this.rocketLengthParameterControl);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RocketForm";
            this.Text = "Ракета TAURUS-TOMAHAWK";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.styleGroupBox.ResumeLayout(false);
            this.styleGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buildButton;
        private RocketParameterControl rocketLengthParameterControl;
        private RocketParameterControl secondStageLengthParameterControl;
        private RocketParameterControl secondStageDiameterParameterControl;
        private RocketParameterControl firstStageLengthParameterControl;
        private RocketParameterControl secondStabilizerSpanParameterControl;
        private RocketParameterControl firstStageDiameterParameterControl;
        private RocketParameterControl secondStabilizerCountParameterControl;
        private RocketParameterControl firstStabilizerSpanParameterControl;
        private RocketParameterControl stabilizerWidthParameterControl;
        private RocketParameterControl firstStabilizerCountParameterControl;
        private RocketParameterControl nozzleDiameterParameterControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox styleGroupBox;
        private System.Windows.Forms.RadioButton colorRadioButton;
        private System.Windows.Forms.RadioButton metalRadioButton;
        private System.Windows.Forms.RadioButton noneRadioButton;

    }
}