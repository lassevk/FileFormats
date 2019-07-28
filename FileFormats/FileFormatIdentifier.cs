using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Identifiers;

namespace FileFormats
{
    public class FileFormatIdentifier
    {
        private readonly List<IFileFormatIdentifier> _Identifiers;
        
        public FileFormatIdentifier()
            : this(FileFormatIdentifierRegistry.Identifiers)
        {
        }

        public FileFormatIdentifier(IEnumerable<IFileFormatIdentifier> identifiers)
        {
            if (identifiers == null)
                throw new ArgumentNullException(nameof(identifiers));

            _Identifiers = identifiers.ToList();
        }

        private IEnumerable<FileFormat> IdentifyImpl(Span<byte> fileContents, IEnumerable<object> traits)
        {
            var result = new List<FileFormat>();
            var traitsList = traits.ToList();
            foreach (var identifier in _Identifiers)
            {
                var identifiedFileType = identifier.TryIdentify(fileContents, traitsList);
                if (identifiedFileType != null)
                    result.Add(identifiedFileType);
            }

            result.Sort(
                delegate(FileFormat ift1, FileFormat ift2)
                {
                    var t1 = ift1.Traits<NumberOfBytesUsedForIdentificationTrait>().FirstOrDefault().Value;
                    var t2 = ift2.Traits<NumberOfBytesUsedForIdentificationTrait>().FirstOrDefault().Value;
                    return -t1.CompareTo(t2);
                });
            return result;
        }

        public IEnumerable<FileFormat> Identify(Span<byte> fileContents, IEnumerable<object> traits = null)
        {
            traits = traits ?? Enumerable.Empty<object>();

            var allTraits = traits.Append(new FileSizeTrait(fileContents.Length));
            
            return IdentifyImpl(fileContents, allTraits);
        }

        public IEnumerable<FileFormat> Identify(string filePath, IEnumerable<object> traits = null)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            traits = traits ?? Enumerable.Empty<object>();

            using (var stream = File.OpenRead(filePath))
            {
                var allTraits = traits.Append(new FilePathTrait(filePath));
                return Identify(stream, allTraits);
            }
        }

        public IEnumerable<FileFormat> Identify(Stream stream, IEnumerable<object> traits = null)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            traits = traits ?? Enumerable.Empty<object>();

            if (!stream.CanRead)
                throw new ArgumentException($"{nameof(stream)} must be readable");
            
            int bufferSize = _Identifiers.Max(identifier => identifier.NumberOfBytesNeededForIdentification);
            var buffer = new byte[bufferSize];
            int inBuffer = stream.Read(buffer, 0, bufferSize);
            var span = buffer.AsSpan();
            if (inBuffer < bufferSize)
                span = span.Slice(0, inBuffer);

            traits = traits.Append(new FileSizeTrait(stream.Length));

            return Identify(span, traits);
        }
    }
}