using System;
using System.Runtime.InteropServices;
using Inventor;

namespace RocketProject
{
    /// <summary>
    /// Иницилиазириует Инвентор.
    /// </summary>
    public class InventorApi
    {
        #region Links to the API

        /// <summary>
        /// Ссылка на работу с документацией АПИ
        /// </summary>
        public PartDocument PartDoc { get; private set; }

        /// <summary>
        /// Ссылка на приложение Инвентора.
        /// </summary>
        public Application InvApp {get; private set; }

        /// <summary>
        /// Описание документа.
        /// </summary>
        public PartComponentDefinition PartDefinition { get; private set; }

        /// <summary>
        /// Геометрия приложения.
        /// </summary>
        public TransientGeometry TransientGeometry { get; private set; }

        #endregion

        #region Reference to the action of the IPA
        /// <summary>
        /// Создание объекта коллекции
        /// </summary>
        /// <returns></returns>
        public ObjectCollection CreateObjectCollection()
        {
            return InvApp.TransientObjects.CreateObjectCollection();
        }

        
        /// <summary>
        /// Создание нового документа.
        /// </summary>
        public void CreateNewDocument()
        {
            InvApp = null;
            try
            {
                InvApp = (Application)Marshal.GetActiveObject("Inventor.Application");
            }
            catch (Exception)
            {
                try
                {
                    //Если не получилось перехватить приложение - выкинется ексепшн на то,
                    //что такого активного приложения нет. Попробуем создать приложение вручную.
                    Type invAppType = Type.GetTypeFromProgID("Inventor.Application");

                    InvApp = (Application)Activator.CreateInstance(invAppType);
                    InvApp.Visible = true;                                      
                }
                catch (Exception)
                {
                    //MessageBox.Show(ex2.ToString());
                    System.Windows.Forms.MessageBox.Show(@"Не получилось запустить инвентор.");
                }
            }

            // В открытом приложении создаем документ
            PartDoc = (PartDocument)InvApp.Documents.Add
                (DocumentTypeEnum.kPartDocumentObject,
                    InvApp.FileManager.GetTemplateFile
                        (DocumentTypeEnum.kPartDocumentObject,
                            SystemOfMeasureEnum.kMetricSystemOfMeasure));

            PartDefinition = PartDoc.ComponentDefinition; //Описание документа
          //  AssemblyDocument assDoc = (AssemblyDocument)_invApp.ActiveDocument;
            //_assemblyDef = assDoc.ComponentDefinition;
            TransientGeometry =InvApp.TransientGeometry; //инициализация метода геометрии
        }

        //Для построения от рабочих плоскостей.
        public PlanarSketch MakeNewSketch(int n, double offset)
        {
            Inventor.WorkPlane MainPlane = PartDefinition.WorkPlanes[n];       //[1 - ZY; 2 - ZX; 3 - XY]
            Inventor.WorkPlane OffsetPlane = PartDefinition.WorkPlanes.AddByPlaneAndOffset(MainPlane, offset, false);
            Inventor.PlanarSketch sketch = PartDefinition.Sketches.Add(OffsetPlane, false);
            return sketch;
        }

        //Для построения на поверхности детали.
        public PlanarSketch MakeNewSketch(Object face, double offset)
        {
            Inventor.WorkPlane OffsetPlane = PartDefinition.WorkPlanes.AddByPlaneAndOffset(face, offset, false);
            Inventor.PlanarSketch sketch = PartDefinition.Sketches.Add(OffsetPlane, false);
            return sketch;
        }
       /// <summary>
       /// Нарисовать многоугольник.
       /// </summary>
       /// <param name="CircumferencePoint"></param>
       /// <param name="sketch"></param>
       /// <param name="CenterPoint"></param>
        public void DrawPolygon(Point2d CircumferencePoint, PlanarSketch sketch, Point2d CenterPoint)
        {
            sketch.SketchLines.AddAsPolygon(6, CenterPoint, CircumferencePoint, false);
        }

       /// <summary>
        /// Отрисовка круга для звеньев.
       /// </summary>
       /// <param name="Diameter"></param>
       /// <param name="sketch"></param>
       /// <param name="CenterPoint"></param>
        public void DrawCircle(double Diameter, PlanarSketch sketch, Point2d CenterPoint)
        {
            sketch.SketchCircles.AddByCenterRadius(CenterPoint, Diameter);
        }
        public void SetColor(Faces faces, string color)
        {
            var oStyle = PartDoc.RenderStyles[color]; //'your customized color  
            foreach (Face face in faces)
            {
                try
                {
                    face.SetRenderStyle(StyleSourceTypeEnum.kOverrideRenderStyle, oStyle);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show(@"Ошибка отрисовки граней.");
                }
            }
        }
        #endregion
    }
}
