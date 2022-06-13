using UnityEngine;

public class HussyDetails : MonoBehaviour
{
    [SerializeField] string HussyName;

    public string GetHussyName()
    {
        return HussyName;
    }
} 
