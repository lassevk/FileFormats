using System;
using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Archives;
using FileFormats.Formats.Images;

namespace FileFormats.Identifiers.Archives
{
    public class ZipFileFormatIdentifier : GenericFileFormatIdentifier, IFileFormatIdentifier
    {
        private static readonly byte?[] _Pattern = { (byte)'P', (byte)'K', 0x03, 0x04 };

        public int NumberOfBytesNeededForIdentification => _Pattern.Length;

        public FileFormat TryIdentify(Span<byte> fileContents, IEnumerable<object> traits)
            => IsMatch(fileContents, _Pattern)
                ? new ZipFileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(_Pattern.Length)))
                : null;
    }
}