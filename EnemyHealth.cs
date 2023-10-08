using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  public GameObject explosion;
  public GameObject debris;
  public float radius = 5f;
  public float power = 10f;
  public int numberOfDebris;
  public int min;
  public int max;
  public float totalEnemyHealth;
  private Bullet playerBullet;

  private void Start() => this.totalEnemyHealth = 250f;

  public void enemyExplodes()
  {
    this.PlaceDebris();
    Object.Instantiate((Object) this.explosion, this.transform.position, Quaternion.identity);
    this.Explosion();
  }

  private void Explosion()
  {
    Vector3 position = this.transform.position;
    foreach (Component component1 in Physics.OverlapSphere(position, this.radius))
    {
      Rigidbody component2 = component1.GetComponent<Rigidbody>();
      if ((Object) component2 != (Object) null)
        component2.AddExplosionForce(this.power, position, this.radius, 3f);
    }
  }

  private void Update()
  {
  }

  private void OnCollisionEnter(Collision collider)
  {
    Bullet component = collider.gameObject.GetComponent<Bullet>();
    if (!(bool) (Object) component)
      return;
    this.totalEnemyHealth -= component.getDamage();
    component.Hit();
    Debug.Log((object) "bulletHit!");
    if ((double) this.totalEnemyHealth > 0.0)
      return;
    this.enemyExplodes();
    Object.Destroy((Object) this.gameObject);
  }

  private void PlaceDebris()
  {
    for (int index = 0; index < this.numberOfDebris; ++index)
      Object.Instantiate((Object) this.debris, Random.insideUnitSphere + this.transform.position, Random.rotation);
  }

  private Vector3 GeneratedPosition() => new Vector3((float) Random.Range(this.min, this.max), (float) Random.Range(this.min, this.max), (float) Random.Range(this.min, this.max));
}