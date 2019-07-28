using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Archives;
using FileFormats.Identifiers.Archives;

using NUnit.Framework;

namespace FileFormats.Tests.Identifiers.Archives
{
    [TestFixture]
    public class ZipFileFormatIdentifierTests : FileFormatIdentifierTestsBase
    {
        [Test]
        public void TryIdentify_ZipArchive_ReturnsIdentifiedType()
        {
            var identifier = new ZipFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.zip");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.That(format, Is.InstanceOf<ZipFileFormat>());
        }

        [Test]
        public void TryIdentify_Bzip2Archive_ReturnsNull()
        {
            var identifier = new ZipFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.bz2");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());

            Assert.Null(format);
        }

        [Test]
        public void TryIdentify_ZipArchive_HasCorrectTraits()
        {
            var identifier = new ZipFileFormatIdentifier();
            var fileContents = LoadFile("Samples.sample.zip");

            FileFormat format = identifier.TryIdentify(fileContents, Enumerable.Empty<object>());
            var traits = format.AllTraits().Where(trait => !(trait is NumberOfBytesUsedForIdentificationTrait));
            
            CollectionAssert.AreEquivalent(new object[] {
                new NameTrait("ZIP File Format"),
                new ShortNameTrait("ZIP"),
                new FileExtensionTrait(".zip"),
                new MediaTypeTrait("application/zip")
            }, traits);
        }
    }
}