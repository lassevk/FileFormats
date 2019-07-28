using System.Collections.Generic;
using System.Linq;

namespace FileFormats.Formats.Images
{
    public class TiffFileFormat : ImageFileFormat
    {
        public TiffFileFormat(IEnumerable<object> traits)
            : base(traits.Concat(DefaultTraits()))
        {
        }

        private static IEnumerable<object> DefaultTraits()
        {
            yield return new NameTrait("Tagged Image File Format");
            yield return new ShortNameTrait("TIFF");
            yield return new FileExtensionTrait(".tif");
            yield return new FileExtensionTrait(".tiff");
            yield return new MediaTypeTrait("image/tiff");
        }
    }
}