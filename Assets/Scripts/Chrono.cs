using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Premier_texte = null;
    public GameObject Deuxieme_texte = null;
    public GameObject Troisieme_texte = null;

    public void Start()
    {
        Premier_texte.SetActive(false);
        Deuxieme_texte.SetActive(false);
        Troisieme_texte.SetActive(false);

        //ShowCharacters();

        StartCoroutine(WaitBeforeShow());
    }

 

    private IEnumerator WaitBeforeShow()
    {
       

        yield return new WaitForSeconds(5);

        Premier_texte.SetActive(true);

        yield return new WaitForSeconds(30);
        Premier_texte.SetActive(false);


        yield return new WaitForSeconds(35);
        Deuxieme_texte.SetActive(true);

        yield return new WaitForSeconds(50);
        Deuxieme_texte.SetActive(false);


        yield return new WaitForSeconds(55);
        Troisieme_texte.SetActive(true);

        yield return new WaitForSeconds(80);
        Troisieme_texte.SetActive(false);
    }

}