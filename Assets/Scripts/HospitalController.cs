using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalController : MonoBehaviour
{
    private int spawnRate = 15;
    public GameObject patient;

    void Start()
    {
        InvokeRepeating("spawnPatient", 0f, spawnRate);
    }

    private void recalibrateSpawn()
    {
        CancelInvoke("spawnPatient");
        InvokeRepeating("spawnPatient", 0f, spawnRate);
    }

    public void spawnPatient()
    {
        GameObject newPatient = Instantiate(patient, transform.position, Quaternion.identity) as GameObject;
        newPatient.transform.SetParent(GameObject.Find("GameBoard").transform);
    }

    public void IncreaseSpawnRate()
    {
        spawnRate--;
        recalibrateSpawn();
    }

    public void DecreaseSpawnRate()
    {
        spawnRate++;
        recalibrateSpawn();
    }

    public int getSpawnRate()
    {
        return spawnRate;
    }

}
