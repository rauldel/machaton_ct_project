using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class Ammo : NonConsumable
{
  public int quantity;

  public abstract int GetQuantity();
  public abstract void SetQuantity(int qty);
}
