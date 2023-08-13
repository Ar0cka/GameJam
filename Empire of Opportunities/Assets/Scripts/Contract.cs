using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Contract : MonoBehaviour
{
    [SerializeField] private GameObject _contract;
    private float disableTimer = 3f;
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
