using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;


namespace PhantomPlus.Patches
{
    public static class Utils
    {

        private static readonly Dictionary<string, Sprite> CachedSprites;
        public static Sprite LoadSprite(string path, float pixelsPerUnit = 1f)
        {
            try
            {
                if (CachedSprites.TryGetValue(path + pixelsPerUnit, out var sprite)) return sprite;
                Texture2D texture = LoadTextureFromResources(path);
                sprite = Sprite.Create(texture, new(0, 0, texture.width, texture.height), new(0.5f, 0.5f), pixelsPerUnit);
                sprite.hideFlags |= HideFlags.HideAndDontSave | HideFlags.DontSaveInEditor;
                return CachedSprites[path + pixelsPerUnit] = sprite;
            }
            catch
            {
            }

            return null;
        }
        public static Texture2D LoadTextureFromResources(string path)
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
                var texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
                using MemoryStream ms = new();
                stream?.CopyTo(ms);
                ImageConversion.LoadImage(texture, ms.ToArray(), false);
                return texture;
            }
            catch
            {
            }

            return null;
        }
    }
}
