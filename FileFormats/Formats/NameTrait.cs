using System;

namespace FileFormats.Formats
{
    public struct NameTrait
    {
        public NameTrait(string value) => Value = value ?? throw new ArgumentNullException(nameof(value));

        public string Value { get; }

        public override string ToString() => $"Name: {Value}";
    }
}