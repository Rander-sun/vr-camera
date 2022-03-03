using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RegionMaker : MonoBehaviour
{
    public Transform plane;//ground
    public Transform centers;//spheres
    public float x;
    public float y;
    public List<Region> regions = new List<Region>();
    
    // Start is called before the first frame update
    void Start()
    {
        var size = plane.GetComponent<Renderer>().bounds.size;
        Debug.Log ("x: " + size.x + ",y: " + size.z);//Length and width of the ground
        Vector3 startPos = plane.position - new Vector3(size.x / 2, 0, size.z / 2);//Take the lower left corner as the origin
        for (float i = x/2; i < size.x; i += x)
        {
            for (float j = y/2; j < size.z; j += y)
            {
                //Blocking
                Debug.Log("A loop！");
                Region region = new Region(x, y, startPos+new Vector3(i, size.y,j));
                regions.Add(region);
                Debug.Log("pos: " + region.pos);
                
                //Generating the central sphere
                var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.GetComponent<Renderer>().material.color=Color.red;
                sphere.transform.position = region.pos;
                sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                sphere.transform.parent = centers;
                
            }
        }
        // for (float i = 1f; i < 5f; i++)
        // {
        //     for (float j = 1f; j < 5f; j++)
        //     {
        //         Region region = new Region();
        //     }
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
