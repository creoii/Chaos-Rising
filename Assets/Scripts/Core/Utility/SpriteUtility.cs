using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class SpriteUtility
{
    public static Sprite CreateSprite(string texturePath)
    {
        Texture2D texture = Resources.Load<Texture2D>(texturePath);
        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(.5f, .5f), 100f);
    }

    public static Sprite GetSprite(string path)
    {
        return Resources.Load<Sprite>(path);
    }

    public static Tile GetTile(string path)
    {
        return Resources.Load<Tile>(path);
    }

    public static void SetSprite(SpriteRenderer spriteRenderer, string path)
    {
        spriteRenderer.sprite = GetSprite(path);
    }

    public static void SetSprite(Image image, string path)
    {
        image.sprite = GetSprite(path);
    }
}