using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Omada.BDDSteps
{
    [Binding]
    class BeforeAfterSteps
    {
        public static string path = ConfigurationManager.AppSettings["ScreenshotPATH"] + DateTime.Now.ToString("ddMMyyyy");
        public static bool CreateScreenshot = Convert.ToBoolean(ConfigurationManager.AppSettings["CreateScreenshot"]);
        public string alreadyCreatedPath;

        //IWebDriver driver = Driver.driver;

        /*
        [BeforeScenario]
        public void Setup()
        {
            Driver.Initialize();
            if (CreateScreenshot)
                CreateFolderForScreenshots();



        }
        */
        [BeforeScenario]
        public void CreateFolderForScreenshots()
        {
            string scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            System.IO.Directory.CreateDirectory(path);
            string scenarioPath = path + "\\" + DateTime.Now.ToString("HHmm") + scenarioName;
            System.IO.Directory.CreateDirectory(scenarioPath);
            alreadyCreatedPath = scenarioPath;

            Log.log.Info("============================= " + scenarioName + " =============================");
            Log.log.Info("Screenshot path = "+ scenarioPath);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            Log.log.Info("=======================================================================");
            Log.log.Info("=======================================================================");

        }
        


        [AfterStep]
        public void AfterStepScreenshot()
        {
            string testStatus = ScenarioContext.Current.ScenarioExecutionStatus.ToString();
            string stepTitle = ScenarioContext.Current.StepContext.StepInfo.Text;
            Log.log.Info(stepTitle + " test status = " + testStatus);

            if (CreateScreenshot)
                CreateScreenShot();
        }

        public void CreateScreenShot()
        {

            Screenshot ss = ((ITakesScreenshot)Driver.driver).GetScreenshot();
            string testStatus = ScenarioContext.Current.ScenarioExecutionStatus.ToString();
            string stepTitle = ScenarioContext.Current.StepContext.StepInfo.Text;
            stepTitle = stepTitle.Replace(":", "_");
            string fileTitle = stepTitle.Replace(" ", "_");
            //string drive = path + DateTime.Now.ToString("yyyyMMdd_HHmm");

            string screenshotfilename = alreadyCreatedPath + "\\" + DateTime.Now.ToString("HHmmss") + fileTitle + ".png";
            //string screenshotfilename = drive + ".png";
            ss.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Png);

        }
        [BeforeScenario]
        public void DeletePDF()
        {
            Tools.DeleteFiles(ConfigurationManager.AppSettings["DownloadFolder"], "Omada-Case");
        }


    }
}
