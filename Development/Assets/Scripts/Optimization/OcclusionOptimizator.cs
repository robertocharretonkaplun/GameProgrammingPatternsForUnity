using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionOptimizator : MonoBehaviour
{
  public int RayAmount = 1500;
  public int RayDistance = 300;
  public float stayTime = 2;

  public Camera camera;

  public Vector2[] Points;

  private void Start()
  {
    camera = GetComponent<Camera>();
    Points = new Vector2[RayAmount];

    GetPoints();
  }

  private void Update()
  {
    CastRay();
  }

  void GetPoints()
  {
    float x = 0;
    float y = 0;

    for (int i = 0; i < RayAmount; i++)
    {
      if (x > 1)
      {
        x = 0;
        y += 1 / Mathf.Sqrt(RayAmount);
      }

      Points[i] = new Vector2(x, y);
      x+= 1 / Mathf.Sqrt(RayAmount);
    }
  }

  void CastRay()
  {
    for (int i = 0; i < RayAmount; i++)
    {
      Ray ray;
      RaycastHit hit;
      OcclusionObject ocl;


      ray = camera.ViewportPointToRay(new Vector3(Points[i].x, Points[i].y, 0));
      if (Physics.Raycast(ray, out hit, RayDistance))
      {
        //Debug.DrawRay(transform.position, hit.point);
        if (ocl = hit.transform.GetComponent<OcclusionObject>())
        {
          ocl.HitOcclude(stayTime);
        }
      }
    }
  }
}
