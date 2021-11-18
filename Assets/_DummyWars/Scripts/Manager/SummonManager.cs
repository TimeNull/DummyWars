using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonManager : MonoBehaviour
{

    [SerializeField] Camera sceneCamera;
    RaycastHit hit;
    [SerializeField] LayerMask layersToAffect;
    public static GameObject spawnObject;
    public static int costMob;


    void Update()
    {
        Ray rayCast = sceneCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast (rayCast, out hit, Mathf.Infinity, layersToAffect))
        {
            if(hit.transform.tag == "Ground" && Input.GetMouseButtonDown(0) && spawnObject != null && MoneyManager.remainingMoney - costMob >= 0) //coloca inimigo
            {
                Instantiate(spawnObject, hit.point, Quaternion.identity);
                MoneyManager.remainingMoney -= costMob;
                //UpdateCostColor.updateColor(); // ele da null reference aq e n tenho ideia do pq
                UpdateRemainingMoney.updateMoneyText();
            }

            if(hit.transform.tag == "Ally" && Input.GetMouseButton(1) && !MoveCamera.cameraOn) //tira inimigo
            {
                Destroy(hit.transform.gameObject);
                MoneyManager.remainingMoney += hit.transform.GetComponent<Cost>().cost;
                //UpdateCostColor.updateColor(); // aq tbm
                UpdateRemainingMoney.updateMoneyText();
            }
        }
    }
}
