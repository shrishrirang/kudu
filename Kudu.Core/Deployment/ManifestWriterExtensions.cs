﻿using System.Collections.Generic;
using System.IO;

namespace Kudu.Core.Deployment
{
    public static class ManifestWriterExtensions
    {
        public static void AddFiles(this IDeploymentManifestWriter writer, string directory)
        {
            var paths = GetPaths(directory);
            writer.AddPaths(paths);
        }

        private static IEnumerable<string> GetPaths(string directory)
        {
            foreach (var path in Directory.GetFileSystemEntries(directory, "*.*", SearchOption.AllDirectories))
            {
                yield return path.Substring(directory.Length).TrimStart('\\');
            }
        }
    }
}
