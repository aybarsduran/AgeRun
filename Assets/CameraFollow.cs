using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraFollow : MonoBehaviour
{
	// Start is called before the first frame update
	public static CameraFollow instance;

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;
	public Vector3 transformoffset;




	private void Awake()
	{
		instance = this;




	}



	void Update()
	{


		Vector3 desiredPosition = target.position + offset;

		Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(desiredPosition.x, desiredPosition.y, desiredPosition.z),smoothSpeed);
		transform.position = smoothedPosition;

		//transform.rotation = Quaternion.Euler(transformoffset.x, transformoffset.y, transformoffset.z);


	}
}