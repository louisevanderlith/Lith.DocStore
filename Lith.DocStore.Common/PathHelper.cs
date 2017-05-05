namespace Lith.DocStore.Common
{
    public static class PathHelper
    {
        public static string StripFileName(string path)
        {
            var lastPartIndex = path.LastIndexOf('\\');

            return path.Substring(0, lastPartIndex);
        }
    }
}
