using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PatientController : MonoBehaviour
{
    public GameController gameController;
    public float speed = 5f;
    private bool firstBed = false;
    private bool firstDiag = false;
    private bool firstSurg = false;
    public bool firstRecov = false;

    public List<GameObject> recovList;

    private bool shouldRecover;

    private void Awake()
    {
        System.Random random = new System.Random();
        int decideRecover = random.Next(1, 3);
        if(decideRecover == 1)
        {
            shouldRecover = false;
        }
        else if(decideRecover == 2)
        {
            shouldRecover = true;
        }
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if(firstBed == false)
        {
            moveToBed();
        }
        else if (firstBed == true && firstDiag == false)
        {
            moveToDiag();
        }
        else if(firstBed == true && firstDiag == true && firstSurg == false)
        {
            moveToSurg();
        }
        else if(firstBed == true && firstDiag == true && firstSurg == true && shouldRecover == false || firstRecov == true)
        {
            moveToSuccess();
        }
        else if(firstBed == true && firstDiag == true && firstSurg == true && shouldRecover == true)
        {
            moveToRecov();
        }
    }

    public void triggerFailure()
    {
        gameController.addFailure(gameObject);
    }

    public GameObject findNearestBed()
    {
        List<GameObject> bedList = new List<GameObject>(GameObject.FindGameObjectsWithTag("bed"));
        foreach(GameObject i in bedList.ToList())
        {
            if(i.GetComponent<BedController>().getPatientNum() == 3 || i.GetComponent<BedController>().getAlrPlaced() == false)
            {
                bedList.Remove(i);
            }
        }
        if(bedList.Count == 0 || bedList == null)
        {
            return null;
        }
        Vector3 currentPos = transform.position;
        return bedList.OrderBy(x => Vector3.Distance(x.transform.position, currentPos)).First();
    }

    public GameObject findNearestDiag()
    {
        List<GameObject> diagList = new List<GameObject>(GameObject.FindGameObjectsWithTag("diagnosis"));
        foreach(GameObject i in diagList.ToList())
        {
            if(i.GetComponent<DiagnosisController>().getPatientNum() == 3 || i.GetComponent<DiagnosisController>().getAlrPlaced() == false)
            {
                diagList.Remove(i);
            }
        }
        if(diagList.Count == 0 || diagList == null)
        {
            return null;
        }
        Vector3 currentPos = transform.position;
        return diagList.OrderBy(x => Vector3.Distance(x.transform.position, currentPos)).First();
    }

    public GameObject findNearestSurg()
    {
        List<GameObject> surgList = new List<GameObject>(GameObject.FindGameObjectsWithTag("surgery"));
        foreach(GameObject i in surgList.ToList())
        {
            if(i.GetComponent<SurgeryController>().getPatientNum() == 3 || i.GetComponent<SurgeryController>().getAlrPlaced() == false)
            {
                surgList.Remove(i);
            }
        }
        if(surgList.Count == 0 || surgList == null)
        {
            return null;
        }
        Vector3 currentPos = transform.position;
        return surgList.OrderBy(x => Vector3.Distance(x.transform.position, currentPos)).First();
    }

    public GameObject findNearestRecov()
    {
        recovList = new List<GameObject>(GameObject.FindGameObjectsWithTag("recovery"));
        foreach(GameObject i in recovList.ToList())
        {
            if(i.GetComponent<RecoveryController>().getPatientNum() == 3 || i.GetComponent<RecoveryController>().getAlrPlaced() == false)
            {
                recovList.Remove(i);
            }
        }
        if(recovList.Count == 0 || recovList == null)
        {
            return null;
        }
        Vector3 currentPos = transform.position;
        return recovList.OrderBy(x => Vector3.Distance(x.transform.position, currentPos)).First();
    }

    public void moveToBed()
    {
        GameObject bed = findNearestBed();
        if(bed == null)
        {
            triggerFailure();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, bed.transform.position, speed * Time.deltaTime);
        }
    }

    public void moveToDiag()
    {
        GameObject diagnosis = findNearestDiag();
        if(diagnosis == null)
        {
            triggerFailure();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, diagnosis.transform.position, speed * Time.deltaTime);
        }
    }

    public void moveToSurg()
    {
        GameObject surgery = findNearestSurg();
        if(surgery == null)
        {
            triggerFailure();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, surgery.transform.position, speed * Time.deltaTime);
        }
    }

    public void moveToSuccess()
    {
        GameObject success = GameObject.FindWithTag("success");
        transform.position = Vector2.MoveTowards(transform.position, success.transform.position, speed * Time.deltaTime);
    }

    public void moveToRecov()
    {
        GameObject recov = findNearestRecov();
        if(recov == null)
        {
            triggerFailure();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, recov.transform.position, speed * Time.deltaTime);
        }
    }

    public void setFirstBed()
    {
        firstBed = true;
    }

    public bool getFirstBed()
    {
        return firstBed;
    }

    public void setFirstDiag()
    {
        firstDiag = true;
    }

    public bool getFirstDiag()
    {
        return firstDiag;
    }

    public void setFirstSurg()
    {
        firstSurg = true;
    }

    public bool getFirstSurg()
    {
        return firstSurg;
    }

    public void setFirstRecov()
    {
        firstRecov = true;
    }

    public bool getFirstRecov()
    {
        return firstRecov;
    }

    public bool getshouldRecover()
    {
        return shouldRecover;
    }

}
