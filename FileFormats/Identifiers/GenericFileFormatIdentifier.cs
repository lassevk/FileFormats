using System;

namespace FileFormats.Identifiers
{
    public abstract class GenericFileFormatIdentifier
    {
        protected bool IsMatch(Span<byte> fileContents, byte?[] pattern)
        {
            if (fileContents.Length < pattern.Length)
                return false;
            
            for (int index = 0; index < pattern.Length; index++)
                if (pattern[index].HasValue && fileContents[index] != pattern[index].GetValueOrDefault())
                    return false;

            return true;
        }
    }
}