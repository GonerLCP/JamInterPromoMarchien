using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Parent : MonoBehaviour
{
    public string nomDuTruc;
    float timer = 0f;
    float delai = 3f;
    int i = 0;
    public GameObject Objet1;
    public GameObject Objet2;
    public GameObject Objet3;
    public GameObject Objet4;
    public GameObject Objet5;
    public Slider SliderReference;
    public TextMeshProUGUI ScoreReference;

    GameObject Temp;
    GameObject Temp2;
    Vector2 vecteur;
    Quaternion Rota;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Tapis")
        {
            nomDuTruc = collision.name;
        }
    }

    private void Update()
    {
        GameObject[] Objects = { Objet1, Objet2, Objet3, Objet4, Objet5 };
        timer += Time.deltaTime;
        if (timer >= delai)
        {
            Temp2 = Objects[Random.Range(0,5)];
            vecteur = new Vector2(Random.Range(-21, -23), Random.Range(3.0f, 0.6f));
            Temp = Instantiate(Temp2, new Vector3(Random.Range(-21, -23), Random.Range(3.0f, 0.6f), -1), Rota);
            Temp.transform.parent = GameObject.Find(nomDuTruc).GetComponent<Transform>();
            Temp.GetComponent<FixedJoint2D>().connectedBody = GameObject.Find(nomDuTruc).GetComponent<Rigidbody2D>();
            Temp.GetComponent<ToolTip>().doggo = GameObject.Find("Doggo").GetComponent<Player>();
            Temp.GetComponent<ToolTip>().slider = SliderReference;
            Temp.GetComponent<ToolTip>().drogue = (Random.value > 0.5f);
            Temp.GetComponent<ToolTip>().scoring = ScoreReference;
            timer = 0f;
            i++;
            //print(i);
            if (i == 5 && delai != 1)
            {
                delai = delai - 1;
                i = 0;
            }
        }
    }
}