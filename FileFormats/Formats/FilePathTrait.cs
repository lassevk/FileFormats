namespace FileFormats.Formats
{
    public struct FilePathTrait
    {
        public FilePathTrait(string value) => Value = value;

        public string Value { get; }

        public override string ToString() => $"File Path: {Value}";
    }
}