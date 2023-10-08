using UnityEngine;

public class Player1Spawner : MonoBehaviour
{
  public GameObject Player1New;
  private GameObject player1;

  private void Start()
  {
  }

  private void Update()
  {
    if ((bool) (Object) GameObject.FindGameObjectWithTag("PlayerCar"))
      return;
    this.PlayerRespawn();
  }

  private void PlayerRespawn() => Object.Instantiate((Object) this.Player1New, this.transform.position, Quaternion.identity);
}