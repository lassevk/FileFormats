using System.IO;

namespace FileFormats.Tests
{
    public abstract class FileFormatIdentifierTestsBase
    {
        protected byte[] LoadFile(string resourceName)
        {
            var type = GetType();
            using (var stream = type.Assembly.GetManifestResourceStream(type.Namespace + "." + resourceName))
            using (var temp = new MemoryStream())
            {
                stream.CopyTo(temp);
                return temp.ToArray();
            }
        }
    }
}