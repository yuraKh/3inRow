using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public Color[] Col = new Color[5];
	int k;
	public GameObject Cube;
	int yP = 0;
	int zP = 0;
	static public GameObject [,] cub = new GameObject[10,5];
	// Use this for initialization
	void Start () {

		for (int q = 0; q < 10; q++) {
			zP = 0;
			for (int j = 0; j < 5; j++) {
				k = Random.Range (0, 5);
				GameObject Cub = (GameObject)Instantiate (Cube);
				Cub.transform.position = new Vector3 (Cub.transform.position.x + zP, Cub.transform.position.y + yP, Cub.transform.position.z);
				Cub.GetComponent<MeshRenderer> ().material.color = Col [k];
				Cub.transform.name = "square" + string.Format ("{0:D2}", q) + " " + string.Format ("{0:D2}", j);
				cub [q, j] = Cub;
				zP++;
			}
			yP++;

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
