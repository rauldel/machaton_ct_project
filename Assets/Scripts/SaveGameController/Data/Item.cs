using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class Item
{
  public bool interactable;
  public string name;

  public abstract bool IsInteractable();
  public abstract string GetName();
  public abstract void SetName(string name);
}
