using UnityEngine;

public class LevelManager : MonoBehaviour
{
  public void LoadLevel(string name)
  {
    Debug.Log((object) ("New Level load: " + name));
    Application.LoadLevel(name);
  }

  public void QuitRequest()
  {
    Debug.Log((object) "Quit requested");
    Application.Quit();
  }
}
