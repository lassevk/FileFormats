using System;
using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;

namespace FileFormats.Identifiers.Images
{
    public class PngFileFormatFormatIdentifier : GenericFileFormatIdentifier, IFileFormatIdentifier
    {
        private static readonly byte?[] _Pattern = { 0x89, (byte)'P', (byte)'N', (byte)'G', (byte)'\r', (byte)'\n', 0x1a, (byte)'\n' };

        public int NumberOfBytesNeededForIdentification => _Pattern.Length;

        public FileFormat TryIdentify(Span<byte> fileContents, IEnumerable<object> traits)
            => IsMatch(fileContents, _Pattern)
                ? new PngFileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(_Pattern.Length)))
                : null;
    }
}