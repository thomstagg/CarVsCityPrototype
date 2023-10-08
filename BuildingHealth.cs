using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
  public AudioClip collapse;
  public float totalBuildingHealth;

  private void Start()
  {
  }

  private void Update()
  {
  }

  private void OnCollisionEnter(Collision collider)
  {
    ScoreKeeper.score += 25;
    Box component1 = this.gameObject.GetComponent<Box>();
    Bullet component2 = collider.gameObject.GetComponent<Bullet>();
    if (!(bool) (Object) component2)
      return;
    this.totalBuildingHealth -= component2.getDamage();
    component2.Hit();
    Debug.Log((object) "bulletHit!");
    if ((double) this.totalBuildingHealth <= 75.0)
      component1.PlaceDebris();
    if ((double) this.totalBuildingHealth > 0.0)
      return;
    ScoreKeeper.score += 100;
    component1.PlaceDebris();
    component1.Explosion();
    AudioSource.PlayClipAtPoint(this.collapse, Camera.main.transform.position, 1f);
    Object.Destroy((Object) this.gameObject);
  }
}
