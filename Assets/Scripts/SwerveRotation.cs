using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveRotation : MonoBehaviour
{
    private SwerweInput swerweInput;
    public float swerveAmount;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 2f;

    public float sensivity;

    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        swerweInput = GetComponent<SwerweInput>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (manager.state == GameManager.GameState.Running)
        {
            float swerveAmount = Time.fixedDeltaTime * sensivity * swerweInput.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.rotation = Quaternion.Euler(0, swerveAmount, 0);
        }
    }
}
    