using System;
using Kompas6API5;
using Kompas6Constants3D;
using System.Runtime.InteropServices;

namespace KompasWrapper
{
    /// <summary>
    /// Класс связи с КОМПАС-3D через API
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект интерфейса API КОМПАС-3D
        /// </summary>
        private KompasObject _object;

        /// <summary>
        /// Компонент сборки
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Свойство возвращающее объект интерфейса API
        /// </summary>
        public KompasObject Object => _object;

        /// <summary>
        /// Строковое наименование идентификатора COM-объекта
        /// </summary>
        private const string Kompas3dProgId = "KOMPAS.Application.5";

        /// <summary>
        /// Свойство возвращающее компонент сборки
        /// </summary>
        public ksPart Part => _part;

        /// <summary>
        /// Метод начала работы КОМПАС-3D
        /// </summary>
        public void Start()
        {
            if (!IsKompasActive(out var kompas))
            {
                if (!IsKompasOpen(out kompas))
                {
                    throw new ArgumentException("Не удалось "
                                                + "открыть КОМПАС-3D.");
                }
            }

            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            _object = kompas;
        }

        /// <summary>
        /// Делает окно КОМПАС-3D активным
        /// </summary>
        /// <param name="kompas">Объект КОМПАС-3D</param>
        /// <returns>Является ли активным</returns>
        private bool IsKompasActive(out KompasObject kompas)
        {
            kompas = null;

            try
            {
                kompas = (KompasObject)Marshal.
                    GetActiveObject(Kompas3dProgId);
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }

        /// <summary>
        /// Метод запускает КОМПАС-3D
        /// </summary>
        /// <param name="kompas">Объект КОМПАС-3D</param>
        /// <returns>Является ли запущенным</returns>
        private bool IsKompasOpen(out KompasObject kompas)
        {
            try
            {
                var kompasType = Type.GetTypeFromProgID(Kompas3dProgId);
                kompas = (KompasObject)Activator.CreateInstance(kompasType);
                return true;
            }
            catch (COMException)
            {
                kompas = null;
                return false;
            }
        }

        /// <summary>
        /// Запускает окно создания 3D-модели
        /// </summary>
        /// <returns>Окно создания детали</returns>
        public ksDocument3D CreateDocument3D()
        {
            ksDocument3D document3D = (ksDocument3D)_object.Document3D();
            document3D.Create();
            _part = (ksPart)document3D.GetPart((int)Part_Type.pTop_Part);
            return document3D;
        }

        /// <summary>
        /// Метод рисования прямоугольника
        /// </summary>
        /// <param name="x">X базовой точки</param>
        /// <param name="y">Y базовой точки</param>
        /// <param name="height">Высота</param>
        /// <param name="width">Ширина</param>
        /// <returns>Переменная с параметрами прямоугольника</returns>
        public ksRectangleParam DrawRectangle(double x, double y,
            double height, double width)
        {
            var rectangleParam =
                (ksRectangleParam)Object.GetParamStruct
                    ((short)Kompas6Constants.StructType2DEnum.ko_RectangleParam);
            rectangleParam.x = x;
            rectangleParam.y = y;
            rectangleParam.height = height;
            rectangleParam.width = width;
            rectangleParam.style = 1;
            return rectangleParam;
        }

        /// <summary>
        /// Метод осуществляющий вырезание
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="depth">Расстояние выреза</param>
        /// <param name="angle">Угол выреза</param>
        /// <param name="side">Направление выреза</param>
        public void СreateCutExtrusion(ksSketchDefinition sketch,
            double depth, double angle, bool side = false)
        {
            var cutExtrusionEntity = (ksEntity)Part.NewEntity(
                (short)ksObj3dTypeEnum.o3d_cutExtrusion);
            var cutExtrusionDef =
                (ksCutExtrusionDefinition)cutExtrusionEntity
                    .GetDefinition();

            cutExtrusionDef.SetSideParam(side,
                (short)End_Type.etBlind, depth);
            cutExtrusionDef.directionType = side ?
                (short)Direction_Type.dtNormal :
                (short)Direction_Type.dtReverse;
            cutExtrusionDef.cut = true;
            cutExtrusionDef.SetSketch(sketch);
            cutExtrusionEntity.Create();
        }

        /// <summary>
        /// Метод создающий эскиз
        /// </summary>
        /// <param name="planeType">Плоскость</param>
        /// <param name="offsetPlane">Объект смещения</param>
        /// <returns>Эскиз</returns>
        public ksSketchDefinition CreateSketch(Obj3dType planeType,
            ksEntity offsetPlane = null)
        {
            var plane = (ksEntity)Part
                .GetDefaultEntity((short)planeType);

            var sketch = (ksEntity)Part.
                NewEntity((short)Obj3dType.o3d_sketch);
            var ksSketch = (ksSketchDefinition)sketch.GetDefinition();

            if (offsetPlane != null)
            {
                ksSketch.SetPlane(offsetPlane);
                sketch.Create();
                return ksSketch;
            }

            ksSketch.SetPlane(plane);
            sketch.Create();
            return ksSketch;
        }

        /// <summary>
        /// Метод осущетсвляющий выдавливание
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="depth">Расстояние выдавливания</param>
        public void СreateExtrusion(ksSketchDefinition sketch,
            double depth, bool side = true)
        {
            var extrusionEntity = (ksEntity)Part.NewEntity(
                (short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity
                .GetDefinition();

            extrusionDef.SetSideParam(side,
                (short)End_Type.etBlind, depth);
            extrusionDef.directionType = side ?
                (short)Direction_Type.dtNormal :
                (short)Direction_Type.dtReverse;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();
        }

        /// <summary>
        /// Метод осущетсвляющий выдавливание с стенками
        /// </summary>
        /// <param name="sketch">Эскиз</param>
        /// <param name="depth">Расстояние выдавливания</param>
        public void СreateExtrusionThin(ksSketchDefinition sketch,
            double depth, bool side = true)
        {
            var extrusionEntity = (ksEntity)Part.NewEntity(
                (short)ksObj3dTypeEnum.o3d_bossExtrusion);
            var extrusionDef = (ksBossExtrusionDefinition)extrusionEntity
                .GetDefinition();
            extrusionDef.SetThinParam(true, 15, 2, 2);


            extrusionDef.SetSideParam(side,
                (short)End_Type.etBlind, depth);
            extrusionDef.directionType = side
                ? (short)Direction_Type.dtMiddlePlane
                : (short)Direction_Type.dtNormal;
            extrusionDef.SetSketch(sketch);
            extrusionEntity.Create();
        }

        /// <summary>
        /// Метод смещающий плоскость
        /// </summary>
        /// <param name="plane">Плоскость</param>
        /// <param name="offset">Расстояние смещения</param>
        /// <returns>Объект смещения</returns>
        public ksEntity CreateOffsetPlane(Obj3dType plane, double offset)
        {
            var offsetEntity = (ksEntity)
                Part.NewEntity((short)Obj3dType.o3d_planeOffset);
            var offsetDef = (ksPlaneOffsetDefinition)offsetEntity
                .GetDefinition();
            offsetDef.SetPlane((ksEntity)
                Part.NewEntity((short)plane));
            offsetDef.offset = offset;
            offsetDef.direction = true;
            offsetEntity.Create();
            return offsetEntity;
        }
    }
}
