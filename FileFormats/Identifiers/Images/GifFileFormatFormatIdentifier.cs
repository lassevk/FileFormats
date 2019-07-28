using System;
using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Images;

namespace FileFormats.Identifiers.Images
{
    public class GifFileFormatFormatIdentifier : GenericFileFormatIdentifier, IFileFormatIdentifier
    {
        private static readonly byte?[] _Pattern1 = { (byte)'G', (byte)'I', (byte)'F', (byte)'8', (byte)'7', (byte)'a' };
        private static readonly byte?[] _Pattern2 = { (byte)'G', (byte)'I', (byte)'F', (byte)'8', (byte)'9', (byte)'a' };

        public int NumberOfBytesNeededForIdentification => Math.Max(_Pattern1.Length, _Pattern2.Length);

        public FileFormat TryIdentify(Span<byte> fileContents, IEnumerable<object> traits)
        {
            if (IsMatch(fileContents, _Pattern1))
                return new GifFileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(_Pattern1.Length)));

            if (IsMatch(fileContents, _Pattern2))
                return new GifFileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(_Pattern2.Length)));

            return null;
        }
    }
}