using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
  private float timeLeft = 60f;
  public Text text;

  private void Start()
  {
  }

  private void Update()
  {
    this.text.text = "Time: " + this.timeLeft.ToString("F0");
    this.timeLeft -= Time.deltaTime;
    Object.FindObjectOfType<PlayerHealth>();
    if ((double) this.timeLeft >= 0.0)
      return;
    this.Invoke("Die", 2f);
  }

  private void Die() => GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevel("Lose");
}