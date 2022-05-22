using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
  [Header("Player UI Attributes")]
  [Space]
  [SerializeField]
  private Text uiWeaponText;
  [SerializeField]
  private Text uiLifeText;
  [SerializeField]
  private Text uiCoinText;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetLifeText(int lifes) {
      uiLifeText.text = "Life(s) - " + lifes;
  }

  public void SetWeaponText(string name, int ammo) {
      uiWeaponText.text = name + " - " + ammo;
  }

  public void SetCoinText(int coins) {
      uiCoinText.text = "Coin: " + coins;
  }
}
