using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerweInput swerweInput;
    public float swerveAmount;
    Animator anim;

    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 2f;

    public float edgeDistance;
    public float moveSpeed = 5f;

    public GameManager manager;

    void Start()
    {
        swerweInput = GetComponent<SwerweInput>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        Run();
        
    }
    void Run()
    {
        if (manager.state == GameManager.GameState.Running)
        {
            anim.SetBool("isRunning", true);
            swerveAmount = swerweInput.MoveFactorX * swerveSpeed * Time.deltaTime;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);


            transform.position += new Vector3(swerveAmount, 0, moveSpeed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -edgeDistance, edgeDistance),
                transform.position.y, transform.position.z);
        }

    }
}
