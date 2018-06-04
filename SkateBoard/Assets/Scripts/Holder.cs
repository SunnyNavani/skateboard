using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour{


	


	public GameObject initSpawnPoint;
	public GameObject[] platforms;
	//public float delayTimer=1f;


	//public CameraScript cam;
	public float bounds;
	float timer;
	public float start, end;
		
	public Vector3 initPosition;
	public GameObject gameObject1;
	public static class WorldContext
	{
		public static float OffScreenX = 0.2f;
		public static float OffScreenY = -14.9f;
	}


	private void Awake(){
		initPosition = initSpawnPoint.transform.position;
		
		currentPositon = initPosition;
//		initPosition = currentPositon = transform.position;
	}
	private void Start (){

		//timer = delayTimer;	
	}
	void Update()
	{
		//timer -= Time.deltaTime;
		//if (timer <= 0) {
		//	timer = delayTimer;
		if (transform.position.x < Camera.main.transform.position.x - WorldContext.OffScreenX) {
			prev = Instantiate (platforms [Random.Range (0, platforms.Length)], currentPositon, Quaternion.identity, transform);
			float minClear = prev.GetComponent<EdgeCollider2D> ().bounds.size.x;
			float diff = Random.Range (minClear + 3f, minClear + 3f);
			currentPositon = currentPositon + new Vector3 (diff, Random.Range (start, end), 0);
			currentPositon.y = Mathf.Clamp (currentPositon.y, initPosition.y - bounds, initPosition.y + bounds);
		} 
		if (transform.position.x > Camera.main.transform.position.x - WorldContext.OffScreenX)
			Destroy (gameObject1);

}



//	private void createBlock(){
//
//
//	}
	

	
	// Update is called once per frame
//	private void Update (){

		
//		if (prev.transform.position.x <= cam.getRightBound() + cam.getCamLength()){
//			createBlock();
//		
//		}
//
//		int childCount =  transform.childCount;
//		for (int i = childCount-1; i >= 0; --i){
//			var trans = transform.GetChild(i);
//			if (trans.position.x+cam.getCamLength()*1.5f <= cam.transform.position.x){
//				Destroy(trans.gameObject);
//			}
//			
//		}
		
//	}
	
	private Vector3 currentPositon;
	private GameObject prev;
	private float camPos;


}
