using System;
using System.Windows.Forms;

namespace RocketProject
{
    public partial class RocketForm : Form
    {
        private readonly RocketBuilder _rocket;

        /// <summary>
        /// Ввод параметров
        /// </summary>
        public RocketForm()
        {
            InitializeComponent();

            _rocket = new RocketBuilder();

            rocketLengthParameterControl.Parameter = _rocket.RocketParameters.GetParameter(ParameterType.RocketLength);
            secondStageLengthParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.SecondStageLength);
            firstStageLengthParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.FirstStageLength);
            secondStageDiameterParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.SecondStageDiameter);
            firstStageDiameterParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.FirstStageDiameter);
            secondStabilizerSpanParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.SecondStabilizerSpan);
            firstStabilizerSpanParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.FirstStabilizerSpan);
            secondStabilizerCountParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.SecondStabilizerCount);
            firstStabilizerCountParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.FirstStabilizerCount);
            stabilizerWidthParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.StabilizerWidth);
            nozzleDiameterParameterControl.Parameter =
                _rocket.RocketParameters.GetParameter(ParameterType.NozzleDiameter);
        }

        /// <summary>
        /// Выбор материала конструкции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buildButton_Click(object sender, EventArgs e)
        {
            if (noneRadioButton.Checked)
                _rocket.Build(RocketBuildStyle.None);
            else if (metalRadioButton.Checked)
                _rocket.Build(RocketBuildStyle.Metal);
            else if (colorRadioButton.Checked)
                _rocket.Build(RocketBuildStyle.Color);
        }

        /// <summary>
        /// Валидация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stabilizerCountParameterControl_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var rocketParameterControl = (RocketParameterControl) sender;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (rocketParameterControl.Parameter.Value%2 != 0)
            {
                rocketParameterControl.Parameter.Value += 1;
            }
        }
    }
}
