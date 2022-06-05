using UnityEngine;

public class CharacterItemLocation : MonoBehaviour
{
    [SerializeField] Transform itemPosition;
    
    public Transform GetItemPosition()
    {
        return itemPosition;
    }
}
