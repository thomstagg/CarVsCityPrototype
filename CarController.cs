using UnityEngine;

public class CarControllerSimple : MonoBehaviour
{
  public WheelCollider wheelFrontLeft;
  public WheelCollider wheelFrontRight;
  public WheelCollider wheelBackLeft;
  public WheelCollider wheelBackRight;
  public float steerMax;
  public float motorMax;
  public float brakeMax;
  private float steer;
  private float motor;
  private float brake;

  private void Start()
  {
  }

  private void FixedUpdate()
  {
    this.steer = Mathf.Clamp(Input.GetAxis("Horizontal"), -1f, 1f);
    this.motor = Mathf.Clamp(Input.GetAxis("Vertical"), 0.0f, 1f);
    this.brake = -1f * Mathf.Clamp(Input.GetAxis("Vertical"), -1f, 0.0f);
    this.wheelBackLeft.motorTorque = -1f * this.motorMax * this.motor;
    this.wheelBackRight.motorTorque = -1f * this.motorMax * this.motor;
    this.wheelBackLeft.brakeTorque = this.brakeMax * this.brake;
    this.wheelBackRight.brakeTorque = this.brakeMax * this.brake;
    this.wheelFrontLeft.steerAngle = this.steerMax * this.steer;
    this.wheelFrontRight.steerAngle = this.steerMax * this.steer;
  }
}