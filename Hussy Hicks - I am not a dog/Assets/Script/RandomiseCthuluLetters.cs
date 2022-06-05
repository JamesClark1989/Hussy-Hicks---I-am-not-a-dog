using UnityEngine;

public class RandomiseCthuluLetters : MonoBehaviour
{
    [SerializeField] RectTransform[] randomPositions;
    [SerializeField] RectTransform[] tablets;
    void Start()
    {
        RandomizeTabletPositions();
    }

    private void RandomizeTabletPositions()
    {
        for(int i = 0; i < randomPositions.Length; i++)
        {
            RectTransform temp = randomPositions[i];
            int randomIndex = Random.Range(i, randomPositions.Length);
            randomPositions[i] = randomPositions[randomIndex];
            randomPositions[randomIndex] = temp;
        }

        for(int i = 0; i < tablets.Length; i++)
        {
            tablets[i].anchoredPosition = randomPositions[i].anchoredPosition;
        }
    }

}
