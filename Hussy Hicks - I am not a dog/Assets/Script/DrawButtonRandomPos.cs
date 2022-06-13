using UnityEngine;

public class DrawButtonRandomPos : MonoBehaviour
{
    [SerializeField] RectTransform buttonTransform;
    [SerializeField] float[] xPos = { -250, 0, 250 };

    void Start()
    {
        buttonTransform.anchoredPosition = new Vector3(xPos[Random.Range(0, xPos.Length)], 40, 0);
    }



}
