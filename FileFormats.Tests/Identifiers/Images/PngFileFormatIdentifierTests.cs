using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;
using FileFormats.Identifiers.Images;

using NUnit.Framework;

namespace FileFormats.Tests.Identifiers.Images
{
    [TestFixture]
    public class PngFileFormatIdentifierTests : FileFormatIdentifierTestsBase
    {
        [Test]
        public void TryIdentify_PngImage_ReturnsIdentifiedType()
        {
            var identifier = new PngFileFormatFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.png");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.That(format, Is.InstanceOf<PngFileFormat>());
        }

        [Test]
        public void TryIdentify_JpegImage_ReturnsNull()
        {
            var identifier = new PngFileFormatFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.jpg");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.Null(format);
        }

        [Test]
        public void TryIdentify_PngImage_HasCorrectTraits()
        {
            var identifier = new PngFileFormatFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.png");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());
            var traits = format.AllTraits().Where(trait => !(trait is NumberOfBytesUsedForIdentificationTrait));
            
            CollectionAssert.AreEquivalent(new object[] {
                new NameTrait("Portable Network Graphics"),
                new ShortNameTrait("PNG"),
                new FileExtensionTrait(".png"),
                new MediaTypeTrait("image/png")
            }, traits);
        }
    }
}