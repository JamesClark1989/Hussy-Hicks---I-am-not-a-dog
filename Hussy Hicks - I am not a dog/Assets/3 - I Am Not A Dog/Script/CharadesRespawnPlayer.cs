using UnityEngine;

public class CharadesRespawnPlayer : MonoBehaviour
{
    [SerializeField] CharadesGame charadesGame;
    [SerializeField] Animator bootAnim;
    
    public void Respawn()
    {
        charadesGame.SpawnCharacter();
        bootAnim.SetTrigger("Reset");

    }
}
