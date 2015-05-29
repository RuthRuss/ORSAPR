namespace RocketProject
{
    partial class RocketParameterControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.minValueLabel = new System.Windows.Forms.Label();
            this.maxValueLabel = new System.Windows.Forms.Label();
            this.valueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.parametrDescriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // minValueLabel
            // 
            this.minValueLabel.AutoSize = true;
            this.minValueLabel.Location = new System.Drawing.Point(177, 2);
            this.minValueLabel.Name = "minValueLabel";
            this.minValueLabel.Size = new System.Drawing.Size(35, 13);
            this.minValueLabel.TabIndex = 2;
            this.minValueLabel.Text = "label2";
            // 
            // maxValueLabel
            // 
            this.maxValueLabel.AutoSize = true;
            this.maxValueLabel.Location = new System.Drawing.Point(363, 2);
            this.maxValueLabel.Name = "maxValueLabel";
            this.maxValueLabel.Size = new System.Drawing.Size(35, 13);
            this.maxValueLabel.TabIndex = 4;
            this.maxValueLabel.Text = "label4";
            // 
            // valueNumericUpDown
            // 
            this.valueNumericUpDown.Location = new System.Drawing.Point(247, 0);
            this.valueNumericUpDown.Name = "valueNumericUpDown";
            this.valueNumericUpDown.Size = new System.Drawing.Size(96, 20);
            this.valueNumericUpDown.TabIndex = 7;
            this.valueNumericUpDown.ValueChanged += new System.EventHandler(this.valueNumericUpDown_ValueChanged);
            // 
            // parametrDescriptionLabel
            // 
            this.parametrDescriptionLabel.AutoSize = true;
            this.parametrDescriptionLabel.Location = new System.Drawing.Point(3, 2);
            this.parametrDescriptionLabel.Name = "parametrDescriptionLabel";
            this.parametrDescriptionLabel.Size = new System.Drawing.Size(35, 13);
            this.parametrDescriptionLabel.TabIndex = 9;
            this.parametrDescriptionLabel.Text = "label1";
            // 
            // RocketParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.parametrDescriptionLabel);
            this.Controls.Add(this.valueNumericUpDown);
            this.Controls.Add(this.maxValueLabel);
            this.Controls.Add(this.minValueLabel);
            this.Name = "RocketParameterControl";
            this.Size = new System.Drawing.Size(402, 20);
            ((System.ComponentModel.ISupportInitialize)(this.valueNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label minValueLabel;
        private System.Windows.Forms.Label maxValueLabel;
        private System.Windows.Forms.NumericUpDown valueNumericUpDown;
        private System.Windows.Forms.Label parametrDescriptionLabel;
    }
}
