using System.Drawing;

namespace SpecFlowDGeoFlowTests.StepDefinitions
{
    [Binding]
    public sealed class MaterialsStepDefinitions
    {
        [Given(@"calibrate")]
        public void GivenCalibrate()
        {
            D_GeoFlow.Recordings.General.StartAUT.Start();
            D_GeoFlow.Recordings.General.MaximizeApplication.Start();

            var geometry = "10;-20,10;15,35;15,60;0,90;0,90;-20";
            var materialName = "Embankment old";
            //Draw layer
            D_GeoFlow.DrawGeometryMethod.ResetCalibration();
            D_GeoFlow.Recordings.Geometry.DrawLayer.Instance.Geometry = geometry;
            D_GeoFlow.Recordings.Geometry.DrawLayer.Start();
            D_GeoFlow.DrawGeometryMethod.DrawOnEditorWithDoubleClick(D_GeoFlow.Recordings.Geometry.DrawLayer.Instance.Geometry);

            // AssignMaterial
            D_GeoFlow.DrawGeometryMethod.ClickOnPolygonCenter(D_GeoFlow.Recordings.Geometry.DrawLayer.Instance.Geometry);
            D_GeoFlow.Recordings.Materials.AssignMaterial.Instance.MaterialName = materialName;
            D_GeoFlow.Recordings.Materials.AssignMaterial.Instance.Geometry = geometry;
            D_GeoFlow.Recordings.Materials.AssignMaterial.Start();

            //EvaluateMaterialDoesExist
            D_GeoFlow.DrawGeometryMethod.ClickOnPolygonCenter(geometry);
            D_GeoFlow.Recordings.Materials.EvaluateMaterialDoesExist.Instance.MaterialName = materialName;
            D_GeoFlow.Recordings.Materials.EvaluateMaterialDoesExist.Instance.Geometry = geometry;
            D_GeoFlow.Recordings.Materials.EvaluateMaterialDoesExist.Start();

            //EvaluateMaterialProperties
            //var lable = "Embankment old";
            //var notes = "";
            //var code = "H_Aa_ht_old";
            //var horizontalPermeability = "0.01";
            //var verticalPermeability = "0.01";
            //D_GeoFlow.DrawGeometryMethod.ClickOnPolygonCenter(geometry);
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialProperties.Instance.Geometry = geometry;
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialProperties.Instance.Notes = notes;
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialProperties.Instance.Code = code;
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialProperties.Instance.HorizontalPermeability = horizontalPermeability; 
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialProperties.Instance.VerticalPermeability = verticalPermeability;
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialProperties.Instance.Label = lable;
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialProperties.Start();

            //EvaluateMaterialSandASandA
            //D_GeoFlow.DrawGeometryMethod.ClickOnPolygonCenter(geometry);
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialSandASandA.Instance.Geometry = geometry;
            ////D_GeoFlow.D_GeoFlowRepository.Instance.DGeoFlow.GeometryEditorFolder.
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialSandASandA.repo.DGeoFlow.PropertyPanel.Materials.FillDropDownButtonInfo.GetScreenshotSandASandA(new Rectangle(4, 3, 44, 25));
            //D_GeoFlow.Recordings.Materials.EvaluateMaterialSandASandA.Start();







        }

    }
}