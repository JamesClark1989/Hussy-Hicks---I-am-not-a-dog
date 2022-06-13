using UnityEngine;
using System.Collections;

public class CowboyScript : MonoBehaviour
{
    [SerializeField] Animator cowboyAnim;
    [SerializeField] NewQuickGameGame newQuickGameGame;
    IEnumerator drawDelay;
    bool canShoot = true;

    public void Draw()
    {
        canShoot = true;
        drawDelay = DrawDelay();
        StartCoroutine(drawDelay);
    }

    public void StopDraw()
    {
        StopCoroutine(drawDelay);
        canShoot = false;
    }

    private IEnumerator DrawDelay()
    {
        float randomDelay = Random.Range(0.5f, 0.6f);
        yield return new WaitForSeconds(randomDelay);
        cowboyAnim.SetTrigger("Draw");
    }

    public void ShootCharacter()
    {
        if(canShoot)
            newQuickGameGame.CowboyShoot();
    }


}
