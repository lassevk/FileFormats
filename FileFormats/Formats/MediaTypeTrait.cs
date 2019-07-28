using System;

namespace FileFormats.Formats
{
    public struct MediaTypeTrait
    {
        public MediaTypeTrait(string value) => Value = value ?? throw new ArgumentNullException(nameof(value));

        public string Value { get; }

        public override string ToString() => $"Media Type: {Value}";
    }
}