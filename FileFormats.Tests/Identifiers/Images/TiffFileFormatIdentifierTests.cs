using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;
using FileFormats.Identifiers.Images;

using NUnit.Framework;

namespace FileFormats.Tests.Identifiers.Images
{
    [TestFixture]
    public class TiffFileFormatIdentifierTests : FileFormatIdentifierTestsBase
    {
        [Test]
        public void TryIdentify_TiffImage_ReturnsIdentifiedType()
        {
            var identifier = new TiffFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.tif");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.That(format, Is.InstanceOf<TiffFileFormat>());
        }

        [Test]
        public void TryIdentify_JpegImage_ReturnsNull()
        {
            var identifier = new TiffFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.jpg");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.Null(format);
        }

        [Test]
        public void TryIdentify_TiffImage_HasCorrectTraits()
        {
            var identifier = new TiffFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.tif");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());
            var traits = format.AllTraits().Where(trait => !(trait is NumberOfBytesUsedForIdentificationTrait));
            
            CollectionAssert.AreEquivalent(new object[] {
                new NameTrait("Tagged Image File Format"),
                new ShortNameTrait("TIFF"),
                new FileExtensionTrait(".tiff"),
                new FileExtensionTrait(".tif"),
                new MediaTypeTrait("image/tiff")
            }, traits);
        }
    }
}