using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryController : MonoBehaviour
{
    public GameObject enterSound;
    private bool alrPlaced = false;
    public int patientNum;
    private GameObject patient;

    private int waitTime = 25;

    GameController gameController;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent<PatientController>(out PatientController patient))
        {
            if(patient.getFirstRecov() == false)
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
                if(gameController.getMoney() < 20)
                {
                    Destroy(gameObject);
                }
                else
                {
                    alrPlaced = true;
                    gameController.buyRec();
                }
            }
        }
        else if(dropLocation.name == "BottomBoard")
        {
            if(alrPlaced == true)
            {
                gameController.sellRec();
                Destroy(gameObject);
            }
        }
    }

    public IEnumerator takeInPatient(GameObject patientTaken)
    {
        Instantiate(enterSound);
        patientTaken.SetActive(false);
        patientNum++;
        patientTaken.GetComponent<PatientController>().setFirstRecov();
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
