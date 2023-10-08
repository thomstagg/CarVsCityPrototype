using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
  private static MusicPlayer instance;

  private void Awake()
  {
    Debug.Log((object) ("Music player awake " + (object) this.GetInstanceID()));
    if ((Object) MusicPlayer.instance != (Object) null)
    {
      Object.DestroyImmediate((Object) this.gameObject);
      MonoBehaviour.print((object) "Music object destroyed!");
    }
    else
    {
      MusicPlayer.instance = this;
      Object.DontDestroyOnLoad((Object) this.gameObject);
    }
  }

  private void Start() => Debug.Log((object) ("Music player start " + (object) this.GetInstanceID()));

  private void Update()
  {
  }
}