using System.Collections.Generic;
using System.Linq;

namespace FileFormats.Formats.Images
{
    public class BmpFileFormat : ImageFileFormat
    {
        public BmpFileFormat(IEnumerable<object> traits)
            : base(traits.Concat(DefaultTraits()))
        {
        }

        private static IEnumerable<object> DefaultTraits()
        {
            yield return new NameTrait("Bitmap Image File");
            yield return new ShortNameTrait("BMP");
            yield return new FileExtensionTrait(".bmp");
            yield return new MediaTypeTrait("image/bmp");
        }
    }
}