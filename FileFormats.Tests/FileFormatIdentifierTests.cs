using System.Linq;

using FileFormats.Formats.Images;

using NUnit.Framework;

namespace FileFormats.Tests
{
    [TestFixture]
    public class FileFormatIdentifierTests : FileFormatIdentifierTestsBase
    {
        [Test]
        public void Identify_JpegImage_ReturnsIdentifiedFileType()
        {
            var identifier = new FileFormatIdentifier();
            var fileContents = LoadFile("Identifiers.Images.Samples.sample.jpg");

            var ifts = identifier.Identify(fileContents).ToList();

            Assert.That(ifts.Count, Is.EqualTo(1));
            Assert.That(ifts[0], Is.InstanceOf<JfifFileFormat>());
        }
    }
}