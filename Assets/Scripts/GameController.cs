using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject failSound;
    public TMP_Text moneytxt;
    public TMP_Text patientNumtxt;
    public TMP_Text failuretxt;
    public TMP_Text successtxt;

    public TMP_Text spawnTimerText;

    public GameObject bed;
    public GameObject diagnosis;
    public GameObject surgery;

    public GameObject recovery;

    public GameObject popup;

    private int money;
    private int patientNum;
    private int failure;
    private int success;

    private HospitalController hospital;

    void Awake()
    {
        hospital = GameObject.FindGameObjectWithTag("hospital").GetComponent<HospitalController>();
    }
    void Start()
    {
        InvokeRepeating("calculateMoney", 0f, 5f);
        setUpGame();
        InvokeRepeating("spawnPopUp", 0f, 30f);
    }

    void Update()
    {
        calculatepatientnum();
        updateSuccessText();
        updateMoneyText();
        updateFailureText();
        updateTimerText();
        if(failure == 25)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void setUpGame()
    {
        Vector3 bedPos = new Vector3(-10, 0 , 0);
        Vector3 DiagPos = new Vector3(0, 0, 0);
        Vector3 SurgPos = new Vector3(10, 0, 0);
        Vector3 recovPos = new Vector3(5, -3, 0);
        GameObject startBed = Instantiate(bed, bedPos, Quaternion.identity);
        startBed.transform.SetParent(GameObject.Find("GameBoard").transform);
        startBed.GetComponent<BedController>().setAlrPlaced();
        GameObject startDiag = Instantiate(diagnosis, DiagPos, Quaternion.identity);
        startDiag.transform.SetParent(GameObject.Find("GameBoard").transform);
        startDiag.GetComponent<DiagnosisController>().setAlrPlaced();
        GameObject startSurg = Instantiate(surgery, SurgPos, Quaternion.identity);
        startSurg.transform.SetParent(GameObject.Find("GameBoard").transform);
        startSurg.GetComponent<SurgeryController>().setAlrPlaced();
        GameObject startRecov = Instantiate(recovery, recovPos, Quaternion.identity);
        startRecov.transform.SetParent(GameObject.Find("GameBoard").transform);
        startRecov.GetComponent<RecoveryController>().setAlrPlaced();
    }
    public void calculateMoney()
    {
        GameObject[] bedList = GameObject.FindGameObjectsWithTag("bed");
        GameObject[] diagList = GameObject.FindGameObjectsWithTag("diagnosis");
        GameObject[] surgList = GameObject.FindGameObjectsWithTag("surgery");
        GameObject[] recList = GameObject.FindGameObjectsWithTag("recovery");
        int bedNum;
        int diagNum;
        int surgNum;
        int recNum;
        bedNum = GameObject.FindGameObjectsWithTag("bed").Length;
        diagNum = GameObject.FindGameObjectsWithTag("diagnosis").Length;
        surgNum = GameObject.FindGameObjectsWithTag("surgery").Length;
        recNum = GameObject.FindGameObjectsWithTag("recovery").Length;

        if(bedList.Length != 0 && diagList.Length != 0 && surgList.Length != 0 && recList.Length != 0)
        {
            money = money + 10 - bedNum - diagNum - surgNum - recNum;
        }
        else
        {
            money = money + 10;
        }
    }

    public void spawnPopUp()
    {
        popup.GetComponent<PopUpController>().generatePopUp();
    }

    public void updateMoneyText()
    {
        moneytxt.text = money.ToString();
    }

    public int getMoney()
    {
        return money;
    }

    public void calculatepatientnum()
    {
        patientNum = GameObject.FindGameObjectsWithTag("patient").Length;
        patientNumtxt.text = patientNum.ToString();
    }

    public void updateSuccessText()
    {
        successtxt.text = success.ToString();
    }

    public void addSuccess()
    {
        success++;
        money = money + 10;
    }

    public void updateFailureText()
    {
        failuretxt.text = failure.ToString();
    }

    public void updateTimerText()
    {
        int spawnrate = hospital.getSpawnRate();
        spawnTimerText.text = spawnrate.ToString();
    }

    public void addFailure(GameObject patient)
    {
        Destroy(patient);
        failure++;
        Instantiate(failSound);
    }

    public void buyBed()
    {
        money = money - 10;
    }

    public void buyDiag()
    {
        money = money - 20;
    }

    public void buySurg()
    {
        money = money - 30;
    }

    public void sellBed()
    {
        money = money + 5;
    }

    public void sellDiag()
    {
        money = money + 10;
    }

    public void sellSurg()
    {
        money = money + 15;
    }

    public void buyRec()
    {
        money = money - 20;
    }

    public void sellRec()
    {
        money = money + 10;
    }
}
