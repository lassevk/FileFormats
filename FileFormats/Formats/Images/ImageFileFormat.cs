using System.Collections.Generic;

namespace FileFormats.Formats.Images
{
    public abstract class ImageFileFormat : FileFormat
    {
        protected ImageFileFormat(IEnumerable<object> traits)
            : base(traits)
        {
        }
    }
}