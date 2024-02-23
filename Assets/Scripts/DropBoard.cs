using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropBoard : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        DragDrop d = eventData.pointerDrag.GetComponent<DragDrop>();
        if(eventData.pointerDrag.GetComponent<BedController>())
        {
            BedController Bed = eventData.pointerDrag.GetComponent<BedController>();
            Bed.CheckDrop(gameObject);
        }
        else if(eventData.pointerDrag.GetComponent<DiagnosisController>())
        {
            DiagnosisController Diagnosis = eventData.pointerDrag.GetComponent<DiagnosisController>();
            Diagnosis.CheckDrop(gameObject);
        }
        else if(eventData.pointerDrag.GetComponent<SurgeryController>())
        {
            SurgeryController Surgery = eventData.pointerDrag.GetComponent<SurgeryController>();
            Surgery.CheckDrop(gameObject);
        }
        else if(eventData.pointerDrag.GetComponent<RecoveryController>())
        {
            RecoveryController Recovery = eventData.pointerDrag.GetComponent<RecoveryController>();
            Recovery.CheckDrop(gameObject);
        }
        if(d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
    }
}
