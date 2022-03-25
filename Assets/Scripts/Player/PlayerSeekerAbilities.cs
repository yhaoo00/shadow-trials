using UnityEngine;
using UnityEngine.UI;

public class PlayerSeekerAbilities : MonoBehaviour
{
    //Ability 1
    public Image abilityImage1;
    public Image durationTint1;
    public GameObject durationImg1;
    private float enemySpeed;
    public float slowEnemyCooldownTimer = 10f;
    public float slowEnemyTimer = 4f;
    private float slowEnemyDuration;
    private float slowEnemyCountdownTimer;
    private float nextSlowEnemyTimer = 0f;
    bool isAbility1Cooldown = false;

    //Ability 2
    public Image abilityImage2;
    public Image durationTint2;
    public GameObject durationImg2;
    private float increaseViewDistance;
    public float increaseViewDistanceCooldownTimer = 15f;
    public float increaseViewDistanceTimer = 5f;
    private float increaseViewDistanceDuration;
    private float increaseViewDistanceCountdownTimer;
    private float nextIncreaseViewDistanceTimer = 0f;
    bool isAbility2Cooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Ability 1
        enemySpeed = 550f;
        slowEnemyCountdownTimer = slowEnemyCooldownTimer;
        abilityImage1.fillAmount = 0;
        durationTint1.fillAmount = 0;
        durationImg1.gameObject.SetActive(false);

        //Ability 2
        increaseViewDistance = 7f;
        increaseViewDistanceCountdownTimer = increaseViewDistanceCooldownTimer;
        abilityImage2.fillAmount = 0;
        durationTint2.fillAmount = 0;
        durationImg2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Ability 1
        Ability1();

        //Ability 2
        Ability2();
    }

    public void Ability1()
    {
        if (Time.time > nextSlowEnemyTimer)
        {
            isAbility1Cooldown = false;
            //Debug.Log("ability 1 is ready");
            slowEnemyCountdownTimer = slowEnemyCooldownTimer;

            if (Input.GetKeyDown(KeyCode.Q) && isAbility1Cooldown == false)
            {
                SoundManager.PlaySound("slow");
                isAbility1Cooldown = true;
                abilityImage1.fillAmount = 1;
                durationTint1.fillAmount = 1;
                durationImg1.gameObject.SetActive(true);
                EnemyHide.Instance.speed = 300f;
                //Debug.Log("ability 1 pressed, start cooldown.");
                nextSlowEnemyTimer = Time.time + slowEnemyCooldownTimer;
                slowEnemyDuration = Time.time + slowEnemyTimer;
            }
        }
        else
        {
            if (isAbility1Cooldown)
            {
                abilityImage1.fillAmount -= 1 / slowEnemyCooldownTimer * Time.deltaTime;

                if (abilityImage1.fillAmount <= 0)
                {
                    abilityImage1.fillAmount = 0;
                }
            }

            durationTint1.fillAmount -= 1 / slowEnemyTimer * Time.deltaTime;

            if (durationTint1.fillAmount <= 0)
            {
                durationTint1.fillAmount = 0;
                durationImg1.gameObject.SetActive(false);
            }

            slowEnemyCountdownTimer -= Time.deltaTime;
            //Debug.Log("Ability 1 Cooldown: " + Mathf.Round(slowEnemyCountdownTimer));

            if (Time.time > slowEnemyDuration)
            {
                //Debug.Log("slow duration end");
                EnemyHide.Instance.speed = enemySpeed;
            }
        }
    }

    public void Ability2()
    {
        if (Time.time > nextIncreaseViewDistanceTimer)
        {
            isAbility2Cooldown = false;
            //Debug.Log("ability 2 is ready");
            increaseViewDistanceCountdownTimer = increaseViewDistanceCooldownTimer;

            if (Input.GetKeyDown(KeyCode.E) && isAbility2Cooldown == false)
            {
                SoundManager.PlaySound("truesight");
                isAbility2Cooldown = true;
                abilityImage2.fillAmount = 1;
                durationTint2.fillAmount = 1;
                durationImg2.gameObject.SetActive(true);
                PlayerMovement.Instance.viewDistance = 9f;
                //Debug.Log("ability 2 pressed, start cooldown");
                nextIncreaseViewDistanceTimer = Time.time + increaseViewDistanceCooldownTimer;
                increaseViewDistanceDuration = Time.time + increaseViewDistanceTimer;
            }
        }
        else
        {
            if (isAbility2Cooldown)
            {
                abilityImage2.fillAmount -= 1 / increaseViewDistanceCooldownTimer * Time.deltaTime;

                if (abilityImage2.fillAmount <= 0)
                {
                    abilityImage2.fillAmount = 0;
                }
            }

            durationTint2.fillAmount -= 1 / increaseViewDistanceTimer * Time.deltaTime;

            if (durationTint2.fillAmount <= 0)
            {
                durationTint2.fillAmount = 0;
                durationImg2.gameObject.SetActive(false);
            }

            increaseViewDistanceCountdownTimer -= Time.deltaTime;
            //Debug.Log("Ability 2 Cooldown: " + Mathf.Round(increaseViewDistanceCountdownTimer));

            if (Time.time > increaseViewDistanceDuration)
            {
                //Debug.Log("increase view distance duration end");
                PlayerMovement.Instance.viewDistance = increaseViewDistance;
            }
        }
    }
}
