using UnityEngine;
using System.Collections;

public class JumpColor : MonoBehaviour
{
	GameObject one = null;
	GameObject two = null;
	  // Use this for initialization
    void Start()
    {
	}
   
    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown (0)) {
			Ray xRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (xRay, out hit, 100f)) {
				if (one == null) {
					one = hit.collider.gameObject;
					iTween.RotateTo (one, iTween.Hash("y", 180, "looptype", "time", 5, iTween.LoopType.loop));
				} else {
					two = hit.collider.gameObject;
					iTween.RotateTo (two, iTween.Hash("y", 180, "looptype", "time", 5, iTween.LoopType.loop));
					if (Vector3.Distance(one.transform.position, two.transform.position) == 1) {
						iTween.MoveTo (one, iTween.Hash ("x", two.transform.position.x, "y", two.transform.position.y, "z", two.transform.position.z, "time", 2, "easetype", iTween.EaseType.easeOutBounce));
						iTween.MoveTo (two, iTween.Hash ("x", one.transform.position.x, "y", one.transform.position.y, "z", one.transform.position.z, "time", 2, "easetype", iTween.EaseType.easeOutBounce));
						print (one.transform.position + " + " + two.transform.position);
						if (two.GetComponent<MeshRenderer>().material.color == Grid.cub[(int)one.transform.position.y, (int)one.transform.position.x + 1].GetComponent<MeshRenderer>().material.color){
							Destroy(gameObject);
							Destroy ( Grid.cub[(int)one.transform.position.y, (int)one.transform.position.x + 1]);
							
						}
					}
					one = null;
					two = null;
				}
			}
		}
	}
}