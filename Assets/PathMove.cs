﻿using UnityEngine;
using System.Collections;

public class PathMove : MonoBehaviour {
	
	public bool go = false;
	public float speed;
	public Path path;
	public float progress = 0;
	
	void Update () {
		this.transform.position = Vector3.Lerp(path.nodeVectors[(int)(Mathf.Floor(progress))],path.nodeVectors[(int)(Mathf.Ceil(progress))],(progress)%1);
		//this.transform.localRotation = Quaternion.Lerp(path.nodeQuats[(int)(Mathf.Floor(progress))],path.nodeQuats[(int)(Mathf.Ceil(progress+1))],progress/(path.nodeVectors.Count-1f));
		progress += Time.deltaTime*speed;
	}
	
}
