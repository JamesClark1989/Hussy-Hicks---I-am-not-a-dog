using UnityEngine;

public class DivingScoreCardNumbers : MonoBehaviour
{
    [SerializeField] GameObject[] failNumbers;
    [SerializeField] GameObject[] correctNumbers;
    
    public void TurnOnNumbers(bool correct)
    {
        int randomValue = Random.Range(0, 2);
        if (correct)
        {
            correctNumbers[randomValue].SetActive(true);
        }
        else
        {
            failNumbers[randomValue].SetActive(true);
        }
    }

    public void TurnOffNumbers()
    {
        for(int i = 0; i < 2; i++)
        {
            correctNumbers[i].SetActive(false);
            failNumbers[i].SetActive(false);
        }
    }
}
