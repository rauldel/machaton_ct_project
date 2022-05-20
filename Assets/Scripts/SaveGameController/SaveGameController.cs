using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameController : MonoBehaviour
{
    [SerializeField] PlayerWeaponController weaponController;
    SaveData saveData = new SaveData();

    void Awake()
    {
        saveData = LoadDataFromStorage();
    }

    void Update()
    {
        if (Input.GetKeyDown("backspace"))
        {
            DeleteSavedData();
        }
    }

    public SaveData GetSavedData()
    {
        return saveData;
    }
    public void UpdateAmmo(int ammo)
    {

        Weapons weapon = weaponController.GetWeaponSelected();

        if (weapon == Weapons.MachineGun)
        {
            saveData.SetMachineGunAmmo(ammo);
        }
        else if (weapon == Weapons.Laser)
        {
            saveData.SetLaserAmmo(ammo);
        }
        else if (weapon == Weapons.SmokeBomb)
        {
            saveData.SetSmokeBombAmmo(ammo);
        }

        WriteDataToStorage(saveData);
    }

    private static void DeleteSavedData()
    {
        string path = Application.persistentDataPath + "/savedData.dat";
        File.Delete(path);
    }

    public static void WriteDataToStorage(SaveData saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedData.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static SaveData LoadDataFromStorage()
    {
        string path = Application.persistentDataPath + "/savedData.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            return new SaveData();
        }
    }
}
