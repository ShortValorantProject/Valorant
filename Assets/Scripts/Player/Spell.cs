using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float equipDuration = 2f;
    public float unEquipDuration = 2f;
    public float lifeTime;
    public virtual void TryCast(out bool isSpellCasted)
    {
        Debug.Log("Spell casted");
        isSpellCasted  = true;
    }
    
    public virtual void Destory()
    {
        Debug.Log("Spell destroyed");
    }

    public virtual void _Update()
    {
        Debug.Log("Spell updated");
    }

    public virtual void Equip()
    {
        Debug.Log("Spell equipped");
    }
    
    public virtual void Unequip()
    {
        Debug.Log("Spell unequipped");
    }

}
