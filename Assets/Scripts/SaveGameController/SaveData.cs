using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
  public int playerCoins = 40;
  public int totalMoneyEarned = 50;
  public int totalMoneySpent = 0;
  public int phaserAmmo = 10;
  public int smokeBombAmmo = 50;
  public int laserAmmo = 50;
  public string anonymousId = "";

  public void SetLaserAmmo(int ammo)
  {
    laserAmmo = ammo;
  }

  public void SetSmokeBombAmmo(int ammo)
  {
    smokeBombAmmo = ammo;
  }

  public void SetPlayerCoins(int coins)
  {
    playerCoins = coins;
  }

  public void SetTotalMoneyEarned(int newMoneyEarned)
  {
    totalMoneyEarned = newMoneyEarned;
  }

  public void SetTotalMoneySpent(int newMoneySpent)
  {
    totalMoneySpent = newMoneySpent;
  }

  public void SetPhaserAmmo(int ammo)
  {
    phaserAmmo = ammo;
  }

  public void SetAnonyomusId(string anonId)
  {
    anonymousId = anonId;
  }
}