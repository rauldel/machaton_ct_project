using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackgroundController : MonoBehaviour
{
  #region Attributes
  [SerializeField]
  private SpriteRenderer backgroundImage;

  [SerializeField]
  private ParticleSystem rainGenerator;
  #endregion

  #region UnityMethods
  void Awake()
  {
    rainGenerator.Play();
  }
  void Update()
  {

  }
  #endregion

  #region PublicMethods
  public IEnumerator EmitThunder(AudioManager audioManager)
  {
    backgroundImage.color = new Color(220f / 255f, 220f / 255f, 220f / 255f);
    var main = rainGenerator.main;
    main.startColor = new Color(220f / 255f, 220f / 255f, 220f / 255f, 160f / 255f);

    yield return new WaitForSeconds(0.1f);

    backgroundImage.color = new Color(128f / 255f, 128f / 255f, 128f / 255f);
    main.startColor = new Color(128f / 255f, 128f / 255f, 128f / 255f, 160f / 255f);

    float randomTimeForThunder = Random.Range(1f, 2f);
    yield return new WaitForSeconds(randomTimeForThunder);

    audioManager.PlaySound("Thunder", false);
  }
  #endregion
}
