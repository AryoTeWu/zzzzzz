using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 TouchDist;
    [HideInInspector]
    public Vector2 PointerOld;
    [HideInInspector]
    protected int PointerId;
    [HideInInspector]
    public bool Pressed;

    public float sensitivity = 1.0f;
    public float smoothing = 5.0f;

    private Vector2 smoothVector = Vector2.zero;

    void Update()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                Vector2 currentTouchPosition = Input.touches[PointerId].position;
                TouchDist = currentTouchPosition - PointerOld;
                PointerOld = currentTouchPosition;
            }
            else
            {
                Vector2 currentMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                TouchDist = currentMousePosition - PointerOld;
                PointerOld = currentMousePosition;
            }

           TouchDist = new Vector2(TouchDist.x * sensitivity, TouchDist.y * sensitivity);
           TouchDist = new Vector2(TouchDist.x, -TouchDist.y);
           TouchDist = Vector2.Lerp(TouchDist, smoothVector, Time.deltaTime * smoothing);
           smoothVector = TouchDist;
        }
        else
        {
            TouchDist = Vector2.zero;
            smoothVector = Vector2.zero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
