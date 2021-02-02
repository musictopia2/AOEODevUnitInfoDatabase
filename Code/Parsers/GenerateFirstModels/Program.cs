using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.Misc;
using CommonBasicStandardLibraries.BasicDataSettingsAndProcesses;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using System;
using ff = DataLocationLibrary.FileHelperClass;
using fs = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileFunctions;
using ll = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.FileFunctions.FileLocator;
namespace GenerateFirstModels
{
    class Program
    {
        static void Main()
        {
            ff.Setup();
            //GenerateUpgradeModel();
            GenerateDatabaseModel();
            
        }

        static void GenerateDatabaseModel()
        {
            CustomBasicList<string> list = GetFields(ff.DatabaseHeaders);

            CreateModel(ff.DatabaseModelLocation, list);
            Console.WriteLine("Done For Now");

        }


        static CustomBasicList<string> GetFields(string location)
        {
            string path = ll.GetLocation(location);
            string firsts = fs.AllText(path);
            CustomBasicList<string> output = firsts.Split(Constants.vbTab).ToCustomBasicList();
            return output;
        }

        
        private static string CleanUpText(string text)
        {
            text = text.Replace(Constants.vbCrLf, "");
            text = text.Replace(":", "");
            text = text.Replace("/", " ");
            text = text.ConvertCase();
            text = text.Replace(" ", "");
            text = text.Replace("(%", "");
            text = text.Replace("(", "");
            text = text.Replace(")", "");
            text = text.Replace("<1=", "");
            text = text.Replace("=CritDamageAnimation1", "");
            return text;
        }

        static void CreateModel(string name, CustomBasicList<string> list)
        {
            CustomBasicList<string> newList = new CustomBasicList<string>();
            list.ForEach(item =>
            {
                string value = CleanUpText(item);
                newList.Add(value);
            });
            StrCat cats = new StrCat();
            //public string Civ { get; set; } = "";
            newList.ForEach(item =>
            {
                string partText = "{get; set; }";
                cats.AddToString($"public string {item} {partText} = {Constants.DoubleQuote}{Constants.DoubleQuote};", Constants.vbCrLf);
            });
            string results = cats.GetInfo();
            string path = ll.GetLocation(name);
            fs.WriteAllText(path, results);

        }

        static void GenerateUpgradeModel()
        {
            
            CustomBasicList<string> list = GetFields(ff.ExcelUpgradeHeaders);
            CreateModel(ff.UpgradeModelLocation, list);
            Console.WriteLine("Done For Now");
        }

        //since this is one time use, not worth creating a class library for it.


    }
}
