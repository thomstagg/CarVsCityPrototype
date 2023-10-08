using UnityEngine;

public class Bullet : MonoBehaviour
{
  public AudioClip cannonExplosion;
  public float lifetime;
  public float damage;
  public GameObject explosion;
  public GameObject buildingFire;

  private void Awake() => Object.Destroy((Object) this.gameObject, this.lifetime);

  private void Start()
  {
  }

  private void Update()
  {
  }

  public float getDamage() => this.damage;

  public void Hit() => Object.Destroy((Object) this.gameObject);

  private void OnCollisionEnter(Collision collision)
  {
    Object.Instantiate((Object) this.explosion, this.transform.position, Quaternion.LookRotation(Vector3.up));
    AudioSource.PlayClipAtPoint(this.cannonExplosion, Camera.main.transform.position, 0.5f);
    Object.Instantiate((Object) this.buildingFire, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
