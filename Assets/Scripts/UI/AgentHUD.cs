using UnityEngine;
using UnityEngine.UI;

public class AgentHUD : MonoBehaviour
{
    public Color sellectedSpellColor = Color.yellow;
    public Color spellNormalColor = Color.red;
    [SerializeField] Image firstSpell;
    [SerializeField] Image secondSpell;
    [SerializeField] Image thirdSpell;
    [SerializeField] Image fourthSpell;

    private Image lastSpellUISelected;

    void Start()
    {
        firstSpell.color = spellNormalColor;
        secondSpell.color = spellNormalColor;
        thirdSpell.color = spellNormalColor;
        fourthSpell.color = spellNormalColor;
    }

    public void SelectFirstSpell()
    {
        OnSpellSeleted(firstSpell);
    }
    public void SelectSecondSpell()
    {
        OnSpellSeleted(secondSpell);
    }
    public void SelectThirdSpell()
    {
        OnSpellSeleted(thirdSpell);
    }
    public void SelectFourthSpell()
    {
        OnSpellSeleted(fourthSpell);
    }


    private void OnSpellSeleted(Image spellUI)
    {
        if (lastSpellUISelected)
        {
            lastSpellUISelected.color = spellNormalColor;
        }
        spellUI.color = sellectedSpellColor;
        lastSpellUISelected = spellUI;
    }
}
