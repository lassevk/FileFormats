using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats.Images;

namespace FileFormats.Formats.Archives
{
    public class ZipFileFormat : ImageFileFormat
    {
        public ZipFileFormat(IEnumerable<object> traits)
            : base(traits.Concat(DefaultTraits()))
        {
        }

        private static IEnumerable<object> DefaultTraits()
        {
            yield return new NameTrait("ZIP File Format");
            yield return new ShortNameTrait("ZIP");
            yield return new FileExtensionTrait(".zip");
            yield return new MediaTypeTrait("application/zip");
        }
    }
}