using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform PointPrefab;

    void Awake()
    {
        // instantiating a object/transform/prefab will return a new transform
        Transform point = Instantiate(this.PointPrefab);
        point.localPosition = Vector3.right; // shorthand for writing Vector(1, 0, 0)

        // we can reuse the variable for the second instantiation, as we're not
        // going to use it anymore for the first cube
        point = Instantiate(this.PointPrefab);
        point.localPosition = Vector3.right * 2f; // shorthand for writing Vector(1, 0, 0)

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
