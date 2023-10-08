using UnityEngine;

public class AIBullet : MonoBehaviour
{
  public float AIBulletlifetime;
  public float damage = 0.5f;

  public float getDamage() => this.damage;

  private void Awake() => Object.Destroy((Object) this.gameObject, this.AIBulletlifetime);

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void Hit() => Object.Destroy((Object) this.gameObject);
}
