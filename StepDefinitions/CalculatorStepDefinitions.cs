namespace SpecFlowDStabilityTests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        [Given(@"Open new project in D-GEO Suite D-Stability")]
        [When(@"I open new project in D-GEO Suite D-Stability")]
        public void GivenOpenNewProjectInD_GEOSuiteD_Stability()
        {
            D_Stability.Recordings.General.StartAUT.Start();
            D_Stability.Recordings.General.MaximizeApplication.Start();
        }

        [Then(@"the selection button has the name '([^']*)'")]
        public void ThenTheSelectionButtonHasTheName(string combindScenarioName)
        {
            D_Stability.Recordings.StagesAndScenarios.EvaluateScenarioSelectionButton.Instance.ScenarioStageName = combindScenarioName;
            D_Stability.Recordings.StagesAndScenarios.EvaluateScenarioSelectionButton.Start();
        }

        [When(@"I change the scenario")]
        public void WhenIChangeTheScenario(Table table)
        {
            D_Stability.Recordings.StagesAndScenarios.EditScenario.repo.ScenarioName = table.Rows[0]["ScenarioName"];
            D_Stability.Recordings.StagesAndScenarios.EditScenario.repo.ScenarioIndex = table.Rows[0]["ScenarioIndex"];
            D_Stability.Recordings.StagesAndScenarios.EditScenario.Start();
        }

        [Then(@"there are the following properties")]
        public void ThenThereAreTheFollowingProperties(Table table)
        {
            D_Stability.Recordings.StagesAndScenarios.EvaluateSelectionProperties.Instance.SelectionName = table.Rows[0]["SelectionName"];
            D_Stability.Recordings.StagesAndScenarios.EvaluateSelectionProperties.Instance.Notes = table.Rows[0]["Notes"];
            D_Stability.Recordings.StagesAndScenarios.EvaluateSelectionProperties.Instance.PropertyPanelCaption = table.Rows[0]["PropertyPanelCaption"];
            D_Stability.Recordings.StagesAndScenarios.EvaluateSelectionProperties.Start();
        }

        [When(@"I modifythere the following properties")]
        public void WhenIModifythereTheFollowingProperties(Table table)
        {
            D_Stability.Recordings.StagesAndScenarios.ModifySelectionProperties.Instance.SelectionName = table.Rows[0]["SelectionName"];
            D_Stability.Recordings.StagesAndScenarios.ModifySelectionProperties.Instance.Notes = table.Rows[0]["Notes"];
            D_Stability.Recordings.StagesAndScenarios.ModifySelectionProperties.Start();

        }

        [When(@"I undo the gemetry changes")]
        public void WhenIUndoTheGemetryChanges()
        {
            D_Stability.Recordings.Geometry.UndoGeometry.Start();
        }

        [When(@"I redo the gemetry changes")]
        public void WhenIRedoTheGemetryChanges()
        {

            D_Stability.Recordings.Geometry.RedoGeometry.Start();
        }

        [Then(@"I save the scenario '(.*)' in the folder '(.*)'")]
        public void ThenISaveTheScenarioInTheFolder(string fileName, string folderName)
        {
            var generateFileName = new D_Stability.Helpers.GenerateFileName();
            generateFileName.TestFilesFolder = folderName;
            D_Stability.Recordings.General.SaveAs.Instance.filename = fileName;

            D_Stability.Recordings.General.SaveAs.Start();
        }
    }
}