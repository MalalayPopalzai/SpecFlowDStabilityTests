using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace SpecFlowDStabilityTests.Support
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var appSettings = GetSetting("AppSettings", "path");
            D_Stability.Recordings.General.StartAUT.Instance.AppPathVar = appSettings;
        }

        //[BeforeScenario("@tag1")]
        //public void BeforeScenarioWithTag()
        //{
        //    // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
        //    // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

        //    //TODO: implement logic that has to run before executing each scenario
        //}

        //[BeforeScenario(Order = 1)]
        //public void FirstBeforeScenario()
        //{
        //    // Example of ordering the execution of hooks
        //    // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

        //    //TODO: implement logic that has to run before executing each scenario
        //}

        [AfterScenario]
        public static void AfterScenario()
        {
            D_Stability.Recordings.General.CloseAUT.Start();
            //TODO: implement logic that has to run after executing each scenario
        }

        [AfterTestRun]
        public static void WriteTestResultsToFile()
        {
            var command = @"livingdoc test-assembly C:\checkouts\Specflow\SpecFlowDStabilityTests\bin\x64\Debug\net48\SpecFlowDStabilityTests.dll -t C:\checkouts\Specflow\SpecFlowDStabilityTests\bin\x64\Debug\net48\TestExecution.json";
            var cmdPath = GetSetting("CmdApp", "path");
            var testResultPath = GetSetting("TesResultDir", "path");

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = cmdPath; 
            processStartInfo.Arguments = "/C " + command;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.WorkingDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, testResultPath));

            var process = Process.Start(processStartInfo);
            process.WaitForExit();

            // writing test results also to the executable directory.
            processStartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory; 
            var process2 = Process.Start(processStartInfo);
            process2.WaitForExit();
            //var fixme3 = process2.StandardOutput.ReadToEnd();
            //var fixme4 = process2.StandardError.ReadToEnd();
        }


        public static IConfigurationBuilder GetSpecflowJsionBuilder()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
              .AddJsonFile("specflow.json");
            return builder;
        }

        public static string GetSetting(string setting, string key)
        {
            var builder = GetSpecflowJsionBuilder();
            var GetAppStringData = builder.Build().GetValue<string>(setting + ":" + key);
            return GetAppStringData;
        }
    }
}