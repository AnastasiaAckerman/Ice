using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Core;
using KompasWrapper;

namespace IceMoldForm
{
    /// <summary>
    /// Класс хранящий и обрабатывающий пользовательский интерфейс плагина
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объект класса построителя
        /// </summary>
        private IceMoldBuilder _iceMoldBuiler;

        /// <summary>
        /// Объект класса с параметрами
        /// </summary>
        private IceMoldParameters _iceMoldParameters =
            new IceMoldParameters();

        /// <summary>
        /// Словарь содержащий пары (Текстбоксы, имя параметра)
        /// </summary>
        private Dictionary<TextBox, IceMoldParameterType> _textBoxesDictionary;

        /// <summary>
        /// Словарь содержащие пары (Текстбокс, корректное ли значение в нём)
        /// </summary>
        private Dictionary<TextBox, bool> _isValueInTextBoxCorrect;

        public MainForm()
        {
            InitializeComponent();

            _textBoxesDictionary = new Dictionary<TextBox, IceMoldParameterType>
            {
                {IceMoldLengthTextBox, IceMoldParameterType.IceMoldLength},
                {IceMoldWidthTextBox, IceMoldParameterType.IceMoldWidth},
                {IceMoldDeepTextBox, IceMoldParameterType.IceMoldDeep},
                {ExternalWallTextBox, IceMoldParameterType.ExternalWall},
                {InnerWallTextBox, IceMoldParameterType.InnerWall},
                {IceMoldBottomTextBox, IceMoldParameterType.IceMoldBottom},
                {CellsWidthCountTextBox, IceMoldParameterType.CellsWidthCount},
                {CellsLengthCountTextBox, IceMoldParameterType.CellsLengthCount},
            };

            _isValueInTextBoxCorrect = new Dictionary<TextBox, bool>
            {
                {IceMoldLengthTextBox, true},
                {IceMoldWidthTextBox, true},
                {IceMoldDeepTextBox, true},
                {ExternalWallTextBox, true},
                {InnerWallTextBox, true},
                {IceMoldBottomTextBox, true},
                {CellsWidthCountTextBox, true},
                {CellsLengthCountTextBox, true},
            };

            foreach (var textBox in _textBoxesDictionary)
            {
                textBox.Key.Text = _iceMoldParameters
                    .GetParameterValueByName(textBox.Value).ToString();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Построить"
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            var connector = new KompasConnector();
            _iceMoldBuiler =
                new IceMoldBuilder(_iceMoldParameters, connector);

            _iceMoldBuiler.BuilIceMold();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox)) return;

            Validating(textBox);
        }


        /// <summary>
        /// Общий метод валидации текстбокса
        /// </summary>
        private void Validating(TextBox textBox)
        {
            try
            {
                _textBoxesDictionary.TryGetValue(textBox,
                    out var parameterInTextBoxName);
                _iceMoldParameters.SetParameterByName(parameterInTextBoxName,
                    int.Parse(textBox.Text));

                if (textBox == IceMoldWidthTextBox)
                {
                    IceMoldLengthTextBox.Text =
                        _iceMoldParameters.IceMoldLength.ToString();
                }
                else if (textBox == IceMoldLengthTextBox)
                {
                    IceMoldWidthTextBox.Text =
                        _iceMoldParameters.IceMoldWidth.ToString();
                }

                //Значение в текстбоксе правильное
                _isValueInTextBoxCorrect[textBox] = true;
                bool isTextBoxesValuesCorrect = true;

                foreach (var isValueCorrect in _isValueInTextBoxCorrect)
                {
                    isTextBoxesValuesCorrect &= isValueCorrect.Value;
                }

                //Проверяем, можно ли активировать кнопку
                if (isTextBoxesValuesCorrect)
                {
                    BuildButton.Enabled = true;
                }
                textBox.BackColor = Color.White;
                toolTip.Active = false;
            }
            catch (Exception exception)
            {
                //Значение в текстбоксе неправильное
                BuildButton.Enabled = false;
                textBox.BackColor = Color.LightSalmon;
                toolTip.Active = true;
                toolTip.SetToolTip(textBox, exception.Message);
                _isValueInTextBoxCorrect[textBox] = false;
            }
        }
    }
}
