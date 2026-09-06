using UnityEngine;

public class AgentBinder : MonoBehaviour
{
    

    private void FirstSpell()
    {
        Debug.Log("First Spell");
    }

    private void SecondSpell()
    {
        Debug.Log("Second Spell");
    }

    private void ThirdSpell()
    {
        Debug.Log("Third Spell");
    }

    private void FourthSpell()
    {
        Debug.Log("Fourth Spell");
    }

    void OnEnable()
    {
        GameInputs.Instance.inputActions.Player.FirstSpell.performed += ctx => FirstSpell();
        GameInputs.Instance.inputActions.Player.SecondSpell.performed += ctx => SecondSpell();
        GameInputs.Instance.inputActions.Player.ThirdSpell.performed += ctx => ThirdSpell();
        GameInputs.Instance.inputActions.Player.FourthSpell.performed += ctx => FourthSpell();
    }
}
