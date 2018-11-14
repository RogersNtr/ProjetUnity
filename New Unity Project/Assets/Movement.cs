using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{

    public Transform cible1;//glisser l'objet player1
    public Transform cible2;//glisser l'objet player2
    private Transform maTransform;
    private NavMeshAgent agent;
    public bool poursuite;
    public float pdv = 10f;
    public bool pause;


    void Awake()
    {
        maTransform = transform;
    }

    // Use this for initialization
    void Start()
    {

        //Initialisation du script NavMeshAgen qui se trouve sur le même objet que ce script
        agent = GetComponent<NavMeshAgent>();

        pause = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (poursuite)
        {
            mouvement();
        }

        if (poursuite == false && pause == true)
        {
            miseEnAttente();
        }

    }


    private void mouvement()
    {
        //Si la variable "vieActuelle" est supérieur a 0
        if (pdv > 0)
        {
            Debug.DrawLine(cible1.transform.position, maTransform.position, Color.blue);
            agent.destination = cible1.position;//le squelette se dirige vers le joueur
        }
    }

    //L'ennemi reste a sa position actuelle
    private void miseEnAttente()
    {
        print("NE BOUGE PLUS !!");
        agent.destination = transform.position;
    }


}
