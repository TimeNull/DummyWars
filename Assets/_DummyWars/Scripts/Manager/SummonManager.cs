using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonManager : MonoBehaviour
{

    [SerializeField] Camera sceneCamera;
    RaycastHit hit;
    [SerializeField] LayerMask layersToAffect;
    public static GameObject spawnObject;


    void Update()
    {
        Ray rayCast = sceneCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast (rayCast, out hit, Mathf.Infinity, layersToAffect))
        {
            if(hit.transform.tag == "Ground" && Input.GetMouseButtonDown(0) && spawnObject != null)
            {
                Instantiate(spawnObject, hit.point, Quaternion.identity);
            }

            if(hit.transform.tag == "Ally" && Input.GetMouseButton(1))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
