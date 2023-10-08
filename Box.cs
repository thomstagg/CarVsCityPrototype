using UnityEngine;

public class Box : MonoBehaviour
{
  public GameObject explosion;
  public GameObject debris;
  public float radius = 5f;
  public float power = 10f;
  public int numberOfDebris;
  public int min;
  public int max;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void Explosion()
  {
    Vector3 position = this.transform.position;
    foreach (Component component1 in Physics.OverlapSphere(position, this.radius))
    {
      Rigidbody component2 = component1.GetComponent<Rigidbody>();
      if ((Object) component2 != (Object) null)
        component2.AddExplosionForce(this.power, position, this.radius, 3f);
    }
  }

  public void PlaceDebris()
  {
    for (int index = 0; index < this.numberOfDebris; ++index)
      Object.Instantiate((Object) this.debris, Random.insideUnitSphere + this.transform.position, Random.rotation);
  }

  private Vector3 GeneratedPosition() => new Vector3((float) Random.Range(this.min, this.max), (float) Random.Range(this.min, this.max), (float) Random.Range(this.min, this.max));
}
