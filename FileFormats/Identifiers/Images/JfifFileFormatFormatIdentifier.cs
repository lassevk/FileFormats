using System;
using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;

namespace FileFormats.Identifiers.Images
{
    public class JfifFileFormatFormatIdentifier : GenericFileFormatIdentifier, IFileFormatIdentifier
    {
        private static readonly byte?[] _Pattern = { 0xff, 0xd8 };

        public int NumberOfBytesNeededForIdentification => _Pattern.Length;

        public FileFormat TryIdentify(Span<byte> fileContents, IEnumerable<object> traits)
            => IsMatch(fileContents, _Pattern)
                ? new JfifFileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(_Pattern.Length)))
                : null;
    }
}