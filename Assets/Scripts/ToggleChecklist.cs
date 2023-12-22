using UnityEngine;
using UnityEngine.UI;

public class ToggleChecklist : MonoBehaviour
{
    public Toggle visibilityToggle;
    public GameObject targetObject;

    void Start()
    {
        if (visibilityToggle == null || targetObject == null)
        {
            enabled = false;
            return;
        }

        visibilityToggle.onValueChanged.AddListener(ToggleObjectVisibility);
    }

    void ToggleObjectVisibility(bool isVisible)
    {
        targetObject.SetActive(isVisible);
    }
}
