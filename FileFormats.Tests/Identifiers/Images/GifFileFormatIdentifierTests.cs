using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;
using FileFormats.Identifiers.Images;

using NUnit.Framework;

namespace FileFormats.Tests.Identifiers.Images
{
    [TestFixture]
    public class GifFileFormatIdentifierTests : FileFormatIdentifierTestsBase
    {
        [Test]
        public void TryIdentify_JpegImage_ReturnsIdentifiedType()
        {
            var identifier = new GifFileFormatFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.gif");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.That(format, Is.InstanceOf<GifFileFormat>());
        }

        [Test]
        public void TryIdentify_PngImage_ReturnsNull()
        {
            var identifier = new GifFileFormatFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.png");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.Null(format);
        }

        [Test]
        public void TryIdentify_GifImage_HasCorrectTraits()
        {
            var identifier = new GifFileFormatFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.gif");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());
            var traits = format.AllTraits().Where(trait => !(trait is NumberOfBytesUsedForIdentificationTrait));
            
            CollectionAssert.AreEquivalent(new object[] {
                new NameTrait("Graphics Interchange Format"),
                new ShortNameTrait("GIF"),
                new FileExtensionTrait(".gif"),
                new MediaTypeTrait("image/gif")
            }, traits);
        }
    }
}