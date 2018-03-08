using System;
using System.Collections.Generic;
using System.IO;

namespace Lith.DocStore
{
    public class KeyForge : IEqualityComparer<KeyForge>
    {
        private readonly string modelName;
        private readonly Guid recordID;

        private string keyPath;

        public KeyForge(string modelName)
        {
            this.modelName = modelName;
        }

        public KeyForge(string modelName, Guid recordID)
        {
            this.modelName = modelName;
            this.recordID = recordID;

            CreateKey();
        }

        public string Key { get; private set; }

        private void CreateKey()
        {
            var result = string.Empty;
            var keyTemplate = "{0}_{1}";

            Key = string.Format(keyTemplate, modelName.ToLower(), recordID);
            GetKeyPath();
        }

        public void SubmitKey(string data)
        {
            var pathWithoutFile = PathHelper.StripFileName(keyPath);

            Directory.CreateDirectory(pathWithoutFile);
            File.WriteAllText(keyPath, data);
        }

        public string LoadKeyData()
        {
            var result = string.Empty;

            if (KeyExists())
            {
                result = File.ReadAllText(keyPath);
            }

            return result;
        }

        public bool KeyExists()
        {
            var result = false;

            var pathWithoutFile = PathHelper.StripFileName(keyPath);

            if (Directory.Exists(pathWithoutFile))
            {
                result = File.Exists(keyPath);
            }

            return result;
        }

        public string GetKeyPath()
        {
            if (string.IsNullOrWhiteSpace(keyPath))
            {
                var keyParts = Key.Split('_');
                var currentPath = Environment.CurrentDirectory;
                var pathTemplate = @"{0}\records\{1}\{2}";

                keyPath = string.Format(pathTemplate, currentPath, keyParts[0], keyParts[1]);
            }

            return keyPath;
        }

        public bool Equals(KeyForge x, KeyForge y)
        {
            return x.Key == y.keyPath;
        }

        public int GetHashCode(KeyForge obj)
        {
            return obj.Key.GetHashCode();
        }
    }
}
