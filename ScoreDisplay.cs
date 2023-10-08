using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
  private void Start()
  {
    this.GetComponent<Text>().text = ScoreKeeper.score.ToString();
    ScoreKeeper.Reset();
  }

  private void Update()
  {
  }
}