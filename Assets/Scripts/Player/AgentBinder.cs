using System;
using System.Collections;
using System.Transactions;
using UnityEngine;

public class AgentBinder : MonoBehaviour
{
    [SerializeField] private Agent activeAgent;
    [SerializeField] private AgentHUD activeAgentHUD;
    [SerializeField] private SpellCaster firstSpell;
    [SerializeField] private SpellCaster secondSpell;
    [SerializeField] private SpellCaster thirdSpell;
    [SerializeField] private SpellCaster fourthSpell;
    Action selectedUtilUpdatLogic;
    SpellCaster currentSpell;
    SpellCaster lastSpell;

    public void Update()
    {
        selectedUtilUpdatLogic?.Invoke();
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

    IEnumerator SpellSellectionCycle(SpellCaster spell)
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
        selectedUtilUpdatLogic = currentSpell.OnSelect;
    }

    void TryCastSpell()
    {
        if (currentSpell)
        {
            currentSpell.TryCast(out var spellIsCasted);
            if (spellIsCasted)
            {
                currentSpell.Unequip();
                lastSpell = currentSpell;
                currentSpell = null;
                activeAgentHUD.UnSellectAll();
                selectedUtilUpdatLogic = null;
            }
            
        }
    }

    void OnEnable()
    {
        GameInputs.Instance.inputActions.Player.FirstSpell.performed += ctx => FirstSpell();
        GameInputs.Instance.inputActions.Player.SecondSpell.performed += ctx => SecondSpell();
        GameInputs.Instance.inputActions.Player.ThirdSpell.performed += ctx => ThirdSpell();
        GameInputs.Instance.inputActions.Player.FourthSpell.performed += ctx => FourthSpell();
        GameInputs.Instance.inputActions.Player.Attack.performed += ctx => TryCastSpell();
    }
}
