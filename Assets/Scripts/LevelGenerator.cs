using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
    Dictionary<int, int[][]>  levels = new Dictionary<int, int[][]>();

    public int[][] level = new int[][] {
                            new int[] { 0, 1, 1, 0, 0, 1, 1, 0 },
                            new int[] { 0, 1, 0, 1, 1, 0, 1, 0 },
                            new int[] { 1, 0, 1, 1, 1, 1, 1, 1 },
                            new int[] { 1, 0, 1, 1, 1, 1, 0, 1 },
                            new int[] { 0, 1, 0, 1, 1, 0, 1, 0 },
                            new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                            new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                            new int[] { 0, 1, 1, 1, 1, 1, 1, 0 }
    };
      
    public int[][] level2 = new int[][] {
                            new int[] { 0, 0, 0, 1, 1, 0, 0, 0 },
                            new int[] { 0, 0, 1, 1, 1, 1, 0, 0 },
                            new int[] { 0, 1, 1, 1, 1, 1, 1, 0 },
                            new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                            new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                            new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                            new int[] { 0, 1, 1, 1, 1, 1, 1, 0 },
                            new int[] { 0, 0, 1, 1, 1, 1, 0, 0 }
                        };

    public int[][] level3 = new int[][] {
                            new int[] { 0, 0, 0, 1, 1, 0, 0, 0 },
                            new int[] { 0, 0, 1, 0, 0, 1, 0, 0 },
                            new int[] { 0, 1, 0, 1, 1, 0, 1, 0 },
                            new int[] { 1, 0, 1, 1, 1, 1, 0, 1 },
                            new int[] { 1, 1, 1, 0, 0, 1, 1, 1 },
                            new int[] { 1, 0, 1, 1, 1, 1, 0, 1 },
                            new int[] { 0, 1, 0, 1, 1, 0, 1, 0 },
                            new int[] { 0, 0, 1, 1, 1, 1, 0, 0 }
                        };

    public GameObject[] bricks;
    bool isRunning = false;

    // Use this for initialization
    void Start() {

        levels.Add(0, level);
        levels.Add(1, level2);
        levels.Add(2, level3);

        int[][] selectedLevel;
        selectedLevel = levels[Random.Range(0, 2)];

        // CONSTS
        int brick_width = 24;
        int brick_height = 13;
        int x_offset = 6;
        int y_offset = 2;

        int y = 0;
        for (int i = 0; i < selectedLevel.Length; i++) {
            int[] row = selectedLevel[i];

            int x = 0;
            for (int j = 0; j < row.Length; j++) {
                if(row[j] == 1) {
                    GameObject toInstantiate;
                    toInstantiate = bricks[0] as GameObject;

                    GameObject instance = Instantiate(toInstantiate, new Vector3(0, 0, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(transform);
                    instance.transform.localPosition = new Vector3(x, y, 0f);
                }

                x = x + brick_width + x_offset;
            }

            y = y - brick_height - y_offset;
        }
    }
	
	// Update is called once per frame
	void Update () {
        bool hasChild = false;

        foreach (Transform child in transform) {
            hasChild = true;
        }

        if(!hasChild) {
            StartCoroutine(Launch(2.0f));
        }

        if(isRunning) {
        }
    }

    IEnumerator Launch(float waitTime) {
        isRunning = true;
        yield return new WaitForSeconds(waitTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        isRunning = false;
    }
}
