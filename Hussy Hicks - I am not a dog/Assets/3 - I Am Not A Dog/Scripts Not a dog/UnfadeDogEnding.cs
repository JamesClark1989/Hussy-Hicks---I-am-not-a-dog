using UnityEngine;
using UnityEngine.UI;

public class UnfadeDogEnding : MonoBehaviour
{
    [SerializeField] Image lerpedColor;

    [SerializeField] float lerpAmount = 0;

    void Update()
    {
        lerpAmount += Time.deltaTime;
        lerpedColor.color = Color.Lerp(Color.black, new Color(0,0,0,0), lerpAmount);
        if (lerpAmount >= 1)
            lerpAmount = 1;
    }
}
