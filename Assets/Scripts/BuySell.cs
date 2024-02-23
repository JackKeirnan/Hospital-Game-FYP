using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySell : MonoBehaviour
{
    public GameObject bed;
    public GameObject diagnosis;
    public GameObject surgery;
    public GameObject recovery;

    private void Awake()
    {
        SpawnBedBuy();
        SpawnDiagBuy();
        SpawnSurgBuy();
        SpawnRecBuy();
    }

    private void Update()
    {
        List<string> children = new List<string>();
        foreach(Transform child in gameObject.transform)
        {
            children.Add(child.tag);
        }

        if(!children.Contains("bed"))
        {
            SpawnBedBuy();
        }
        else if(!children.Contains("diagnosis"))
        {
            SpawnDiagBuy();
        }
        else if (!children.Contains("surgery"))
        {
            SpawnSurgBuy();
        }
        else if(!children.Contains("recovery"))
        {
            SpawnRecBuy();
        }

    }

    private void SpawnBedBuy()
    {
        Vector3 bedPos = new Vector3(-17, -7, 0);
        GameObject buyBed = Instantiate(bed, bedPos, Quaternion.identity);
        buyBed.transform.SetParent(GameObject.Find("BottomBoard").transform);

    }

    private void SpawnDiagBuy()
    {
        Vector3 diagPos = new Vector3(-14, -7, 0);
        GameObject buyDiag = Instantiate(diagnosis, diagPos, Quaternion.identity);
        buyDiag.transform.SetParent(GameObject.Find("BottomBoard").transform);

    }

    private void SpawnSurgBuy()
    {
        Vector3 surgPos = new Vector3(-11, -7, 0);
        GameObject buySurg = Instantiate(surgery, surgPos, Quaternion.identity);
        buySurg.transform.SetParent(GameObject.Find("BottomBoard").transform);
    }

    private void SpawnRecBuy()
    {
        Vector3 recPos = new Vector3(-8, -7, 0);
        GameObject buyRec = Instantiate(recovery, recPos, Quaternion.identity);
        buyRec.transform.SetParent(GameObject.Find("BottomBoard").transform);
    }
}
