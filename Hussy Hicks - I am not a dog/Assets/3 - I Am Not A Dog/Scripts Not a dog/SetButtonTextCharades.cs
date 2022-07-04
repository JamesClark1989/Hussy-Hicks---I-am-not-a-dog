using UnityEngine;

public class SetButtonTextCharades : MonoBehaviour
{
    [SerializeField] CharadesGame charadesGame;

    private void OnEnable()
    {
        charadesGame.SetupAnswerButtons();
    }
}
