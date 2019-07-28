using System.Collections.Generic;
using System.Linq;

namespace FileFormats.Formats.Images
{
    public class JfifFileFormat : ImageFileFormat
    {
        public JfifFileFormat(IEnumerable<object> traits)
            : base(traits.Concat(DefaultTraits()))
        {
        }

        private static IEnumerable<object> DefaultTraits()
        {
            yield return new NameTrait("JPEG File Interchange Format");
            yield return new ShortNameTrait("JFIF");
            yield return new FileExtensionTrait(".jpeg");
            yield return new FileExtensionTrait(".jpg");
            yield return new MediaTypeTrait("image/jpeg");
        }
    }
}