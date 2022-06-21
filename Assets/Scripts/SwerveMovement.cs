using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerweInput swerweInput;
    public float swerveAmount;
    public Animator anim;

    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 2f;

    public float edgeDistance;
    public float moveSpeed = 5f;

    public GameManager manager;
    Rigidbody rb2;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    public ParticleSystem obstacleParticle;

    void Start()
    {
        swerweInput = GetComponent<SwerweInput>();
       
        rb2 = GetComponent<Rigidbody>();  
    }

    void FixedUpdate()
    {
        Run();
        
        

    }
    void Run()
    {
        if (manager.state == GameManager.GameState.Running)
        {
            if (knockBackCounter <= 0)
            {

                swerveAmount = swerweInput.MoveFactorX * swerveSpeed * Time.fixedDeltaTime;
                swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);



                transform.position += new Vector3(swerveAmount, 0, moveSpeed * Time.fixedDeltaTime);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -edgeDistance, edgeDistance),
                    transform.position.y, transform.position.z);
                
                
            }
            else
            {
                knockBackCounter -= Time.fixedDeltaTime;

            }
        }

    }

    public void KnockBack()
    {
        Debug.Log("Calisti");
        obstacleParticle.Play();
        knockBackCounter = knockBackTime;
        rb2.AddForce(new Vector3(0, 0, -1) * knockBackForce);
        anim.SetTrigger("Idle");
        
    }
}
