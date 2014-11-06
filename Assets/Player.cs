using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public enum States {Drawing, Shooting, Boosting, Simulating};
	public States state;
	
	private Rect drawRect;
	
	private List<Vector3> prePath;
	public int progress;
	
	public Texture star;
	
	void Start () {
		drawRect = new Rect(0,0,Screen.width,Screen.height);
		
		state = States.Drawing;
		NextState();
	}
	
	IEnumerator Drawing(){
		while(state == States.Drawing){
			
			RaycastHit hit;
			
			if(Input.GetMouseButtonDown(0)){
				prePath = new List<Vector3>();
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit)){
					prePath.Add(hit.point);
				}
			}
			if(Input.GetMouseButton(0)){
				Vector3 newPos = Vector3.zero;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit)){
					newPos = hit.point;
				}
				
				while((newPos-prePath[prePath.Count-1]).magnitude > 0.1f){
					
					prePath.Add(prePath[prePath.Count-1]+(Quaternion.LookRotation(newPos-prePath[prePath.Count-1])*(Vector3.forward*0.1f)));
				}
			}
			if(Input.GetMouseButtonUp(0)){
				dicks = new Path(prePath,100);
				//state = States.Simulating;
			}
			
			
			yield return null;
		}
		NextState();
	}
	
	IEnumerator Simulating(){
		progress = 0;
		while(state == States.Simulating){
			
			
			
			//while(progress < prePath.Count){
				
			//}
			
			yield return null;
		}
		NextState();
	}
	
	public Vector3 drawMe1;
	public Vector3 drawMe2;
	public Path dicks;
	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		if(prePath != null){
			foreach(Vector3 i in prePath){
				Gizmos.DrawSphere(i,0.05f);
			}
		}
		
		Gizmos.color = Color.green;
		if(dicks != null){
			foreach(Vector3 i in dicks.nodeVectors){
				Gizmos.DrawSphere(i,0.1f);
			}
			for(int i=0;i<dicks.nodeVectors.Count;i++){
				Gizmos.DrawLine(dicks.nodeVectors[i],dicks.nodeVectors[i]+(dicks.nodeQuats[i]*Vector3.forward));
			}
		}
		if(drawMe1 != null){
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(drawMe1,0.2f);
		}
		if(drawMe2 != null){
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(drawMe1,0.2f);
		}
	}
	
	
	void NextState(){
		StartCoroutine(state.ToString());
	}
	
	Vector3 Flipped(Vector3 input){
		return new Vector3(input.x,Screen.height-input.y,input.z);
	}
}
