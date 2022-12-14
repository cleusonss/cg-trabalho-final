using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour {

    public AudioSource death; //som de derrota
    public GameObject target; //jogador ou referencia para ele
    NavMeshAgent agent;       //referencia para o fantasma navmeshagent component
    public ChangeScore changeScore; //importado para fazer a checagem do game over


    void Start() {
        death = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
            target = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update() {
        //atualiza a localizacao do target
        if(!changeScore.IsGameOver())
            agent.SetDestination(target.transform.position);
        else
        {
            agent.isStopped = true;
        }
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "player"){
            death.Play();
            //Destroy(collision.gameObject);
            Invoke("GoToMenu", 3f);
            target.SetActive(false);
        }
    }

    void GoToMenu() {
        SceneManager.LoadScene("menu");
    }
    
}
