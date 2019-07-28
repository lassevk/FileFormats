using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;
using FileFormats.Identifiers.Images;

using NUnit.Framework;

namespace FileFormats.Tests.Identifiers.Images
{
    [TestFixture]
    public class JfifFileFormatIdentifierTests : FileFormatIdentifierTestsBase
    {
        [Test]
        public void TryIdentify_JpegImage_ReturnsIdentifiedType()
        {
            var identifier = new JfifFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.jpg");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.That(format, Is.InstanceOf<JfifFileFormat>());
        }

        [Test]
        public void TryIdentify_PngImage_ReturnsNull()
        {
            var identifier = new JfifFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.png");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.Null(format);
        }

        [Test]
        public void TryIdentify_JpegImage_HasCorrectTraits()
        {
            var identifier = new JfifFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.jpg");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());
            var traits = format.AllTraits().Where(trait => !(trait is NumberOfBytesUsedForIdentificationTrait));
            
            CollectionAssert.AreEquivalent(new object[] {
                new NameTrait("JPEG File Interchange Format"),
                new ShortNameTrait("JFIF"),
                new FileExtensionTrait(".jpeg"),
                new FileExtensionTrait(".jpg"),
                new MediaTypeTrait("image/jpeg")
            }, traits);
        }
    }
}