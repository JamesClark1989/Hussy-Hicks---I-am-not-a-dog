using UnityEngine;

public class CowboyScript : MonoBehaviour
{
    bool canShoot = true;

    public void ShootCharacter()
    {
        if (canShoot)
        {
            CharacterRunScript characterRunScript = FindObjectOfType<CharacterRunScript>();
            characterRunScript.CowboyShot();
        }
    }

    public void CantShoot()
    {
        canShoot = false;
    }


}
