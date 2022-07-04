using UnityEngine;

public class DestroyAlternateInstruments : MonoBehaviour
{
    [SerializeField] GameObject[] instruments;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < instruments.Length; i++)
        {
            Destroy(instruments[i]);
        }

    }


}
