using System;
using aa = CommonBasicStandardLibraries.BasicDataSettingsAndProcesses.ApplicationPath;
using ff = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileFunctions;
namespace CaptureFirstData
{
    class Program
    {
        static void Main()
        {

            string results = GetTestPath();
            if (ff.FileExists(results) == false)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine("Good Job");
            }

            Console.WriteLine(results);
            //Console.WriteLine(path);
        }


        static string GetTestPath()
        {
            //C:\VS\Net5\BlazorAOEO\AOEODevUnitInfoDatabase\Code\Parsers\CaptureFirstData\bin\Debug\net5.0\
            string lookFor = "AOEODevUnitInfoDatabase";

            string path = aa.GetApplicationPath();

            int finds = path.IndexOf(lookFor);

            string modified = path.Substring(0, finds);
            modified += lookFor += @"\";

            string name = @"RawData\ExcelDatabase.txt";
            modified += name;

            return modified;


        }

    }
}
