using System.Collections.Generic;
using System.Linq;

namespace FileFormats.Formats.Images
{
    public class GifFileFormat : ImageFileFormat
    {
        public GifFileFormat(IEnumerable<object> traits)
            : base(traits.Concat(DefaultTraits()))
        {
        }
        
        private static IEnumerable<object> DefaultTraits()
        {
            yield return new NameTrait("Graphics Interchange Format");
            yield return new ShortNameTrait("GIF");
            yield return new FileExtensionTrait(".gif");
            yield return new MediaTypeTrait("image/gif");
        }
    }
}