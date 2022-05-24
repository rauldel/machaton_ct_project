using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Laser : Weapon
{
  public Laser()
  {
    this.interactable = false;
    this.name = "Laser";
    this.ammoAllowed = new List<string>() { "AmmoLaser" };
  }

  public Laser(string name, List<string> ammoAllowed)
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
