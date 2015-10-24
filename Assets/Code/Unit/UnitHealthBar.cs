using UnityEngine;

[RequireComponent(typeof(HasHealth))]
public class UnitHealthBar : MonoBehaviour
{
    void OnGUI()
    {
        var hp = gameObject.GetComponent<HasHealth>();
        if (transform != null && Camera.current != null)
        {
            Vector3 screenPosition = Camera.current.WorldToScreenPoint(transform.position);
            if (screenPosition.z > 0)
            {
                screenPosition.y = Screen.height - (screenPosition.y + 1);
                Rect rect = new Rect(screenPosition.x - 50, screenPosition.y - 12, 100, 24);
                GUI.Box(rect, hp.currentHp + "/" + hp.maxHealth);
            }
        }
    }
}
