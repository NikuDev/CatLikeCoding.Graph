using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform PointPrefab;

    void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            Transform point = Instantiate(this.PointPrefab);

            // we'd like the range to be x: -1 to x:1 instead of x:0 to x:2
            // so substract -1 at the end of the formula

            // edit2: to compensate the width of a prefab (0.2), we'll add 0.5f
            // to the current iteration. this will center it on -1, -0.8, -0.6
            // opposed to -1.1, -0.9, -0.7 etc.
            point.localPosition = Vector3.right * ((i + 0.5f) / 5f - 1f);

            // reduce the scale of the prefab to create space between them
            // we'll use 5 cubes per 1x/y/z
            point.localScale = Vector3.one / 5f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
