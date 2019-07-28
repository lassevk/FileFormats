using System;
using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;

namespace FileFormats.Identifiers.Images
{
    public class BmpFileFormatFormatIdentifier : GenericFileFormatIdentifier, IFileFormatIdentifier
    {
        private static readonly byte?[] _Pattern = { (byte)'B', (byte)'M' };

        public int NumberOfBytesNeededForIdentification => _Pattern.Length;

        public FileFormat TryIdentify(Span<byte> fileContents, IEnumerable<object> traits)
            => IsMatch(fileContents, _Pattern)
                ? new BmpFileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(_Pattern.Length)))
                : null;
    }
}