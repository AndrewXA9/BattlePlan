using UnityEngine;
using System.Collections;

public class resizeToScreen : MonoBehaviour {
	
	void Start () {
		this.transform.localScale = new Vector3((Camera.main.orthographicSize*2)*Camera.main.aspect,(Camera.main.orthographicSize*2),1);
	}
	
}
