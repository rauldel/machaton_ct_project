using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SuperPotion : Consumable
{
  public SuperPotion()
  {
    this.interactable = true;
    this.name = "Superpotion";
    this.value = 4;
  }

  public SuperPotion(string name, int value)
  {
    this.interactable = true;
    this.name = name;
    this.value = value;
  }

  public override bool IsInteractable()
  {
    return this.interactable;
  }

  public override string GetName() {
      return this.name;
  }

  public override void SetName(string name)
  {
    this.name = name;
  }

  public override int GetValue()
  {
    return this.value;
  }

  public override void SetValue(int value)
  {
    this.value = value;
  }
}
