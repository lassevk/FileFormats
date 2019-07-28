using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;
using FileFormats.Identifiers.Images;

using NUnit.Framework;

namespace FileFormats.Tests.Identifiers.Images
{
    [TestFixture]
    public class BmpFileFormatIdentifierTests : FileFormatIdentifierTestsBase
    {
        [Test]
        [TestCase("Samples.sample-monochrome.bmp")]
        [TestCase("Samples.sample-16-color.bmp")]
        [TestCase("Samples.sample-256-color.bmp")]
        [TestCase("Samples.sample-24-bit.bmp")]
        public void TryIdentify_BmpImage_ReturnsIdentifiedType(string sampleName)
        {
            var identifier = new BmpFileFormatIdentifier();
            var fileContents = LoadFile(sampleName);

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.That(format, Is.InstanceOf<BmpFileFormat>());
        }

        [Test]
        public void TryIdentify_JpegImage_ReturnsNull()
        {
            var identifier = new BmpFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.jpg");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.Null(format);
        }

        [Test]
        [TestCase("Samples.sample-monochrome.bmp")]
        [TestCase("Samples.sample-16-color.bmp")]
        [TestCase("Samples.sample-256-color.bmp")]
        [TestCase("Samples.sample-24-bit.bmp")]
        public void TryIdentify_BmpImage_HasCorrectTraits(string sampleName)
        {
            var identifier = new BmpFileFormatIdentifier();
            var fileContents = LoadFile(sampleName);

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());
            var traits = format.AllTraits().Where(trait => !(trait is NumberOfBytesUsedForIdentificationTrait));
            
            CollectionAssert.AreEquivalent(new object[] {
                new NameTrait("Bitmap Image File"),
                new ShortNameTrait("BMP"),
                new FileExtensionTrait(".bmp"),
                new MediaTypeTrait("image/bmp")
            }, traits);
        }
    }
}