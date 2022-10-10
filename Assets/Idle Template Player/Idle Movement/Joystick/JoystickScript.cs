using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickScript : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private const float SimmetryAngle = 90f;
    private const float DeadZone = 0.2f;
    private const float ClampZone = 1f;
    public const int Directions = 0;
    public bool IsWorking { get; private set; } = false;
    public Vector2 Output { get; private set; } = Vector2.zero;

    [Header("Objects")] [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;

    private Vector2 originalPosition;


    private void Start()
    {
        IsWorking = false;
        Output = Vector2.zero;
        background.anchoredPosition = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        originalPosition = background.anchoredPosition;
        background.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        background.gameObject.SetActive(true);
        background.position = eventData.position;
        handle.anchoredPosition = Vector2.zero;
    }

    public void OnBackgroundPointerDown(BaseEventData baseEventData)
    {
        OnPointerDown(baseEventData as PointerEventData);
    }

    public void OnBackgroundDrag(BaseEventData baseEventData)
    {
        PointerEventData eventData = baseEventData as PointerEventData;

        Vector2 vector = eventData.position - (Vector2) background.position;

        float magnitude = vector.magnitude;

        float deadSize = DeadZone * background.sizeDelta.x * 0.5f;

        if (magnitude < deadSize)
        {
            Output = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
            IsWorking = false;
            return;
        }

        Following(vector);

        if (Directions > 0)
            vector = DirectionalVector(vector, Directions, SimmetryAngle * Mathf.Deg2Rad);

        float clampSize = ClampZone * background.sizeDelta.x * 0.5f;

        Output = vector.normalized;
        if (magnitude < clampSize)
            Output *= (magnitude - deadSize) / (clampSize - deadSize);

        handle.anchoredPosition = Output * clampSize;

        IsWorking = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (IsWorking ||
            RectTransformUtility.RectangleContainsScreenPoint(background, eventData.position,
                eventData.pressEventCamera))
            OnBackgroundDrag(eventData);
    }

    public void OnBackgroundPointerUp(BaseEventData baseEventData)
    {
        IsWorking = false;
        Output = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        background.anchoredPosition = originalPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnBackgroundPointerUp(eventData);
        background.gameObject.SetActive(false);
    }

    private Vector2 DirectionalVector(Vector2 vector, int directions, float simmetryAngle)
    {
        Vector2 simmetry = new Vector2(Mathf.Cos(simmetryAngle), Mathf.Sin(simmetryAngle));
        float angle = Vector2.SignedAngle(simmetry, vector);

        angle /= 180f / directions;

        angle = (angle >= 0f) ? Mathf.Floor(angle) : Mathf.Ceil(angle);
        if ((int) Mathf.Abs(angle) % 2 == 1)
        {
            if (angle >= 0f)
            {
                angle += 1;
            }
            else
            {
                angle -= 1;
            }
        }


        angle *= 180f / directions;

        angle *= Mathf.Deg2Rad;
        Vector2 result = new Vector2(Mathf.Cos(angle + simmetryAngle), Mathf.Sin(angle + simmetryAngle));
        result *= vector.magnitude;
        return result;
    }

    private void Following(Vector2 vector)
    {
        float clampSize = ClampZone * background.sizeDelta.x * 0.5f;
        if (vector.magnitude > clampSize)
        {
            Vector2 radius = vector.normalized * clampSize;
            Vector2 delta = vector - radius;
            Vector2 newPos = background.anchoredPosition + delta;

            float xMax = rectTransform.sizeDelta.x * 0.5f;
            newPos.x = Mathf.Clamp(newPos.x, -xMax, xMax);

            float yMax = rectTransform.sizeDelta.y * 0.5f;
            newPos.y = Mathf.Clamp(newPos.y, -yMax, yMax);

            background.anchoredPosition = newPos;
        }
    }
}