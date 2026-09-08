using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float equipDuration = 2f;
    public float unEquipDuration = 2f;
    public float lifeTime;
    public bool isDestroyed {get; protected set;}

    public virtual void TryCast(out bool spellIsCasted)
    {
        if (isDestroyed)
        {
            Debug.Log("Cannot cast spell");
            spellIsCasted  = false;
        }else
        {
            Debug.Log("Spell casted");
            spellIsCasted  = true;
        }
    }
    
    public virtual void OnCast()
    {
        Debug.Log("Spell updated");
    }

    public virtual void OnSelect()
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

    public virtual void Destory()
    {
        isDestroyed = true;
        Debug.Log("Spell destroyed");
    }


}
