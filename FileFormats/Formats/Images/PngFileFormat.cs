using System.Collections.Generic;
using System.Linq;

namespace FileFormats.Formats.Images
{
    public class PngFileFormat : ImageFileFormat
    {
        public PngFileFormat(IEnumerable<object> traits)
            : base(traits.Concat(DefaultTraits()))
        {
        }

        private static IEnumerable<object> DefaultTraits()
        {
            yield return new NameTrait("Portable Network Graphics");
            yield return new ShortNameTrait("PNG");
            yield return new FileExtensionTrait(".png");
            yield return new MediaTypeTrait("image/png");
        }
    }
}