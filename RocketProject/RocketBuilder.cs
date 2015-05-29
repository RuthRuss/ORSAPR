using Inventor;

namespace RocketProject
{
    /// <summary>
    /// Деталь Rocket.
    /// </summary>
    /// 
    public class RocketBuilder
    {

        #region Links and designer
        /// <summary>
        /// Апи инвентора.
        /// </summary>
        private readonly InventorApi _inventorApi;

        /// <summary>
        /// Текущая точка.
        /// </summary>
        private Point2d _curPoint;
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        public RocketBuilder()
        {
            _inventorApi = new InventorApi();
            RocketParameters = new RocketParameters();            
        }       

        /// <summary>
        /// Параметры Ракеты.
        /// </summary>
        public RocketParameters RocketParameters { get; private set; }

        #endregion

        #region Builder
        /// <summary>
        /// Метод создания модели.
        /// </summary>
        public void Build(RocketBuildStyle style)
        {
            _inventorApi.CreateNewDocument();
            _curPoint = _inventorApi.TransientGeometry.CreatePoint2d(0, 0); //Текущая точка по центру.

            BuildCone(style);
            BuildSecondStage(style);
            BuildBetweenStage(style);
            BuildFirstStage(style);
            BuildSecondStabilizer(style);
            BuildNozzle(style);
            BuildFirstStabilizer(style);
            if (style == RocketBuildStyle.Metal || style == RocketBuildStyle.Color)
            {
                ChangeMaterial(style);
            }
            TurnCamera(style);
            TurnCamera(style);

        }

        #endregion

        #region Build Cone
        /// <summary>
        /// Отрисовка верхнего конуса
        /// </summary>
        private void BuildCone(RocketBuildStyle style)
        {
            // Комментарий к методу один раз так как дальше все по аналогии одинаково =)
            //Задаем плоскости
            WorkAxis xAxis = _inventorApi.PartDefinition.WorkAxes[1];
            WorkAxis yAxis = _inventorApi.PartDefinition.WorkAxes[2];
            WorkAxis zAxis = _inventorApi.PartDefinition.WorkAxes[3];

            //Задаем опорные точки
            double coneBezierParameter1 = 0.625;
            double coneBezierParameter2 = 0.325;
            var coneLenght = RocketParameters.GetParameter(ParameterType.ConeLength).Value;
            var coneDiameter = RocketParameters.GetParameter(ParameterType.SecondStageDiameter).Value;
            var conePoint1 = _inventorApi.TransientGeometry.CreatePoint2d(0, 0);
            var conePoint2 = _inventorApi.TransientGeometry.CreatePoint2d(0, coneLenght);
            var conePoint3 = _inventorApi.TransientGeometry.CreatePoint2d(coneDiameter, coneLenght);
            var coneBezierPoint = _inventorApi.TransientGeometry.
                CreatePoint2d(coneBezierParameter1*coneDiameter, coneBezierParameter2*coneLenght);
            
            //Создаем скетч
            var xySketch = _inventorApi.MakeNewSketch(1, 0);

            //Добавляем в него линии по точкам (внимательно! нужно указывать начало и конец линий)          
            var line1 = xySketch.SketchLines.AddByTwoPoints(conePoint1, conePoint2);
            var line2 = xySketch.SketchLines.AddByTwoPoints(line1.EndSketchPoint, conePoint3);
            xySketch.SketchArcs.AddByThreePoints(line1.StartSketchPoint, coneBezierPoint, line2.EndSketchPoint);
            var xySketchProfile = xySketch.Profiles.AddForSolid();
            
            //Вращаем на 360 градусов с выдавливанием вокруг оси Z
            var revolve = _inventorApi.PartDefinition.Features.RevolveFeatures.AddFull(xySketchProfile, zAxis,
            PartFeatureOperationEnum.kJoinOperation);

            //Выбор металла
            if (style == RocketBuildStyle.Color)
            {
                _inventorApi.SetColor(revolve.Faces, "Gold - Metal");
            }
        }
        #endregion 

        #region Build Second Stage
        /// <summary>
        /// Отрисовка второй ступени (тонкой)
        /// </summary>
        private void BuildSecondStage(RocketBuildStyle style)
        {
            WorkAxis xAxis = _inventorApi.PartDefinition.WorkAxes[1];
            WorkAxis yAxis = _inventorApi.PartDefinition.WorkAxes[2];
            WorkAxis zAxis = _inventorApi.PartDefinition.WorkAxes[3];

            var secondStageLenght = RocketParameters.GetParameter(ParameterType.SecondStageLength).Value;
            var secondStageDiameter = RocketParameters.GetParameter(ParameterType.SecondStageDiameter).Value;
            var coneLenght = RocketParameters.GetParameter(ParameterType.ConeLength).Value;
            var secondStagePoint1 = _inventorApi.TransientGeometry.CreatePoint2d(0, 0);
            var secondStagePoint2 = _inventorApi.TransientGeometry.
                CreatePoint2d(secondStageDiameter, coneLenght + secondStageLenght);
            var secondStagePoint3 = _inventorApi.TransientGeometry.
                CreatePoint2d(secondStageDiameter, coneLenght);

            var xySketch = _inventorApi.MakeNewSketch(3, coneLenght);
            xySketch.SketchCircles.AddByCenterRadius(secondStagePoint1, secondStageDiameter);
            var xySketchProfile = xySketch.Profiles.AddForSolid();

            var extrudeDef = _inventorApi.PartDefinition.Features.ExtrudeFeatures.CreateExtrudeDefinition(
                xySketchProfile, PartFeatureOperationEnum.kJoinOperation);
            
            // Отрисовка при помощи выдавливания круга (тест)
            extrudeDef.SetDistanceExtent(secondStageLenght, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
            var extrude = _inventorApi.PartDefinition.Features.ExtrudeFeatures.Add(extrudeDef);

            if (style == RocketBuildStyle.Color)
            {
                _inventorApi.SetColor(extrude.Faces, "Nickel");
            }
        }
        #endregion

        #region Build Between Stage
        /// <summary>
        /// Отрисовка промежуточной юбки между ступенями
        /// </summary>
        private void BuildBetweenStage(RocketBuildStyle style)
        {
            WorkAxis xAxis = _inventorApi.PartDefinition.WorkAxes[1];
            WorkAxis yAxis = _inventorApi.PartDefinition.WorkAxes[2];
            WorkAxis zAxis = _inventorApi.PartDefinition.WorkAxes[3];

            var secondStageLenght = RocketParameters.GetParameter(ParameterType.SecondStageLength).Value;
            var secondStageDiameter = RocketParameters.GetParameter(ParameterType.SecondStageDiameter).Value;
            var coneLenght = RocketParameters.GetParameter(ParameterType.ConeLength).Value;
            var firstStageLenght = RocketParameters.GetParameter(ParameterType.FirstStageLength).Value;
            var firstStageDiameter = RocketParameters.GetParameter(ParameterType.FirstStageDiameter).Value;
            var rocketLength = RocketParameters.GetParameter(ParameterType.RocketLength).Value;

            var betweenStagePoint1 = _inventorApi.TransientGeometry.
                CreatePoint2d(0, coneLenght + secondStageLenght);
            var betweenStagePoint2 = _inventorApi.TransientGeometry.
                CreatePoint2d(0, rocketLength - firstStageLenght);
            var betweenStagePoint3 = _inventorApi.TransientGeometry.
                CreatePoint2d(firstStageDiameter, rocketLength - firstStageLenght);
            var betweenStagePoint4 = _inventorApi.TransientGeometry.
                CreatePoint2d(secondStageDiameter, coneLenght + secondStageLenght);
     
            var xySketch = _inventorApi.MakeNewSketch(1, 0);
            var line1 = xySketch.SketchLines.AddByTwoPoints(betweenStagePoint1, betweenStagePoint2);
            var line2 = xySketch.SketchLines.AddByTwoPoints(line1.EndSketchPoint, betweenStagePoint3);
            var line3 = xySketch.SketchLines.AddByTwoPoints(line2.EndSketchPoint, betweenStagePoint4);
            xySketch.SketchLines.AddByTwoPoints(line1.StartSketchPoint, line3.EndSketchPoint);

            var xySketchProfile = xySketch.Profiles.AddForSolid();
            var revolve = _inventorApi.PartDefinition.Features.RevolveFeatures.AddFull(xySketchProfile, zAxis,
                PartFeatureOperationEnum.kJoinOperation);

            if (style == RocketBuildStyle.Color)
            {
                _inventorApi.SetColor(revolve.Faces, "Titanium");
            }
        }
        #endregion

        #region Build First Stage
        /// <summary>
        /// Отрисовка первой ступени методом вращения прямоугольника
        /// </summary>
        private void BuildFirstStage(RocketBuildStyle style)
        {
            WorkAxis xAxis = _inventorApi.PartDefinition.WorkAxes[1];
            WorkAxis yAxis = _inventorApi.PartDefinition.WorkAxes[2];
            WorkAxis zAxis = _inventorApi.PartDefinition.WorkAxes[3];

            var firstStageLenght = RocketParameters.GetParameter(ParameterType.FirstStageLength).Value;
            var firstStageDiameter = RocketParameters.GetParameter(ParameterType.FirstStageDiameter).Value;
            var rocketLength = RocketParameters.GetParameter(ParameterType.RocketLength).Value;
            var firstStagePoint1 = _inventorApi.TransientGeometry.CreatePoint2d(0, rocketLength - firstStageLenght);
            var firstStagePoint2 = _inventorApi.TransientGeometry.CreatePoint2d(firstStageDiameter, rocketLength);
            
            var xySketch = _inventorApi.MakeNewSketch(1, 0);
            xySketch.SketchLines.AddAsTwoPointRectangle(firstStagePoint1, firstStagePoint2);
            var xySketchProfile = xySketch.Profiles.AddForSolid();
            var revolve = _inventorApi.PartDefinition.Features.RevolveFeatures.AddFull(xySketchProfile, zAxis,
                PartFeatureOperationEnum.kJoinOperation);

            if (style == RocketBuildStyle.Color)
            {
                _inventorApi.SetColor(revolve.Faces, "Chrome - Polished");
            }

        }
        #endregion

        #region Build Second Stage
        /// <summary>
        /// Отрисовка и вращение стабилизаторов второй ступени
        /// </summary>
        private void BuildSecondStabilizer(RocketBuildStyle style)
        {
            WorkAxis xAxis = _inventorApi.PartDefinition.WorkAxes[1];
            WorkAxis yAxis = _inventorApi.PartDefinition.WorkAxes[2];
            WorkAxis zAxis = _inventorApi.PartDefinition.WorkAxes[3];
            
            var secondStageDiameter = RocketParameters.GetParameter(ParameterType.SecondStageDiameter).Value;
            var secondStabilizerSpan = RocketParameters.GetParameter(ParameterType.SecondStabilizerSpan).Value - secondStageDiameter;
            var secondStabilizerCount = RocketParameters.GetParameter(ParameterType.SecondStabilizerCount).Value;
            var coneLenght = RocketParameters.GetParameter(ParameterType.ConeLength).Value;
            var secondStageLenght = RocketParameters.GetParameter(ParameterType.SecondStageLength).Value + coneLenght;
            var stabilizerWidth = RocketParameters.GetParameter(ParameterType.StabilizerWidth).Value;

            //Необходимые параметры для отрисовки стабилизатора в соответсвии с чертежом
            double parameterPointStabilizer1 = 0.25;
            double parameterPointStabilizer2 = 0.2;
            double parameterPointStabilizer3 = 0.05;

            var secondStabilizerPoint1 = _inventorApi.TransientGeometry.CreatePoint2d(
                secondStageDiameter, secondStageLenght - secondStageLenght * 0.25);
            var secondStabilizerPoint2 = _inventorApi.TransientGeometry.CreatePoint2d(
                secondStageDiameter, secondStageLenght);
            var secondStabilizerPoint3 = _inventorApi.TransientGeometry.CreatePoint2d(
                secondStabilizerSpan, secondStageLenght + secondStabilizerSpan*0.2);
            var secondStabilizerPoint4 = _inventorApi.TransientGeometry.CreatePoint2d(
                secondStabilizerSpan, secondStageLenght - secondStageLenght * 0.05);

            var xySketch = _inventorApi.MakeNewSketch(1, 0);
            var line1 = xySketch.SketchLines.AddByTwoPoints(secondStabilizerPoint1, secondStabilizerPoint2);
            var line2 = xySketch.SketchLines.AddByTwoPoints(line1.EndSketchPoint, secondStabilizerPoint3);
            var line3 = xySketch.SketchLines.AddByTwoPoints(line2.EndSketchPoint, secondStabilizerPoint4);
            xySketch.SketchLines.AddByTwoPoints(line1.StartSketchPoint, line3.EndSketchPoint);

            var xySketchProfile = xySketch.Profiles.AddForSolid();
            
            //Метод выдавливания
            var extrudeDef = _inventorApi.PartDefinition.Features.ExtrudeFeatures.CreateExtrudeDefinition(
                xySketchProfile, PartFeatureOperationEnum.kJoinOperation);
            
            //Выдвыливание
            extrudeDef.SetDistanceExtent(stabilizerWidth, PartFeatureExtentDirectionEnum.kSymmetricExtentDirection);
            var extrude = _inventorApi.PartDefinition.Features.ExtrudeFeatures.Add(extrudeDef);

            ObjectCollection objectCollection = _inventorApi.CreateObjectCollection();
            objectCollection.Add(extrude);

            //Вращение по массиву
            _inventorApi.PartDefinition.Features.CircularPatternFeatures.Add(
            objectCollection,zAxis,true,secondStabilizerCount,"360 deg",true,
            PatternComputeTypeEnum.kAdjustToModelCompute);
        }
        #endregion

        #region Build Nozzle
        /// <summary>
        /// Отрисовка сопла (модернизирована с добавлением имитации двигателя)
        /// </summary>
        private void BuildNozzle(RocketBuildStyle style)
        {
            WorkAxis xAxis = _inventorApi.PartDefinition.WorkAxes[1];
            WorkAxis yAxis = _inventorApi.PartDefinition.WorkAxes[2];
            WorkAxis zAxis = _inventorApi.PartDefinition.WorkAxes[3];

            var firstStageLenght = RocketParameters.GetParameter(ParameterType.FirstStageLength).Value;
            var firstStageDiameter = RocketParameters.GetParameter(ParameterType.FirstStageDiameter).Value;
            var rocketLenght = RocketParameters.GetParameter(ParameterType.RocketLength).Value;
            var nozzleDiameter = RocketParameters.GetParameter(ParameterType.NozzleDiameter).Value;

            double parameterPointNozzle1 = 0.25;
            double parameterPointNozzle2 = 0.30;
            double parameterPointNozzle3 = 0.1;
            double parameterPointNozzle4 = 0.5;
            
            var nozzlePoint1 = _inventorApi.TransientGeometry.CreatePoint2d(0, rocketLenght);
            var nozzlePoint2 = _inventorApi.TransientGeometry.
                CreatePoint2d(0, rocketLenght + 
                (firstStageLenght * parameterPointNozzle1) * parameterPointNozzle2);
            var nozzlePoint3 = _inventorApi.TransientGeometry.
                CreatePoint2d(nozzleDiameter * 0.30, rocketLenght + 
                (firstStageLenght * parameterPointNozzle1) * parameterPointNozzle3);
            var nozzlePoint4 = _inventorApi.TransientGeometry.
                CreatePoint2d(nozzleDiameter * 0.95, rocketLenght + firstStageLenght * parameterPointNozzle1);
            var nozzleBezierPoint = _inventorApi.TransientGeometry.
                CreatePoint2d(0.85 * nozzleDiameter, rocketLenght + 
                (firstStageLenght * parameterPointNozzle1) * parameterPointNozzle4);
            var nozzlePoint5 = _inventorApi.TransientGeometry.
                CreatePoint2d(nozzleDiameter, rocketLenght + firstStageLenght * 0.25);
            var nozzlePoint6 = _inventorApi.TransientGeometry.CreatePoint2d(firstStageDiameter, rocketLenght);

            var xySketch = _inventorApi.MakeNewSketch(1, 0);
            var line1 = xySketch.SketchLines.AddByTwoPoints(nozzlePoint1, nozzlePoint2);
            var line2 = xySketch.SketchLines.AddByTwoPoints(line1.EndSketchPoint, nozzlePoint3);
            var line3 = xySketch.SketchArcs.AddByThreePoints(line2.EndSketchPoint, nozzleBezierPoint, nozzlePoint4);
            var line4 = xySketch.SketchLines.AddByTwoPoints(line3.EndSketchPoint, nozzlePoint5);
            var line5 = xySketch.SketchLines.AddByTwoPoints(line4.EndSketchPoint, nozzlePoint6);
            xySketch.SketchLines.AddByTwoPoints(line1.StartSketchPoint, line5.EndSketchPoint);

            var xySketchProfile = xySketch.Profiles.AddForSolid();
            var revolve = _inventorApi.PartDefinition.Features.RevolveFeatures.AddFull(xySketchProfile, zAxis,
                PartFeatureOperationEnum.kJoinOperation);

            if (style == RocketBuildStyle.Color)
            {
                _inventorApi.SetColor(revolve.Faces, "Nickel");
            }

        }
        #endregion

        #region Build First Stage
        /// <summary>
        /// Отрисовка стабилизаторов первой ступени
        /// </summary>
        private void BuildFirstStabilizer(RocketBuildStyle style)
        {
            WorkAxis xAxis = _inventorApi.PartDefinition.WorkAxes[1];
            WorkAxis yAxis = _inventorApi.PartDefinition.WorkAxes[2];
            WorkAxis zAxis = _inventorApi.PartDefinition.WorkAxes[3];

            var firstStageDiameter = RocketParameters.GetParameter(ParameterType.FirstStageDiameter).Value;
            var firstStageLenght = RocketParameters.GetParameter(ParameterType.FirstStageLength).Value;
            var rocketLenght = RocketParameters.GetParameter(ParameterType.RocketLength).Value;
            var nozzleLenght = firstStageLenght * 0.25;
            var firstStabilizerSpan = RocketParameters.GetParameter(ParameterType.FirstStabilizerSpan).Value - firstStageDiameter;
            var firstStabilizerCount = RocketParameters.GetParameter(ParameterType.FirstStabilizerCount).Value;
            var stabilizerWidth = RocketParameters.GetParameter(ParameterType.StabilizerWidth).Value;
            var nozzleDiameter = RocketParameters.GetParameter(ParameterType.NozzleDiameter).Value;

            double parameterPointStabilizer1 = 0.2;
            double parameterPointStabilizer2 = 0.1;
            double parameterPointStabilizer3 = 0.05;

            var firstStabilizerPoint1 = _inventorApi.TransientGeometry.CreatePoint2d(
                firstStageDiameter, rocketLenght - firstStageLenght * parameterPointStabilizer3);
            var firstStabilizerPoint2 = _inventorApi.TransientGeometry.CreatePoint2d(
                nozzleDiameter, rocketLenght + nozzleLenght);
            var firstStabilizerPoint3 = _inventorApi.TransientGeometry.CreatePoint2d(
                nozzleDiameter + nozzleDiameter*parameterPointStabilizer2, 
                rocketLenght + nozzleLenght + firstStageDiameter * parameterPointStabilizer1);
            var firstStabilizerPoint4 = _inventorApi.TransientGeometry.CreatePoint2d(
                firstStabilizerSpan, rocketLenght + nozzleLenght - firstStabilizerSpan * parameterPointStabilizer2);
            var firstStabilizerPoint5 = _inventorApi.TransientGeometry.CreatePoint2d(
                firstStabilizerSpan, rocketLenght + nozzleLenght * parameterPointStabilizer2);

            var xySketch = _inventorApi.MakeNewSketch(1, 0);
            var line1 = xySketch.SketchLines.AddByTwoPoints(firstStabilizerPoint1, firstStabilizerPoint2);
            var line2 = xySketch.SketchLines.AddByTwoPoints(line1.EndSketchPoint, firstStabilizerPoint3);
            var line3 = xySketch.SketchLines.AddByTwoPoints(line2.EndSketchPoint, firstStabilizerPoint4);
            var line4 = xySketch.SketchLines.AddByTwoPoints(line3.EndSketchPoint, firstStabilizerPoint5);
            xySketch.SketchLines.AddByTwoPoints(line1.StartSketchPoint, line4.EndSketchPoint);

            var xySketchProfile = xySketch.Profiles.AddForSolid();
            var extrudeDef = _inventorApi.PartDefinition.Features.ExtrudeFeatures.CreateExtrudeDefinition(
                xySketchProfile, PartFeatureOperationEnum.kJoinOperation);
            extrudeDef.SetDistanceExtent(stabilizerWidth, PartFeatureExtentDirectionEnum.kSymmetricExtentDirection);
            var extrude = _inventorApi.PartDefinition.Features.ExtrudeFeatures.Add(extrudeDef);

            ObjectCollection objectCollection = _inventorApi.CreateObjectCollection();
            objectCollection.Add(extrude);
            var curc = _inventorApi.PartDefinition.Features.CircularPatternFeatures.Add(
                objectCollection,zAxis,true,firstStabilizerCount,"360 deg",true,
                PatternComputeTypeEnum.kAdjustToModelCompute);
        }
        #endregion

        #region Material for Rocket
        /// <summary>
        /// Задаем материал для детали
        /// </summary>
        private void ChangeMaterial(RocketBuildStyle style)
        {
            PartDocument partDocument = (PartDocument)_inventorApi.InvApp.ActiveDocument;
            Materials materialsLibrary = partDocument.Materials;
            Material myMaterial = materialsLibrary["Silver"];
            Material tempMaterial = null;
            tempMaterial = myMaterial.StyleLocation == StyleLocationEnum.kLibraryStyleLocation  ? myMaterial.ConvertToLocal() : myMaterial;
            partDocument.ComponentDefinition.Material = tempMaterial;
            partDocument.Update();
        }
        #endregion

        #region Camera
        /// <summary>
        /// Управление камерой
        /// </summary>
        private void TurnCamera(RocketBuildStyle style)
        {
            Camera camera = _inventorApi.InvApp.ActiveView.Camera;
            camera.ViewOrientationType = ViewOrientationTypeEnum.kTopViewOrientation;
            camera.Apply();
        }
        #endregion
    }
}
