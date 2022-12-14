using UnityEngine;

public class MovePacman : MonoBehaviour {

    public ChangeScore changeScore;
    public AudioSource source;
    public AudioClip eat_dot;
    public AudioClip eat_cherry;

    public float moveSpeed;
    //0:up, 1:right, 2:down, 3:left
    private int direction;
    private int pressedKey;
    private bool gameOver;

    void Start() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        source = audioSources[0];
        eat_dot = audioSources[0].clip;
        eat_cherry = audioSources[1].clip;
        moveSpeed = 3f;
        direction = 0;
        pressedKey = 0;
        gameOver = false;
    }

    void Update() {
        //transform.Translate(-1f * Time.deltaTime, 0f, 0f);

        //checa se jogador comeu todos os items
        if(changeScore.GetScore() >= 1420)
        {
            gameOver = true;
            moveSpeed = 0f;
            changeScore.Victory();

        }
        //seta pra cima ou W pressionado
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                direction = 0;
                moveSpeed = 3f;
            }
            //seta pra baixo ou S pressionado
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                direction = 2;
                moveSpeed = 3f;
            }
            //seta pra esquerda ou A pressionado
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                direction = 3;
                moveSpeed = 3f;
                pressedKey = 3;
            }
            //seta pra direita ou D pressionado
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                direction = 1;
                moveSpeed = 3f;
                pressedKey = 1;
            }

            //mudar direcao
            if (PlayerPrefs.GetInt("CameraPosition") == 0)
            {
                if (direction == 0)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                else if (direction == 1)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                }
                else if (direction == 2)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }
                else if (direction == 3)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
                }
            }
            else
            {
                float newAngle = -1f;
                if (pressedKey == 1)
                {
                    newAngle = transform.localRotation.eulerAngles.y + 90;
                    if (newAngle == 360f)
                        newAngle = 0;
                    transform.rotation = Quaternion.Euler(new Vector3(0, newAngle, 0));
                }
                else if (pressedKey == 3)
                {
                    newAngle = transform.localRotation.eulerAngles.y - 90;
                    if (newAngle == -360f)
                        newAngle = 0f;
                    transform.rotation = Quaternion.Euler(new Vector3(0, newAngle, 0));
                }

                if (newAngle == 0f)
                {
                    direction = 0;
                }
                else if (newAngle == 90f || newAngle == -270f)
                {
                    direction = 1;
                }
                else if (newAngle == 180f || newAngle == -180f)
                {
                    direction = 2;
                }
                else if (newAngle == 270f || newAngle == -90f)
                {
                    direction = 3;
                }
            }

            pressedKey = 0;
            transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        //colisao com parede
        if (other.gameObject.tag == "wall") {
            moveSpeed = 0f;
            transform.Translate(0f, 0f, -3f * Time.deltaTime);
        }
        //colisao com comida
        else if (other.gameObject.tag == "foodDot") {
            changeScore.SetScore(changeScore.GetScore() + 5);
            source.PlayOneShot(eat_dot);
            Destroy(other.gameObject);
        }
        //colisao com cereja
        else if (other.gameObject.tag == "cherry") {
            changeScore.SetScore(changeScore.GetScore() + 50);
            source.PlayOneShot(eat_cherry);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "pinkGhost" || other.gameObject.tag == "orangeGhost") {
            moveSpeed = 0f;
            gameOver = true;
            if(changeScore.GetScore() >= 1370)
            {
                changeScore.Victory();
            }
            else
            {
                changeScore.Defeated();
            }
        }
    }

}
