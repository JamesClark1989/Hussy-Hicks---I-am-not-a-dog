
using UnityEngine;
using UnityEngine.EventSystems;

public class CthuluMoveTablets : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;

    [SerializeField] Vector2 originalLocation;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalLocation = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        // Delta has the movement delta of the mouse per frame
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        MoveBackToOriginalPosition();
    }

    public void OnDrop(PointerEventData eventData)
    {

    }

    public void MoveBackToOriginalPosition()
    {
        rectTransform.anchoredPosition = originalLocation;
    }

    public void DroppedInCorrectLocation()
    {
        canvasGroup.alpha = 1f;

        Destroy(GetComponent<CthuluMoveTablets>());
    }
}
