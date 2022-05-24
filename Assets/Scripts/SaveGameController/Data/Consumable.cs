using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class Consumable : Item 
{
    public int value;

    public abstract int GetValue();
    public abstract void SetValue(int value);
}
