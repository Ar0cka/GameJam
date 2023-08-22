using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Contract : MonoBehaviour
{
    private float disableTimer = 2f;
    public void StartDisplay()
    {
        StartCoroutine(DisplayContractAndHide());
    }

    private IEnumerator DisplayContractAndHide()
    {
        gameObject.SetActive(true);

        yield return new WaitForSeconds(disableTimer);

        gameObject.SetActive(false);
    }
}
