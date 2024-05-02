using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Spin.Manager
{
    public class SpriteAtlasManager : MonoBehaviour, ISpriteAtlasManager
    {
        public SpriteAtlas spriteAtlas; 
        private Dictionary<string, Sprite> spriteDictionary = new Dictionary<string, Sprite>();
        public void AddSprite(string spriteName, SpriteRenderer image)
        {
            if (spriteAtlas == null)
            {
                Debug.LogError("Sprite Atlas is not assigned!");
                return;
            }

            if (!spriteDictionary.ContainsKey(spriteName))
            {
                Sprite sprite = spriteAtlas.GetSprite(spriteName);
                if (sprite != null)
                {
                    image.sprite = sprite;
                    spriteDictionary.Add(spriteName, sprite);
                }
                else
                {
                    Debug.LogError("Sprite not found in the Sprite Atlas: " + spriteName);
                }
            }
            else
            {
                image.sprite = spriteDictionary[spriteName];
            }
        }

        public void AddSprite(string spriteName, Image image)
        {
            if (spriteAtlas == null)
            {
                Debug.LogError("Sprite Atlas is not assigned!");
                return;
            }
            if (image == null)
            {
                Debug.LogError("Image is not assigned!");
                return;
            }

            if (!spriteDictionary.ContainsKey(spriteName))
            {
                Sprite sprite = spriteAtlas.GetSprite(spriteName);
                if (sprite != null)
                {
                    image.sprite = sprite;
                    spriteDictionary.Add(spriteName, sprite);
                }
                else
                {
                    Debug.LogError("Sprite not found in the Sprite Atlas: " + spriteName);
                }
            }
            else
            {
                image.sprite = spriteDictionary[spriteName];
            }
        }
    }

    public interface ISpriteAtlasManager
    {
        void AddSprite(string spriteName, SpriteRenderer image);
        void AddSprite(string spriteName, Image image);
    }
}