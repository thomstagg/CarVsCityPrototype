using UnityEngine;

public class TurretController : MonoBehaviour
{
  public float speed;

  private void FixedUpdate()
  {
    Plane plane = new Plane(Vector3.up, this.transform.position);
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    float enter = 0.0f;
    if (!plane.Raycast(ray, out enter))
      return;
    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(ray.GetPoint(enter) - this.transform.position), this.speed * Time.deltaTime);
  }
}
