using UnityEngine;

public class MonkeysWave : MonoBehaviour
{
    [SerializeField] Animator[] anims;
    
    public void Wave()
    {
        for(int i = 0; i < anims.Length; i++)
        {
            anims[i].SetBool("Wave", true);
        }
    }

    public void StopWaving()
    {
        for (int i = 0; i < anims.Length; i++)
        {
            anims[i].SetBool("Wave", false);
        }
    }
}
