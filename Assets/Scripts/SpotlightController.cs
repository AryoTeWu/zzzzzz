using UnityEngine;
using UnityEngine.UI;

public class SpotlightController : MonoBehaviour
{
    public Light spotlight;
    private string spotlightStatusKey = "SpotlightStatus";

    void Start()
    {
        if (spotlight == null)
        {
            Debug.LogError("Spotlight not assigned! Attach a spotlight to the script in the Inspector.");
            return;
        }

        if (PlayerPrefs.HasKey(spotlightStatusKey))
        {
            bool spotlightStatus = PlayerPrefs.GetInt(spotlightStatusKey) == 1;
            spotlight.enabled = spotlightStatus;
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ButtonClick);
        }
    }

    void ButtonClick()
    {
        spotlight.enabled = !spotlight.enabled;

        PlayerPrefs.SetInt(spotlightStatusKey, spotlight.enabled ? 1 : 0);
        PlayerPrefs.Save();

        Debug.Log("Flashlight " + (spotlight.enabled ? "ON" : "OFF"));
    }
}
