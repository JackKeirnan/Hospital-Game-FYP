using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessController : MonoBehaviour
{
    public GameObject GameController;
    private GameObject patient;

    void OnTriggerEnter2D (Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent<PatientController>(out PatientController patient))
        {
            Destroy (collider.gameObject);
            GameController.GetComponent<GameController>().addSuccess();
        }
    }
}
