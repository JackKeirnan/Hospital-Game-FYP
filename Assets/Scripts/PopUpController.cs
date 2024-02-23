using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PopUpController : MonoBehaviour
{
    public GameObject hospital;
    private PausePlay pause;
    private TextMeshProUGUI mainText;
    private Button option1;
    private Button option2;

    private TextMeshProUGUI button1Text;
    private TextMeshProUGUI button2Text;

    private UnityEngine.Events.UnityAction buttonOption1;
    private UnityEngine.Events.UnityAction buttonOption2;

    private void Awake()
    {
        pause = GameObject.FindGameObjectWithTag("pause").GetComponent<PausePlay>();
        mainText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        option1 = transform.Find("Option 1").GetComponent<Button>();
        option2 = transform.Find("Option 2").GetComponent<Button>();
        button1Text = transform.Find("Option 1").Find("Text").GetComponent<TextMeshProUGUI>();
        button2Text = transform.Find("Option 2").Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void showPopUp(string popUpText, string option1Text, string option2Text, Action option1Action, Action option2Action)
    {
        gameObject.SetActive(true);
        pause.Pause();
        mainText.text = popUpText;
        button1Text.text = option1Text;
        button2Text.text = option2Text;
        option1.onClick.AddListener(() => {
            Hide();
            pause.Play();
            option1Action();
        });
        option2.onClick.AddListener(() => {
            Hide();
            pause.Play();
            option2Action();
        });
    }

    public void generatePopUp()
    {
        showPopUp("Demand is increasing! Choose whether to allow more patients in or to let them queue outside to keep your current capacity.", "Let them in!", "Let them queue!", hospital.GetComponent<HospitalController>().IncreaseSpawnRate, hospital.GetComponent<HospitalController>().DecreaseSpawnRate);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
