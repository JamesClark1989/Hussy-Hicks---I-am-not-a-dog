using UnityEngine;

public class TurnOffCharadesButton : MonoBehaviour
{
    [SerializeField] GameObject charadesParent;

    public void TurnOffCharadesButtons()
    {
        charadesParent.SetActive(false);
    }
}
