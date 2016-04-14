using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float interpVelocity;
	public GameObject level;

	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;

	[SerializeField]
	private float interpMultiplier;

	private Vector3 mapBoundMax, mapBoundMin;
	private Camera cam;
	private float halfCameraHeight, halfCameraWidth;

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
		interpMultiplier = 10f;

		cam = GetComponent<Camera> ();
		mapBoundMax = level.GetComponent<Renderer> ().bounds.max;
		mapBoundMin = level.GetComponent<Renderer> ().bounds.min;
		halfCameraHeight = cam.orthographicSize;
		halfCameraWidth = cam.aspect * cam.orthographicSize;
		Debug.Log (mapBoundMax);
		Debug.Log (mapBoundMin);
		Debug.Log (halfCameraWidth);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * interpMultiplier;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

			//TODO Do it with Math.Clamp
			if (transform.position.y <= mapBoundMin.y + halfCameraHeight)
				transform.position = Vector3.Lerp( new Vector3(transform.position.x, mapBoundMin.y + halfCameraHeight, transform.position.z), targetPos + offset, 0f);

			if (transform.position.y >= -halfCameraHeight)
				transform.position = Vector3.Lerp( new Vector3(transform.position.x, -halfCameraHeight, transform.position.z), targetPos + offset, 0f);

			if(transform.position.x <= halfCameraWidth)
				transform.position = Vector3.Lerp( new Vector3(halfCameraWidth, transform.position.y, transform.position.z), targetPos + offset, 0f);

			if (transform.position.x >= mapBoundMax.x - halfCameraWidth)
				transform.position = Vector3.Lerp( new Vector3(mapBoundMax.x - halfCameraWidth, transform.position.y, transform.position.z), targetPos + offset, 0f);

		}
	}
}