using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats.Images;

namespace FileFormats.Formats.Video
{
    public class Mp4FileFormat : ImageFileFormat
    {
        public Mp4FileFormat(IEnumerable<object> traits)
            : base(traits.Concat(DefaultTraits()))
        {
        }

        private static IEnumerable<object> DefaultTraits()
        {
            yield return new NameTrait("MPEG-4 Part 14");
            yield return new ShortNameTrait("MP4");
            yield return new FileExtensionTrait(".mp4");
            yield return new MediaTypeTrait("video/mp4");
        }
    }
}