using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	
	public Rigidbody2D rb;
	float constantSpeed = 8.8f;
	bool finishedDragging = false;
	bool dragged = false;
	Vector3 startingPosition;
	Vector3 endingPosition;

	void Start(){

		//rb = GetComponent<Rigidbody2D> ();
		startingPosition= rb.position;
	

	}

	void Update() { 

		if (finishedDragging == true) {
			rb.velocity = constantSpeed * (rb.velocity.normalized);
		}

		BoundChecker ();

	}

	void OnMouseDrag(){
		dragged = true;
		endingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		rb.position = endingPosition;

	}

	void OnMouseUp(){
		if (dragged == true) {
			finishedDragging = true;

			Vector3 diff = (endingPosition - startingPosition).normalized;
			rb.velocity = diff;
		}
	}

	void BoundChecker(){
		if(rb.position.x>1.75 || rb.position.x<-1.75 || rb.position.y >2.7 || rb.position.y<-2.7){
			rb.position = startingPosition;
			rb.velocity = new Vector3(0, 0, 0);
			ScoreScript.score = 0;
		}
	}

}
