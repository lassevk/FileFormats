namespace FileFormats.Formats
{
    public struct FileSizeTrait
    {
        public FileSizeTrait(long value) => Value = value;

        public long Value { get; }

        public override string ToString() => $"File Size: {Value}";
    }
}