public class Tripwire : Spell
{
    

    public override void TryCast(out bool isSpellCasted)
    {
        isSpellCasted = true;
    }
    
    public override void Destory()
    {
        base.Destory();
    }

    public override void OnCast()
    {
        base.OnCast();
    }

    public override void OnSelect()
    {
        base.OnSelect();
    }

    public override void Equip()
    {
        base.Equip();
    }   
    
    public override void Unequip()
    {
        base.Unequip();
    }
}
