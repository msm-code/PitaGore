using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairTexture;
    public float scale = 1;
    private Rect position;

    void Start()
    {
        Vector2 realSize = new Vector2(crosshairTexture.width, crosshairTexture.height) * scale;

        position = new Rect(
            x: (Screen.width - realSize.x) / 2,
            y: (Screen.height - realSize.y) / 2,
            width: realSize.x,
            height: realSize.y);
    }

    void OnGUI()
    {
        GUI.DrawTexture(position, crosshairTexture);
    }
}