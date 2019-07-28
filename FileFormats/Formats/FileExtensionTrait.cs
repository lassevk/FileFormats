using System;

namespace FileFormats.Formats
{
    public struct FileExtensionTrait
    {
        public FileExtensionTrait(string value) => Value = value ?? throw new ArgumentNullException(nameof(value));

        public string Value { get; }

        public override string ToString() => $"File Extension: {Value}";
    }
}