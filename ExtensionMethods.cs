using System;
using System.IO;
using SplashKitSDK;

namespace TombOfTheMask
{
    // Represents an ExtensionMethods class
    public static class ExtensionMethods
    {
        // Extension method for StreamReader that reads an integer
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }

        // Extension method for StreamReader that reads a single-precision floating-point number
        public static float ReadSingle(this StreamReader reader)
        {
            return Convert.ToSingle(reader.ReadLine());
        }

        // Extension method for StreamReader that reads a Color object
        public static Color ReadColor(this StreamReader reader)
        {
            return Color.RGBColor(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        // Extension method for StreamWriter that writes a Color object
        public static void WriteColor(this StreamWriter writer, Color clr)
        {
            writer.WriteLine("{0}\n{1}\n{2}", clr.R, clr.G, clr.B);
        }
    }
}
