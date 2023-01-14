using Core;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using System.Numerics;

namespace KompasWrapper
{
    /// <summary>
    /// Класс осуществляющий построение детали
    /// </summary>
    public class IceMoldBuilder
    {
        /// <summary>
        /// Объект класса конектора для связи с КОММПАС-3D
        /// </summary>
        private KompasConnector _connector;

        /// <summary>
        /// Объект класса параметра для построение детали
        /// </summary>
        private IceMoldParameters _parameters;

        /// <summary>
        /// Глубина для формы
        /// </summary>
        private const int IceCubeDeep = 5;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parameters">Параметры киянки</param>
        /// <param name="connector">Объект для связи с КОМПАС-3D</param>
        public IceMoldBuilder(IceMoldParameters parameters,
            KompasConnector connector)
        {
            _parameters = parameters;
            _connector = connector;
        }

        /// <summary>
        /// Метод строящий форму для льда
        /// </summary>
        // TODO: грам ошибка
        public void BuilIceMold()
        {
            _connector.Start();
            _connector.CreateDocument3D();

            IceBase(_parameters.IceMoldLength, _parameters.IceMoldWidth, _parameters.ExternalWall, _parameters.IceMoldDeep);
            IceCube(_parameters.IceMoldLength, _parameters.IceMoldWidth, _parameters.ExternalWall, _parameters.InnerWall, _parameters.IceMoldDeep,
                _parameters.IceMoldBottom, _parameters.CellsLengthCount, _parameters.CellsWidthCount);

        }

        /// <summary>
        /// Метод осуществляющий построения отверстий для льда
        /// </summary>
        /// <param name="length">Длина формы</param>
        /// <param name="width">Ширина формы</param>
        /// <param name="externalWall">Толищина внешней стенки</param>
        /// <param name="innerWall">Толищина внутренней стенки</param>
        /// <param name="deep">Глубина формы</param>
        /// <param name="bottom">Толщина дна</param>
        /// <param name="cellsWidthCount">Количество ячеек на ширину формы</param>
        /// <param name="cellsLengthCount">Количество ячеек на длину формы</param>
        private void IceCube(double length, double width, double externalWall, double innerWall, double deep, double bottom, int cellsWidthCount, int cellsLengthCount)
        {
            //Расчёт рабочей зоны для ячеек
            double workingAreaWidth = width - (externalWall * 2);
            double workingAreaLength = length - (externalWall * 2);

            //Расчёт занимаемого места внутренними стенками
            double InnerWallWidth = (cellsWidthCount + 1) * innerWall;
            double InnerWallLength = (cellsLengthCount + 1) * innerWall;

            //Рассчёт размеров одной ячейки
            double cellsWidth = (workingAreaWidth - InnerWallWidth) / cellsWidthCount;
            double cellsLength = (workingAreaLength - InnerWallLength) / cellsLengthCount;

            var sketchIce = _connector.CreateSketch(Obj3dType.o3d_planeXOZ);
            var doc2dIce = (ksDocument2D)sketchIce.BeginEdit();
      
            //Построение ячеек
            for (int i = 0; i < cellsLengthCount; i++)
            {
                for (int j = 0; j < cellsWidthCount; j++)
                {
                    doc2dIce.ksRectangle(_connector.DrawRectangle(externalWall + innerWall * (i + 1) + cellsLength * i, externalWall + 
                        innerWall * (j+1) + cellsWidth * j, cellsWidth, cellsLength));
                }
            }
            sketchIce.EndEdit();
            _connector.СreateCutExtrusion(sketchIce, deep - bottom, 0);

        }

        /// <summary>
        /// Метод осуществляющий построение основания для формы
        /// </summary>
        /// <param name="length">Длина формы</param>
        /// <param name="width">Ширина формы</param>
        /// <param name="external">Внешняя стенка</param>
        /// <param name="deep">Глубина формы</param>
        private void IceBase(double length, double width, double external, double deep)
        {
            var sketch = _connector.CreateSketch(Obj3dType.o3d_planeXOZ);
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            doc2d.ksRectangle(_connector.DrawRectangle(0, 0, width, length));
            sketch.EndEdit();
            _connector.СreateExtrusion(sketch, deep);

            var sketchOuter = _connector.CreateSketch(Obj3dType.o3d_planeXOZ);
            var doc2dOut = (ksDocument2D)sketchOuter.BeginEdit();
            doc2dOut.ksRectangle(_connector.DrawRectangle(external, external, width - external * 2, length - external * 2));
            sketchOuter.EndEdit();
            _connector.СreateCutExtrusion(sketchOuter, IceCubeDeep, 0);

            var handleOffsetPlane = _connector.CreateOffsetPlane(Obj3dType.o3d_planeXOZ,
                deep/2);
            var handlesSketch = _connector.CreateSketch(Obj3dType.o3d_planeXOZ, handleOffsetPlane);
            var handelsDoc2d = (ksDocument2D)handlesSketch.BeginEdit();

            handelsDoc2d.ksLineSeg(0, width / 2 - width / 10, -deep / 2, width / 2 - width / 10, 1);
            handelsDoc2d.ksLineSeg(-deep/2, width / 2 - width / 10, -deep / 2, width / 2 + width / 10, 1);
            handelsDoc2d.ksLineSeg(0, width / 2 + width / 10, -deep / 2, width / 2 + width / 10, 1);

            handelsDoc2d.ksLineSeg(length, width / 2 - width / 10, length + deep / 2, width / 2 - width / 10, 1);
            handelsDoc2d.ksLineSeg(length + deep / 2, width / 2 - width / 10, length + deep / 2, width / 2 + width / 10, 1);
            handelsDoc2d.ksLineSeg(length, width / 2 + width / 10, length + deep / 2, width / 2 + width / 10, 1);

            handlesSketch.EndEdit();
            _connector.СreateExtrusionThin(handlesSketch, deep / 5);
        }
    }
}
