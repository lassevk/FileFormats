namespace FileFormats.Formats
{
    public struct NumberOfBytesUsedForIdentificationTrait
    {
        public NumberOfBytesUsedForIdentificationTrait(int value) => Value = value;

        public int Value { get; }

        public override string ToString() => $"Number of bytes used for identification: {Value}";
    }
}