using UnityEngine;
using UnityEngine.UI;

public class ShowHideObj : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject[] objectsToHide; 

    void Start()
    {
        if (targetObject == null || objectsToHide == null || objectsToHide.Length == 0)
        {
            enabled = false;
            return;
        }
    }

    public void ToggleObjectVisibility()
    {
        bool isVisible = !targetObject.activeSelf;
        targetObject.SetActive(isVisible);

        if (isVisible)
        {
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(false);
            }
        }
    }
}
