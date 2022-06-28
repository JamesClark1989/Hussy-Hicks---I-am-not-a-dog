using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyGameData : MonoBehaviour
{
    void Awake()
    {
        GameObject objs = GameObject.FindGameObjectWithTag("GameData");

        if (objs != null)
        {
            Destroy(objs);
        }

    }

}
