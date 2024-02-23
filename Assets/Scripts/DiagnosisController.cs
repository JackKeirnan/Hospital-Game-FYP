using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnosisController : MonoBehaviour
{
    public GameObject enterSound;
    public bool alrPlaced = false;
    private int patientNum;
    private GameObject patient;

    private int waitTime = 15;

    GameController gameController;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent<PatientController>(out PatientController patient))
        {
            if(patient.getFirstDiag() == false)
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
                    gameController.buyDiag();                   
                }
            }
        }
        else if(dropLocation.name == "BottomBoard")
        {
            if(alrPlaced == true)
            {
                gameController.sellDiag();
                Destroy(gameObject);
            }
        }
    }

    public IEnumerator takeInPatient(GameObject patientTaken)
    {
        Instantiate(enterSound);
        patientTaken.SetActive(false);
        patientNum++;
        patientTaken.GetComponent<PatientController>().setFirstDiag();
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
