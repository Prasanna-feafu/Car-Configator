using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public enum JoyStickDirection { Horizontal, Vertical, Both }

public class CarJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform joystickBackground, joystickHandle;
    public JoyStickDirection joyStickDirection = JoyStickDirection.Both;
    [Range(0, 2f)] public float handleLimit = 0.5f;

    Vector2 input = Vector2.zero;

    public float Vertical { get { return input.y; } }
    public float Horizontal { get { return input.x; } }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joyDirection = eventData.position - RectTransformUtility.WorldToScreenPoint(new Camera(), joystickBackground.position);
        input = (joyDirection.magnitude > joystickBackground.sizeDelta.x / 2f) ? joyDirection.normalized :
            joyDirection / (joystickBackground.sizeDelta.x / 2f);
        if(joyStickDirection == JoyStickDirection.Horizontal)
        {
            input = new Vector2(input.x, 0f); 
        }
        if(joyStickDirection == JoyStickDirection.Vertical)
        {
            input = new Vector2(0f, input.y);
        }

        joystickHandle.anchoredPosition = (input * joystickBackground.sizeDelta.x / 2f) * handleLimit;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}
