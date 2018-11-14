using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour
{

    private Transform robot1;
    private Transform robot2;

    /***Variable Detection***/
    public float distanceDetect = 4.0F;
    public bool detecter;
    //Une fois sorti de la zone de detection l'ennemi arrête de poursuivre le joueur apres le temps donné par cette variable "decroche" 
    public float decroche = 3f;
    private Movement sComportement;



    // Use this for initialization
    void Start()
    {

        sComportement = GetComponent<Movement>();
        robot1= sComportement.cible1;
        robot2 = sComportement.cible2;

    }

    // Update is called once per frame
    void Update()
    {

        CalculDist();

    }

    //Verifie la position du joueur
    private void CalculDist()
    {
        //Le joueur est a ditance
        if (robot1 && robot2)
        {
            float sqrLen1 = (robot1.position - transform.position).sqrMagnitude;
            float sqrLen2 = (robot2.position - transform.position).sqrMagnitude;
            if (sqrLen1 < distanceDetect * distanceDetect)
            {
                detecter = true;
                ConditionComportement();//Appel de methode
                if (IsInvoking("Timer"))//Annule l'invocation au cas d'une invocation déjà effectué
                {
                    CancelInvoke("Timer");
                }
            }
            //Le joueur n'est plus a distance
            if (sqrLen1 > distanceDetect && detecter)
            {
                detecter = false;
                PlusAdistance();
            }

        }
    }


    private void ConditionComportement()
    {
        if (detecter)
        {
            //BonneDist();
            sComportement.pause = false;
            sComportement.poursuite = true;

        }

    }

    //Active la poursuite dans le script "comportement"
    private void BonneDist()
    {
        sComportement.poursuite = true;
    }

    //Appel la methode coroutine "Timer"
    private void PlusAdistance()
    {
        Invoke("finPoursuite", decroche);//Permet d'utilisé un temps donné avant d'arreter la poursuite et appel la méthode "finPoursuite"
    }

    //Met fin a la poursuite du joueur
    private void FinPoursuite()
    {
        sComportement.pause = true;
        sComportement.poursuite = false;
        print("DESACTIVE LA POURSUITE !!");

    }

}
