using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    public GameObject enterSound;
    private bool alrPlaced = false;
    public int patientNum;
    private GameObject patient;

    private int waitTime = 10;

    GameController gameController;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent<PatientController>(out PatientController patient))
        {
            if(patient.getFirstBed() == false)
            {
                StartCoroutine("takeInPatient", collider.gameObject);

            }
        }
    }

    public void CheckDrop(GameObject dropLocation)
    {
        if(dropLocation.name == "GameBoard")
        {
            if(alrPlaced == false)
            {
                if(gameController.getMoney() < 10)
                {
                    Destroy(gameObject);
                }
                else
                {
                    alrPlaced = true;
                    gameController.buyBed();
                }
            }
        }
        else if(dropLocation.name == "BottomBoard")
        {
            if(alrPlaced == true)
            {
                gameController.sellBed();
                Destroy(gameObject);
            }
        }
    }

    public IEnumerator takeInPatient(GameObject patientTaken)
    {
        Instantiate(enterSound);
        patientTaken.SetActive(false);
        patientNum++;
        patientTaken.GetComponent<PatientController>().setFirstBed();
        yield return new WaitForSeconds(waitTime);
        patientTaken.SetActive(true);
        patientNum--;
    }

    public int getPatientNum()
    {
        return patientNum;
    }

    public bool getAlrPlaced()
    {
        return alrPlaced;
    }

    public void setAlrPlaced()
    {
        alrPlaced = true;
    }

}
