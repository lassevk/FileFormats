using System;

namespace FileFormats.Formats
{
    public struct ShortNameTrait
    {
        public ShortNameTrait(string value) => Value = value ?? throw new ArgumentNullException(nameof(value));

        public string Value { get; }

        public override string ToString() => $"Short Name: {Value}";
    }
}