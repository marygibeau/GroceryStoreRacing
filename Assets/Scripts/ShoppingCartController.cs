using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartController : MonoBehaviour
{
    // Movement Variables
    float movementOffset = 3;
    public Animator animator;
    int direction; // -1 = right, 1 = left, 0 = center
    bool canMoveRight;
    bool canMoveLeft;

    // Audio variables
    public AudioClip rolling;
    public AudioClip crash;
    AudioSource audio;
    float audioFadeFactor;

    // Translation 
    public SceneMovementManager sceneMover;
    public ChoiceMenu choiceMenu;
    public FinalScoreHandler finalScore;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        animator = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        PlayRolling();
        canMoveLeft = true;
        canMoveRight = true;
        sceneMover = (SceneMovementManager)GameObject.FindObjectOfType(typeof(SceneMovementManager));
        choiceMenu = (ChoiceMenu)GameObject.FindObjectOfType(typeof(ChoiceMenu));
        finalScore = (FinalScoreHandler)GameObject.FindObjectOfType(typeof(FinalScoreHandler));
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && canMoveRight)
        {
            MoveRight();
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && canMoveLeft)
        {
            MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            MoveForward();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            sceneMover.IncreaseSpeed();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            sceneMover.DecreaseSpeed();
        }
        transform.Translate(direction * movementOffset * Time.deltaTime, 0, 0, Space.World);

        if (GetIsPaused())
        {
            if (audioFadeFactor == 0)
            {
                audioFadeFactor = 1f - (10f * Time.deltaTime);
            }
            if (audio.volume < 0.01)
            {
                audio.Pause();
            }
            else
            {
                Debug.Log(audio.volume);
                audio.volume *= audioFadeFactor;
                audio.pitch *= audioFadeFactor;
            }
        }
        if (!GetIsPaused() && !audio.isPlaying)
        {
            Debug.Log("Resuming rolling");
            audioFadeFactor = 0;
            PlayRolling();
        }
    }

    bool GetIsPaused(){
        return (choiceMenu.GetIsPaused() || finalScore.GetIsPaused());
    }

    void MoveRight()
    {
        if (direction == 0 && Time.timeScale != 0f)
        {
            direction = -1;
            animator.Play("CartRotateFromCenterToRight");
        }
    }

    void MoveLeft()
    {
        if (direction == 0 && Time.timeScale != 0f)
        {
            direction = 1;
            animator.Play("CartRotateFromCenterToLeft");
        }
    }

    void MoveForward()
    {
        if (direction == -1 && Time.timeScale != 0f)
        {
            animator.Play("CartRotateFromRightToCenter");
        }
        else if (direction == 1 && Time.timeScale != 0f)
        {
            animator.Play("CartRotateFromLeftToCenter");
        }
        direction = 0;
    }

    IEnumerator PlayCrash()
    {
        audio.loop = false;
        audio.volume = 1.0f;
        audio.clip = crash;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        PlayRolling();
    }

    void PlayRolling()
    {
        audio.loop = true;
        audio.volume = 0.25f;
        audio.pitch = 1f;
        audio.clip = rolling;
        audio.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter " + other.gameObject.name);
        if (other.gameObject.tag == "Wall")
        {
            if (other.gameObject.name == "Shelf1")
            {
                canMoveLeft = false;
            }
            else
            {
                canMoveRight = false;
            }
            StartCoroutine(PlayCrash());
            MoveForward();
        }
        if (other.gameObject.tag == "TranslationTrigger")
        {
            choiceMenu.Pause();
            sceneMover.IncreaseSpeedByAmount(2);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.gameObject.tag == "Wall")
        {
            if (other.gameObject.name == "Shelf1")
            {
                canMoveLeft = true;
            }
            else
            {
                canMoveRight = true;
            }
        }
    }
}
