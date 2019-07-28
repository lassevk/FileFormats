using System;
using System.Collections.Generic;
using System.Linq;

using FileFormats.Formats;
using FileFormats.Identifiers;

namespace FileFormats
{
    public static class FileFormatIdentifierRegistry
    {
        static FileFormatIdentifierRegistry()
        {
            Type requiredInterfaceType = typeof(IFileFormatIdentifier);
            var identifiers =
                from type in typeof(FileFormat).Assembly.GetTypes()
                where !type.IsAbstract && requiredInterfaceType.IsAssignableFrom(type)
                let identifier = Activator.CreateInstance(type) as IFileFormatIdentifier
                where identifier != null
                select identifier;

            Identifiers = new HashSet<IFileFormatIdentifier>(identifiers);
        }

        public static HashSet<IFileFormatIdentifier> Identifiers { get; }
    }
}