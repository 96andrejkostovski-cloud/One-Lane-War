using System;
using UnityEngine;

namespace OneLaneWar.Presentation
{
    public static class ContentResources
    {
        public static Content Load()
        {
            return Content.Load(path => {
                string name = path == "SOURCE_MANIFEST.json" ? "SOURCE_MANIFEST" : System.IO.Path.GetFileNameWithoutExtension(path);
                var asset = Resources.Load<TextAsset>("Canonical/" + name);
                if (asset == null) throw new InvalidOperationException("CONTENT_RESOURCE_MISSING: " + name);
                return asset.bytes;
            });
        }
    }
}
