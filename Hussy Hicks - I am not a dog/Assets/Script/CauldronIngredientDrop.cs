using UnityEngine;

public class CauldronIngredientDrop : MonoBehaviour
{
    [SerializeField] WitchGameScript witchGameScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            print("IM IN");
            other.GetComponent<DragWitchIngredient>().CanDropIngredient(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ingredient"))
        {
            other.GetComponent<DragWitchIngredient>().CanDropIngredient(false);
        }
    }
}
