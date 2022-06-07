using UnityEngine;

public class DragWitchIngredient : MonoBehaviour
{
    Vector3 startPos;
    private Vector3 mOffset;
    private float mZCood;

    [SerializeField] bool inCauldron;

    [SerializeField] string ingredientName;

    [SerializeField] FloatingOscillator floatingOscillator;

    [SerializeField] WitchGameScript witchGameScript;

    [SerializeField] Transform cauldronPos;
    public bool goInCauldron = false;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        witchGameScript = FindObjectOfType<WitchGameScript>();        
    }

    public void SetStartPosition(Vector3 newStartPosition)
    {
        startPos = newStartPosition;
        transform.position = startPos;
    }

    private void Update()
    {
        if (goInCauldron)
        {
            transform.position = Vector3.MoveTowards(transform.position, cauldronPos.position, moveSpeed * Time.deltaTime);
            if (transform.position == cauldronPos.position) goInCauldron = false;
        }
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
            witchGameScript.CheckCurrentIngredient(ingredientName);
            goInCauldron = true;
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
