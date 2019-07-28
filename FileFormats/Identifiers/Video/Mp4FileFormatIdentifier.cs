using System;
using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Formats.Archives;
using FileFormats.Formats.Video;

namespace FileFormats.Identifiers.Video
{
    public class Mp4FileFormatIdentifier : GenericFileFormatIdentifier, IFileFormatIdentifier
    {
        private static readonly byte?[][] _Patterns = {
            new byte?[]
            {
                null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'a', (byte)'v', (byte)'c', (byte)'1'
            },
            new byte?[]
            {
                null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'m', (byte)'p', (byte)'4', (byte)'2'
            },
            new byte?[]
            {
                null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'3', (byte)'g', (byte)'p', (byte)'5'
            }
        };

        public int NumberOfBytesNeededForIdentification => _Patterns.Max(s => s.Length);

        public FileFormat TryIdentify(Span<byte> fileContents, IEnumerable<object> traits)
        {
            foreach (var pattern in _Patterns)
                if (IsMatch(fileContents, pattern))
                    return new Mp4FileFormat(traits.Append(new NumberOfBytesUsedForIdentificationTrait(pattern.Length)));

            return null;
        }
    }
}