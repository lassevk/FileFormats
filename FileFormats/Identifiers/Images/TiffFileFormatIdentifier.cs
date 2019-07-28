using System;
using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;

namespace FileFormats.Identifiers.Images
{
    public class TiffFileFormatIdentifier : GenericFileFormatIdentifier, IFileFormatIdentifier
    {
        private static readonly byte?[] _Pattern1 = { (byte)'I', (byte)'I', 0x2a, 0x00 };
        private static readonly byte?[] _Pattern2 = { (byte)'M', (byte)'M', 0x00, 0x2a };

        public int NumberOfBytesNeededForIdentification => Math.Max(_Pattern1.Length, _Pattern2.Length);

        public FileFormat TryIdentify(Span<byte> fileContents, IEnumerable<object> traits)
        {
            if (IsMatch(fileContents, _Pattern1))
                return new TiffFileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(_Pattern1.Length)));

            if (IsMatch(fileContents, _Pattern2))
                return new TiffFileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(_Pattern2.Length)));

            return null;
        }
    }
}