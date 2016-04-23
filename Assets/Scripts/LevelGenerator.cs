using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    public int[][] level = new int[][] {
                            new int[] { 1, 1, 1, 1, 1, 1, 3, 1 },
                            new int[] { 1, 4, 0, 0, 0, 4, 0, 1 },
                            new int[] { 1, 4, 0, 4, 0, 4, 0, 1 },
                            new int[] { 1, 4, 0, 4, 0, 4, 0, 1 },
                            new int[] { 1, 4, 0, 4, 0, 4, 0, 1 },
                            new int[] { 1, 4, 0, 4, 0, 4, 0, 1 },
                            new int[] { 1, 4, 0, 4, 0, 0, 0, 1 },
                            new int[] { 1, 1, 2, 1, 1, 1, 1, 1 }
                        };
    public GameObject[] bricks;

    // Use this for initialization
    void Start () {
        int y = 0;
        for (int i = 0; i < level.Length; i++) {
            int[] row = level[i];

            int x = 0;
            for (int j = 0; j < row.Length; j++) {

                int tile = row[j];
                x = x + 24;
                GameObject toInstantiate;
                toInstantiate = bricks[0] as GameObject;
                
                Debug.Log(x + " : " + y);

                GameObject instance = Instantiate(toInstantiate, new Vector3(0, 0, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(transform);
                instance.transform.localPosition = new Vector3(x, y, 0f);
            }
            y = y - 13;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
