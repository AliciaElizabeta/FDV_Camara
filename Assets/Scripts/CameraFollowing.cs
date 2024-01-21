using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{	
    public Transform target;
	public float smoothSpeed = 1f;
	public Vector3 offset;
	private float y;
	private Vector3 velocity = Vector3.zero;
	Vector3 desiredPosition;
	Vector3 smoothedPosition;


	void LateUpdate ()
	{
		y = transform.position.y;
		desiredPosition = target.position + offset;
		desiredPosition.y = y;
		smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;
	}
}
