using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HasHealth))]
public class DamageOverlay : MonoBehaviour {
    public Texture2D overlayTexture;
    public float overlayTime = 1;
    Rect position;
    float lastHealth = float.NegativeInfinity;
    float timeSinceLastDamage = float.PositiveInfinity;

    void Start()
    {
        position = new Rect(
            x: 0,
            y: 0,
            width: Screen.width,
            height: Screen.height);
    }
    
    void Update()
    {
        var hp = gameObject.GetComponent<HasHealth>();
        if (hp.currentHp < lastHealth)
        {
            timeSinceLastDamage = 0;
        }
        lastHealth = hp.currentHp;
        timeSinceLastDamage += Time.deltaTime;
    }

    void OnGUI()
    {
        if (timeSinceLastDamage < overlayTime)
        {
            Color newColor = new Color(1, 1, 1, 1 - timeSinceLastDamage / overlayTime);
            Utils.WithGuiColor(newColor, () => GUI.DrawTexture(position, overlayTexture));
        }
    }
}
