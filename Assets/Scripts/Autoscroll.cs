using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Autoscroll : MonoBehaviour
{
    float speed = 2.0f;
    float textPosBegin =-1635.0f;
    float boundaryTextEnd = 2580.0f;

    RectTransform myGorectTransform;
    [SerializeField]
    TextMeshProUGUI mainText;

    
    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoscrollText());

    }

    IEnumerator AutoscrollText()
{
    while(myGorectTransform.localPosition.y< boundaryTextEnd)
    {
        myGorectTransform.Translate(Vector3.up * speed * Time.deltaTime);
        yield return null;
    }
}
    
}
