using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
  public static int score;
  public Text text;

  private void Start() => ScoreKeeper.Reset();

  private void Update() => this.text.text = "Score " + ScoreKeeper.score.ToString();

  public static void Reset() => ScoreKeeper.score = 0;
}