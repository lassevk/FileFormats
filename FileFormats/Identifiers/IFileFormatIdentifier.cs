using System;
using System.Collections.Generic;

using FileFormats.Formats;

namespace FileFormats.Identifiers
{
    public interface IFileFormatIdentifier
    {
        int NumberOfBytesNeededForIdentification { get; }

        FileFormat TryIdentify(Span<byte> fileContents, IEnumerable<object> additionalTraits);
    }
}