using UnityEngine;
using UnityEngine.EventSystems;


public class CthuluTabletDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] string TabletTag;
    [SerializeField] CthuluGame cthuluGame;
    [SerializeField] RandomiseCthuluLetters randomiseCthuluLetters;


    public void OnDrop(PointerEventData eventData)
    {
        print("DROPPING");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.gameObject.CompareTag(TabletTag))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<CthuluMoveTablets>().DroppedInCorrectLocation();
                cthuluGame.IncreaseCorrectTabletsAmount();

            }
            else
            {
                eventData.pointerDrag.GetComponent<CthuluMoveTablets>().MoveBackToOriginalPosition();
            }
            
        }
    }

}
