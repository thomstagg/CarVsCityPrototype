using UnityEngine;

public class DebrisDeSpawn : MonoBehaviour
{
  public float lifetime;

  private void Awake() => Object.Destroy((Object) this.gameObject, this.lifetime);

  private void Update()
  {
  }
}