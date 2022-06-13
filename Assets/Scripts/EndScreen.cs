using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    public Transform endPosition;
    public Transform Player;
    public Animator PlayerAnim;
   
    public float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, endPosition.transform.position);

        if (distance < 15f && distance >= 1f)
        {
          
           Player.transform.position = Vector3.MoveTowards(Player.transform.position, endPosition.transform.position, 2 * Time.deltaTime);
        }
        if (distance < 0.3f) {
            PlayerAnim.SetBool("isWalking", false);
            Player.Rotate(0, 135, 0);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.End);
           
            
        }
    }
}
