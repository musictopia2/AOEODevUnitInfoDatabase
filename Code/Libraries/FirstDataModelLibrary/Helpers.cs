using CommonBasicStandardLibraries.CollectionClasses;
using System.Linq;

namespace FirstDataModelLibrary
{
    public static class Helpers
    {
        //this has helpres that helps in parsing.  this is regardless of what phase i am at.
        //looks like the animations part is the same.  worry about the immortal possible bugs later.
        public static CustomBasicList<double> GetAnimations(FullDatabaseModel model)
        {
            CustomBasicList<double> output = new CustomBasicList<double>();
            if (model.Animation1Hit1Durations != "")
            {
                output.Add(double.Parse(model.Animation1Hit1Durations));
            }
            if (model.Animation2Hit1Durations != "")
            {
                output.Add(double.Parse(model.Animation2Hit1Durations));
            }
            if (model.Animation3Durations != "")
            {
                output.Add(double.Parse(model.Animation3Durations));
            }
            if (model.Animation4Durations != "")
            {
                output.Add(double.Parse(model.Animation4Durations));
            }
            if (model.Animation5Durations != "")
            {
                output.Add(double.Parse(model.Animation5Durations));
            }
            if (model.Animation6Durations != "")
            {
                output.Add(double.Parse(model.Animation6Durations));
            }
            if (model.Animation7Durations != "")
            {
                output.Add(double.Parse(model.Animation7Durations));
            }
            if (model.Animation8Durations != "")
            {
                output.Add(double.Parse(model.Animation8Durations));
            }
            output.RemoveAllAndObtain(xxx => xxx == 0);
            return output;
        }

    }
}
