using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Phaser : Weapon
{
  public Phaser()
  {
    this.interactable = false;
    this.name = "Phaser";
    this.ammoAllowed = new List<string>() { "AmmoPhaser" };
  }

  public Phaser(string name, List<string> ammoAllowed)
  {
    this.interactable = false;
    this.name = name;
    this.ammoAllowed = ammoAllowed;
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

  public override List<string> GetAmmoAllowed()
  {
    return this.ammoAllowed;
  }

  public override void SetAmmoAllowed(List<string> ammoAllowed)
  {
    this.ammoAllowed = ammoAllowed;
  }
}
