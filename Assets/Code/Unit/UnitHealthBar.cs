using UnityEngine;

[RequireComponent(typeof(HasHealth))]
public class UnitHealthBar : MonoBehaviour
{
    public GameObject playerObject;

    public void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    void OnGUI()
    {
        var hp = gameObject.GetComponent<HasHealth>();
        if (transform != null && Camera.current != null)
        {
            Vector3 screenPosition = Camera.current.WorldToScreenPoint(transform.position);
            float dist = Vector3.Distance(playerObject.transform.position, transform.position);
            if (screenPosition.z > 0 && dist < 10)
            {
                screenPosition.y = Screen.height - (screenPosition.y + 1);
                Rect rect = new Rect(screenPosition.x - 50, screenPosition.y - 12, 100, 24);
                GUI.Box(rect, (int) hp.currentHp + "/" + hp.maxHealth);
            }
        }
    }
}
