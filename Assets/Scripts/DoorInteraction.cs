using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject elementToToggle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the collider");
            ToggleElementVisibility(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the collider");
            ToggleElementVisibility(false); 
        }
    }

    void ToggleElementVisibility(bool isVisible)
    {
        if (elementToToggle != null)
        {
            elementToToggle.SetActive(isVisible);
        }
    }
}
