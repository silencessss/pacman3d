using UnityEngine;
using System.Collections;

public class AnimationPickUp : MonoBehaviour {

	public float scaleSpeed;
	public float durationScaleMax;
	private float durationScale;
	private bool scale;

	void Start() {
		scale = true;
		durationScale = 0;
	}
	// Update is called once per frame
	void Update () {
		if(durationScale <= durationScaleMax && scale == true) {
			if(durationScale == durationScaleMax)
				scale = false;
			else {
				++durationScale;
			}
			transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
		} else {
			if(durationScale == 0)
				scale = true;
			else {
				--durationScale;
			}
			transform.localScale -= new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
		}
	}
}
