using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path{
	
	public List<Vector3> nodeVectors;
	public List<Quaternion> nodeQuats;
	
	public Path(List<Vector3> input, int rez){
		
		nodeVectors = new List<Vector3>();
		
		int size = input.Count;
		float step = ((float)size/(float)rez);
		Debug.Log("Creating with rez of "+rez.ToString()+" from size of "+size.ToString());
		Debug.Log("Step size of "+step.ToString());
		
		for(int i=0;i<rez;i++){
			Debug.Log("Iteration "+i.ToString());
			float pos = Mathf.Clamp((float)step*i,0f,size-1f);
			Debug.Log("Position "+pos.ToString());
			nodeVectors.Add(Vector3.Lerp(input[(int)Mathf.Floor(pos)],input[(int)Mathf.Ceil(pos)],pos%1));
		}
		
		nodeQuats = new List<Quaternion>();
		
		for(int i=0;i<rez-1;i++){
			nodeQuats.Add(Quaternion.LookRotation(nodeVectors[i+1]-nodeVectors[i]));
		}
		nodeQuats.Add(nodeQuats[rez-2]);
		
	}
	
}
