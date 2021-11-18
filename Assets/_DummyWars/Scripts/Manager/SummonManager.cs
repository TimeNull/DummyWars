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
            if(hit.transform.tag == "Ground" && Input.GetMouseButtonDown(0) && spawnObject != null && MoneyManager.remainingMoney - costMob >= 0)
            {
                Instantiate(spawnObject, hit.point, Quaternion.identity);
                MoneyManager.remainingMoney -= costMob;
                //UpdateCostColor.updateColor(); // ele da null reference aq e n tenho ideia do pq
                UpdateRemainingMoney.updateMoneyText();
            }

            if(hit.transform.tag == "Ally" && Input.GetMouseButton(1))
            {
                Destroy(hit.transform.gameObject);
                MoneyManager.remainingMoney += costMob;
                //UpdateCostColor.updateColor(); // aq tbm
                UpdateRemainingMoney.updateMoneyText();
            }

            if (hit.transform.tag == "Enemy" && Input.GetMouseButtonDown(0))
            {
                hit.transform.gameObject.GetComponent<Life>().ReceiveDamage(100);
            }
        }
    }
}
