using System;
using System.IO;
using System.Reflection;

namespace Zen.Utilities
{
    public static class ResourceReader
    {
        public static string ReadResource(string resourceName, Assembly assemblyToReadFrom)
        {
            using var stream = assemblyToReadFrom.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream ?? throw new InvalidOperationException($"Failed to get stream for [{resourceName}] from Assembly [{assemblyToReadFrom.FullName}]"));
            var result = reader.ReadToEnd();

            return result;
        }
    }
}