using UnityEngine;

public class DragWitchIngredient : MonoBehaviour
{
    private Vector3 startPos;

    private Vector3 mOffset;

    private float mZCood;

    [SerializeField] bool inCauldron;

    [SerializeField] string ingredientName;

    [SerializeField] FloatingOscillator floatingOscillator;

    [SerializeField] WitchGameScript witchGameScript;

    private void Start()
    {
        witchGameScript = FindObjectOfType<WitchGameScript>();
        startPos = transform.position;
    }

    private void OnMouseDown()
    {
        floatingOscillator.enabled = false;
        mZCood = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // pixel coord to world coord (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCood;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    private void OnMouseUp()
    {
        if (inCauldron)
        {
            Destroy(gameObject);
            witchGameScript.CheckCurrentIngredient(ingredientName);
        }
        else
        {
            transform.position = startPos;
            floatingOscillator.enabled = true;
        }
    }


    public void CanDropIngredient(bool canDrop)
    {
        inCauldron = canDrop;
    }

}
