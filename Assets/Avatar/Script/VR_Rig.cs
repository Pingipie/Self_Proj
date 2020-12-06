using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class VR_Map
{
	public Transform vrTarget;
	public Transform rigTarget;
	public Vector3 trackingPositionOffset;
	public Vector3 trackingRotationOffset;

    public void Map()
	{
		rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
		rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
	}
}

public class VR_Rig : MonoBehaviour
{
	public VR_Map head;
	public VR_Map leftHand;
	public VR_Map rightHand;

	public Transform headConstraint;
	public Vector3 headBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
		headBodyOffset = transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = headConstraint.position + headBodyOffset;
		transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;

		head.Map();
		leftHand.Map();
		rightHand.Map();
    }
}
