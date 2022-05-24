using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class Weapon : NonConsumable
{
  // Nothing new here at the moment
  public List<string> ammoAllowed;

  public abstract List<string> GetAmmoAllowed();
  public abstract void SetAmmoAllowed(List<string> ammoAllowed);
}
