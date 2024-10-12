using Il2CppInterop.Runtime.InteropTypes.Arrays;
using NotEnoughFeatures;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;


namespace NotEnoughFeatures.Patches
{
    public static class Utils
    {



        private static Dictionary<byte, List<RoleBehaviour>> playerRolesHistory = new Dictionary<byte, List<RoleBehaviour>>();
        public static UnityEngine.SpriteRenderer myRend(this PlayerControl p) => p.cosmetics.currentBodySprite.BodySprite;


        public static Dictionary<string, Sprite> CachedSprites = new();

        public static PlayerControl PlayerById(byte id)
        {
            foreach (var player in PlayerControl.AllPlayerControls)
                if (player.PlayerId == id)
                    return player;

            return null;
        }

        public static List<RoleBehaviour> GetPlayerRolesHistory(byte playerId)
        {
            if (playerRolesHistory.ContainsKey(playerId))
            {
                return playerRolesHistory[playerId];
            }
            return new List<RoleBehaviour>();
        }

        public static RoleBehaviour GetPlayerLastRole(byte playerId)
        {
            if (playerRolesHistory.ContainsKey(playerId)) return playerRolesHistory[playerId].Last();
            return null;
        }

        public static void ClearPlayerRolesHistory() => playerRolesHistory.Clear();

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

        public static Sprite LoadSpriteIntoGame(string path, float pixelsPerUnit = 1f)
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

        public static Sprite loadSpriteFromResources(string path, float pixelsPerUnit, bool cache = true)
        {
            try
            {
                if (cache && CachedSprites.TryGetValue(path + pixelsPerUnit, out var sprite)) return sprite;
                Texture2D texture = LoadTextureFromResources(path);
                sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), pixelsPerUnit);
                if (cache) sprite.hideFlags |= HideFlags.HideAndDontSave | HideFlags.DontSaveInEditor;
                if (!cache) return sprite;
                return CachedSprites[path + pixelsPerUnit] = sprite;
            }
            catch
            {
                System.Console.WriteLine("Error loading sprite from path: " + path);
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
