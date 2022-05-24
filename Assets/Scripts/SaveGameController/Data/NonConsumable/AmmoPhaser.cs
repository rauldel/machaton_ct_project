using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AmmoPhaser : Ammo
{
  public AmmoPhaser()
  {
    this.interactable = false;
    this.name = "Phaser charge";
    this.quantity = 0;
  }

  public AmmoPhaser(string name, int quantity)
  {
    this.interactable = false;
    this.name = name;
    this.quantity = quantity;
  }

  public override bool IsInteractable()
  {
    return this.interactable;
  }

  public override string GetName()
  {
    return this.name;
  }

  public override void SetName(string name)
  {
    this.name = name;
  }

  public override int GetQuantity()
  {
    return this.quantity;
  }

  public override void SetQuantity(int qty)
  {
    this.quantity = qty;
  }
}
