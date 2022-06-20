using UnityEngine;

public class StaticScreenAnimation : MonoBehaviour
{
    [SerializeField] Renderer rend;

    [SerializeField] float timer;
    [SerializeField] float timerMax;
    void Start()
    {
        rend = GetComponent<Renderer>();
        timer = timerMax;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            float xOffset = Random.Range(0f, 1f);
            float yOffset = Random.Range(0f, 1f);


            rend.material.mainTextureOffset = new Vector2(xOffset, yOffset);
            timer = timerMax;
        }
    }
}
