using System;
using UnityEngine;

[Serializable]
public class Wheels
{
  private const int dps = 6;
  private Quaternion angleCorrection = Quaternion.Euler(0.0f, 0.0f, 90f);
  public GameObject wheelLeftGo;
  public Transform wheelLeftT;
  private WheelCollider wheelLeftWc;
  public GameObject wheelRightGo;
  public Transform wheelRightT;
  private WheelCollider wheelRightWc;
  public bool drive;
  public bool brakes;
  public bool steering;
  private float steerAngle;
  private Vector3 wheelRightRotationCurrent;
  private Vector3 wheelLeftRotationCurrent;
  private Vector3 tempRotation = new Vector3(0.0f, 0.0f, 0.0f);

  public void Throttle(Side side, float motor, float max)
  {
    if (!this.drive)
      return;
    if (side == Side.left)
      this.wheelLeftWc.motorTorque = -1f * max * motor;
    else
      this.wheelRightWc.motorTorque = -1f * max * motor;
  }

  public void Brake(Side side, float brake, float max)
  {
    if (!this.brakes)
      return;
    if (side == Side.left)
      this.wheelLeftWc.brakeTorque = max * brake;
    else
      this.wheelRightWc.brakeTorque = max * brake;
  }

  public void Steer(Side side, float amount, float max)
  {
    this.steerAngle = amount * max;
    if (!this.steering)
      return;
    if (side == Side.left)
      this.wheelLeftWc.steerAngle = this.steerAngle;
    else
      this.wheelRightWc.steerAngle = this.steerAngle;
  }

  public void Init()
  {
    this.wheelLeftWc = this.wheelLeftT.GetComponent<WheelCollider>();
    this.wheelRightWc = this.wheelRightT.GetComponent<WheelCollider>();
    this.wheelLeftRotationCurrent = this.wheelLeftGo.transform.eulerAngles;
    this.wheelRightRotationCurrent = this.wheelLeftGo.transform.eulerAngles;
  }

  public void UpdateWheels()
  {
    this.wheelLeftGo.transform.position = this.wheelLeftWc.transform.position;
    this.wheelRightGo.transform.position = this.wheelRightWc.transform.position;
    if (this.steering)
    {
      this.tempRotation.y = Mathf.Lerp(this.tempRotation.y, this.steerAngle, 0.2f);
      this.wheelRightRotationCurrent.y = this.tempRotation.y;
      this.wheelLeftRotationCurrent.y = this.tempRotation.y;
      this.wheelLeftGo.transform.localEulerAngles = this.wheelLeftRotationCurrent;
      this.wheelRightGo.transform.localEulerAngles = this.wheelRightRotationCurrent;
    }
    else
    {
      this.wheelLeftGo.transform.rotation = this.wheelLeftWc.transform.rotation * this.angleCorrection;
      this.wheelRightGo.transform.rotation = this.wheelRightWc.transform.rotation * this.angleCorrection;
    }
    this.wheelLeftGo.transform.Rotate(0.0f, this.wheelLeftWc.rpm * 6f * Time.deltaTime, 0.0f);
    this.wheelRightGo.transform.Rotate(0.0f, this.wheelRightWc.rpm * 6f * Time.deltaTime, 0.0f);
  }

  public string GetTorque(Side side) => side == Side.left ? this.wheelLeftWc.motorTorque.ToString() : this.wheelRightWc.motorTorque.ToString();
}