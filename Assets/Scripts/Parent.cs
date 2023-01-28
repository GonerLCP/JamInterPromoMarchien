using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            vecteur = new Vector2(Random.Range(-11, -13), Random.Range(0.8f, -0.8f));
            Temp = Instantiate(Temp2, new Vector3(Random.Range(-11, -13), Random.Range(0.8f, -0.8f), -1), Rota);
            Temp.transform.parent = GameObject.Find(nomDuTruc).GetComponent<Transform>();
            Temp.GetComponent<FixedJoint2D>().connectedBody = GameObject.Find(nomDuTruc).GetComponent<Rigidbody2D>();
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