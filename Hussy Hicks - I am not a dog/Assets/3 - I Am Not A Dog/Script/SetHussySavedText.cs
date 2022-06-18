using TMPro;
using UnityEngine;

public class SetHussySavedText : MonoBehaviour
{
    [SerializeField] TMP_Text savedText;

    public void ChangeText(string newtext)
    {
        savedText.SetText(newtext);
    }
}
