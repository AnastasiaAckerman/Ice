using System;
using Core;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class IceMoldParametersTest
    {
        /// <summary>
        /// Свойство возвращающее новый обект класса MalletParameters
        /// </summary>
        private IceMoldParameters DefaultParameters =>
            new();

        /// <summary>
        /// Словарь имён и максимальных значений параметров
        /// </summary>
        private readonly Dictionary<IceMoldParameterType, int>
            _maxValuesOfParameterDictionary =
                new()
                {
                    {
                        IceMoldParameterType.IceMoldLength,
                        IceMoldParameters.MaxIceMoldLength
                    },
                    {
                        IceMoldParameterType.IceMoldWidth,
                        IceMoldParameters.MaxIceMoldWidth
                    },
                    {
                        IceMoldParameterType.IceMoldDeep,
                        IceMoldParameters.MaxIceMoldDeep
                    },
                    {
                        IceMoldParameterType.ExternalWall,
                        IceMoldParameters.MaxExternalWall
                    },
                    {
                        IceMoldParameterType.InnerWall,
                        IceMoldParameters.MaxInnerWall
                    },
                    {
                        IceMoldParameterType.IceMoldBottom,
                        IceMoldParameters.MaxIceMoldBottom
                    },
                    {
                        IceMoldParameterType.CellsWidthCount,
                        IceMoldParameters.MaxCellsWidthCount
                    },
                    {
                        IceMoldParameterType.CellsLengthCount,
                        IceMoldParameters.MaxCellsLengthCount
                    }
                };

        [Test(Description = "Тест метода передающий значение "
                            + "в сеттер параметра по его имени")]
        public void TestSetParameterByName()
        {
            var testScrewParameters = DefaultParameters;

            foreach (var parameterMaxValue
                     in _maxValuesOfParameterDictionary)
            {
                testScrewParameters.SetParameterByName(
                    parameterMaxValue.Key, parameterMaxValue.Value);
            }

            int errorCounter = 0;

            foreach (var parameterMaxValue
                     in _maxValuesOfParameterDictionary)
            {
                if (testScrewParameters.GetParameterValueByName(
                        parameterMaxValue.Key) != parameterMaxValue.Value)
                {
                    errorCounter++;
                }
            }

            Assert.That(errorCounter, Is.Zero,
                "Значения не были помещены в сеттеры параметров");
        }

        [Test(Description = "Тест на геттер значения параметра по имени")]
        public void TestGetParameterByName()
        {
            var testScrewParameters = DefaultParameters;

            var newValue = (IceMoldParameters.MinIceMoldLength
                            + IceMoldParameters.MinIceMoldLength) / 2;
            IceMoldParameterType testParameterName =
                IceMoldParameterType.IceMoldLength;
            testScrewParameters
                .SetParameterByName(testParameterName, newValue);

            Assert.That(testScrewParameters
                    .GetParameterValueByName(testParameterName), Is.EqualTo(newValue),
                "Из геттера вернулось неверное значение");
        }

        [Test(Description = "Позитивный тест на геттеры параметров")]
        public void TestParameterGet()
        {
            var testScrewParameters = DefaultParameters;

            foreach (var parameterMaxValue
                     in _maxValuesOfParameterDictionary)
            {
                testScrewParameters.SetParameterByName(
                    parameterMaxValue.Key, parameterMaxValue.Value);
            }

            Assert.That(testScrewParameters.IceMoldDeep
                          == IceMoldParameters.MaxIceMoldDeep
                          && testScrewParameters.ExternalWall
                          == IceMoldParameters.MaxExternalWall
                          && testScrewParameters.InnerWall
                          == IceMoldParameters.MaxInnerWall
                          && testScrewParameters.IceMoldBottom
                          == IceMoldParameters.MaxIceMoldBottom
                          && testScrewParameters.CellsWidthCount
                          == IceMoldParameters.MaxCellsWidthCount
                          && testScrewParameters.CellsLengthCount
                          == IceMoldParameters.MaxCellsLengthCount, Is.True,
                "Возникает, если геттер вернул не то значение");
        }

        [Test(Description = "Тест на сеттер ширины формы")]
        public void TestIceMollWidth_Set()
        {
            var testScrewParameters = DefaultParameters;

            testScrewParameters.IceMoldLength = IceMoldParameters.MaxIceMoldLength;
            testScrewParameters.IceMoldWidth = IceMoldParameters.MaxIceMoldLength
                + IceMoldParameters.IceMoldDifference;
            testScrewParameters.IceMoldWidth = IceMoldParameters.MinIceMoldWidth;

            Assert.That(testScrewParameters.IceMoldLength, Is.EqualTo(IceMoldParameters.MinIceMoldWidth
                - IceMoldParameters.IceMoldDifference),
                "Сеттер не поменял знаечние зависимого параметра");
        }

        [Test(Description = "Тест на сеттер длины формы")]
        public void TestIceMoldLength_Set()
        {
            var testScrewParameters = DefaultParameters;

            testScrewParameters.IceMoldLength = IceMoldParameters.MaxIceMoldLength;
            testScrewParameters.IceMoldWidth = IceMoldParameters.MaxIceMoldLength
                + IceMoldParameters.IceMoldDifference;
            testScrewParameters.IceMoldLength = IceMoldParameters.MinIceMoldLength;

            Assert.That(testScrewParameters.IceMoldWidth, Is.EqualTo(IceMoldParameters.MinIceMoldLength
                + IceMoldParameters.IceMoldDifference),
                "Сеттер не поменял знаечние зависимого параметра");
        }
    }
}