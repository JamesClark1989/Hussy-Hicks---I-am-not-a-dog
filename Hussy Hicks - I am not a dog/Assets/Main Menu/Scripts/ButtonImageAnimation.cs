using UnityEngine.UI;
using UnityEngine;

public class ButtonImageAnimation : MonoBehaviour
{
    [SerializeField] Image uiImage;
    [SerializeField] Sprite[] buttonImages;
    [SerializeField] int element = 0;

    float timer;
    [SerializeField] float timerMax;

    private void Start()
    {
        timer = timerMax;
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            element++;
            if (element >= buttonImages.Length) element = 0;
            uiImage.sprite = buttonImages[element];
            timer = timerMax;
        }
    }
}
