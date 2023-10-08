using UnityEngine;

public class BuildingFireLifetime : MonoBehaviour
{
  public float lifetime;

  private void Awake() => Object.Destroy((Object) this.gameObject, this.lifetime);

  private void Start()
  {
  }

  private void Update()
  {
  }
}