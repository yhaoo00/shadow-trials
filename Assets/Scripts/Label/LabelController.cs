using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelController : MonoBehaviour
{
    [SerializeField] private string placeName;
    [SerializeField] private GameObject text;
    [SerializeField] private Text placeText;

    private void Start()
    {
        StartCoroutine(LabelCoroutine());
    }

    private IEnumerator LabelCoroutine()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
