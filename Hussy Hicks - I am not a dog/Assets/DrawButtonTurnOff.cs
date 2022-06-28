using UnityEngine;
using System.Collections;

public class DrawButtonTurnOff : MonoBehaviour
{
    [SerializeField] GameObject drawButton;

    [SerializeField] Vector2[] randomPositions;
    [SerializeField] RectTransform buttonPos;

    private void OnEnable()
    {
        int posChosen = Random.Range(0, randomPositions.Length);
        Debug.Log(randomPositions[posChosen]);
        buttonPos.anchoredPosition = randomPositions[posChosen];
    }

    public void TurnSelfOff()
    {
        drawButton.SetActive(false);
    }
}
