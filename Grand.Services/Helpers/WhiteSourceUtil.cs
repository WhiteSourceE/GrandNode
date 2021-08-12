using System;
using System.IO;

namespace Grand.Services.Helpers
{
    public static class WhiteSourceUtil
    {
        public static bool isSubDirectory(String basePath, String childPath)
        {
            if (IsValidPath(basePath) && IsValidPath(childPath))
            {
                if (Path.GetFullPath(childPath).StartsWith(Path.GetFullPath(basePath), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static bool isSubDirectory(String childPath)
        {
            return isSubDirectory(GetBaseDirectory(), childPath);
        }

        private static string GetBaseDirectory()
        {
            return Environment.CurrentDirectory;
        }

        private static bool IsValidPath(string path)
        {
            if (path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                return false;
            }

            return true;
        }
    }
}
