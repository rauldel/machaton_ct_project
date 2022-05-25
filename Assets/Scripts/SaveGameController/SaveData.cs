using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
  public int playerCoins = 50;
  public int totalMoneyEarned = 50;
  public int totalMoneySpent = 0;
  public AmmoPhaser phaserAmmo;
  public AmmoCannonSmoke smokeBombAmmo;
  public AmmoLaser laserAmmo;
  public string anonymousId = "";
  public bool hasPhaser = false;
  public bool hasLaser = false;
  public bool hasBombthrower = false;
  public int potionsCount = 0;
  public int superPotionsCount = 0;
  public int hyperPotionsCount = 0;

  public SaveData()
  {
    playerCoins = 50;
    totalMoneyEarned = 50;
    totalMoneySpent = 0;
    phaserAmmo = new AmmoPhaser();
    laserAmmo = new AmmoLaser();
    smokeBombAmmo = new AmmoCannonSmoke();
    anonymousId = "";
    hasPhaser = false;
    hasLaser = false;
    hasBombthrower = false;
    potionsCount = 0;
    superPotionsCount = 0;
    hyperPotionsCount = 0;
  }

  public void SetLaserAmmo(int ammo)
  {
    laserAmmo.SetQuantity(ammo);
  }

  public void SetPhaserAmmo(int ammo)
  {
    phaserAmmo.SetQuantity(ammo);
  }

  public void SetSmokeBombAmmo(int ammo)
  {
    smokeBombAmmo.SetQuantity(ammo);
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

  public void SetAnonyomusId(string anonId)
  {
    anonymousId = anonId;
  }

  public void SetHasPhaser(bool newHasPhaser)
  {
    hasPhaser = newHasPhaser;
  }

  public void SetHasLaser(bool newHasLaser)
  {
    hasLaser = newHasLaser;
  }

  public void SetHasBombthrower(bool newHasBombthrower)
  {
    hasBombthrower = newHasBombthrower;
  }

  public void SetPotionsCount(int newPotionsCount)
  {
    potionsCount = newPotionsCount;
  }

  public void SetSuperPotionsCount(int newSuperPotionsCount)
  {
    superPotionsCount = newSuperPotionsCount;
  }

  public void SetHyperPotionsCount(int newHyperPotionsCount)
  {
    hyperPotionsCount = newHyperPotionsCount;
  }
}