using System;
using System.Collections;
using System.Transactions;
using UnityEngine;

public class AgentBinder : MonoBehaviour
{
    [SerializeField] private Agent activeAgent;
    [SerializeField] private AgentHUD activeAgentHUD;
    [SerializeField] private Spell firstSpell;
    [SerializeField] private Spell secondSpell;
    [SerializeField] private Spell thirdSpell;
    [SerializeField] private Spell fourthSpell;
    Action selectedUtil;
    Spell currentSpell;
    Spell lastSpell;

    public void Update()
    {
        selectedUtil?.Invoke();
    }

    private void FirstSpell()
    {
        if(firstSpell == null)
        {
            Debug.Log("The spell is not set");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(SpellSellectionCycle(firstSpell));
        activeAgentHUD.SelectFirstSpell();
        
    }

    private void SecondSpell()
    {
        if(secondSpell == null)
        {
            Debug.Log("The spell is not set");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(SpellSellectionCycle(secondSpell));
        activeAgentHUD.SelectSecondSpell();

    }

    private void ThirdSpell()
    {
        if(thirdSpell == null)
        {
            Debug.Log("The spell is not set");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(SpellSellectionCycle(thirdSpell));
        activeAgentHUD.SelectThirdSpell();

    }

    private void FourthSpell()
    {
        if(fourthSpell == null)
        {
            Debug.Log("The spell is not set");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(SpellSellectionCycle(fourthSpell));
        activeAgentHUD.SelectFourthSpell();

    }

    IEnumerator SpellSellectionCycle(Spell spell)
    {

        if (currentSpell)
        {
            yield return new WaitForSeconds(currentSpell.unEquipDuration); // why am i unequiping the last spell 
            currentSpell.Unequip();
        }

        currentSpell = spell;
        yield return new WaitForSeconds(spell.equipDuration);
        spell.Equip();
        lastSpell = currentSpell;
        selectedUtil += currentSpell.OnSelect;
    }

    void UseSpell()
    {
        if (currentSpell)
        {
            currentSpell.TryCast(out var spellIsCasted);
            if(spellIsCasted)
                selectedUtil += currentSpell.OnCast;

        }
    }

    void OnEnable()
    {
        GameInputs.Instance.inputActions.Player.FirstSpell.performed += ctx => FirstSpell();
        GameInputs.Instance.inputActions.Player.SecondSpell.performed += ctx => SecondSpell();
        GameInputs.Instance.inputActions.Player.ThirdSpell.performed += ctx => ThirdSpell();
        GameInputs.Instance.inputActions.Player.FourthSpell.performed += ctx => FourthSpell();
        GameInputs.Instance.inputActions.Player.Attack.performed += ctx => UseSpell();
    }
}
