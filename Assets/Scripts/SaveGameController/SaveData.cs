using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private int playerCoins;
    private int totalMoneyEarned;
    private int totalMoneySpent;
    public int machineGunAmmo = 50;
    public int smokeBombAmmo = 50;
    public int laserAmmo = 50;



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

    public void SetMachineGunAmmo(int ammo)
    {
        machineGunAmmo = ammo;
    }


}
