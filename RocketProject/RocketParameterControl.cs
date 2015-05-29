using System;
using System.Windows.Forms;

namespace RocketProject
{
    /// <summary>
    /// Контрол отображающий параметр  детали.
    /// </summary>
    public partial class RocketParameterControl : UserControl
    {
        /// <summary>
        /// Параметр детали.(поле)
        /// </summary>
        private Parameter _parameter; 

        private bool _updateInfoStarted;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public RocketParameterControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Описание параметра.
        /// </summary>
        public string ParameterDescription
        {
            get { return parametrDescriptionLabel.Text; }

            set { parametrDescriptionLabel.Text = value; }
        }

        /// <summary>
        /// Инкремент для поля значения параметра.
        /// </summary>
        public decimal Increment
        {
            get { return valueNumericUpDown.Increment; }

            set { valueNumericUpDown.Increment = value; }
        }

        /// <summary>
        /// Установить параметр детали в ValControl.
        /// </summary>
        public Parameter Parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter == value)
                    return;
                if (_parameter != null)
                    _parameter.ParameterChanged -= OnParameterChanged;
                if (value == null) 
                    return;
                value.ParameterChanged += OnParameterChanged;
                _parameter = value;
                UpdateInfo();
            }
        }

        /// <summary>
        /// Обработчик событий при изменении параметра.
        /// </summary>
        private void OnParameterChanged(object o, EventArgs e)
        {
            UpdateInfo();
        }

        /// <summary>
        /// Обновить данные в соответсвии с параметром.
        /// </summary>
        private void UpdateInfo()
        {
            _updateInfoStarted = true;
            valueNumericUpDown.Minimum = Convert.ToDecimal(_parameter.MinValue);
            valueNumericUpDown.Maximum = Convert.ToDecimal(_parameter.MaxValue);
            valueNumericUpDown.Value = Convert.ToDecimal(_parameter.Value);

            minValueLabel.Text = valueNumericUpDown.Minimum.ToString();
            maxValueLabel.Text = valueNumericUpDown.Maximum.ToString();
            _updateInfoStarted = false;
        }

        /// <summary>
        /// Обработчик срабатывает при изменении параметра пользователем в форме.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!_updateInfoStarted)
            {
                double value = Convert.ToDouble(valueNumericUpDown.Value);
                _parameter.Value = value;
            }
        }
    }
}
