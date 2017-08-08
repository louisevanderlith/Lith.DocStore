using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lith.DocStore
{
    public class KeyRing : IDisposable
    {
        public IEnumerable<KeyOnRing> Keys { get; private set; }

        public KeyRing()
        {
            Keys = PopulateKeys();
        }

        public IEnumerable<KeyOnRing> GetKeysInSection(string sectionName)
        {
            var result = from k in Keys
                         where k.Section == sectionName.ToLower()
                         select k;

            return result;
        }

        private IEnumerable<KeyOnRing> PopulateKeys()
        {
            var result = new List<KeyOnRing>();

            var rawKeys = GetKeys();

            foreach (var key in rawKeys)
            {
                var trueKey = Guid.Empty;
                var validKey = Guid.TryParse(key.Key, out trueKey);

                if (validKey && trueKey != Guid.Empty)
                {
                    var nextOnRing = new KeyOnRing { ID = trueKey, Section = key.Value };

                    result.Add(nextOnRing);
                }
            }

            return result;
        }

        private static IDictionary<string, string> GetKeys()
        {
            var result = new Dictionary<string, string>();
            var recordsPath = Environment.CurrentDirectory + @"\records";

            if (Directory.Exists(recordsPath))
            {
                var directoryInfo = new DirectoryInfo(recordsPath);
                var directories = directoryInfo.GetDirectories();

                foreach (var directory in directories)
                {
                    var files = directory.GetFiles();

                    foreach (var file in files)
                    {
                        result.Add(file.Name, directory.Name);
                    }
                }
            }

            return result;
        }

        public void Dispose()
        {
            Keys = null;
        }
    }
}
