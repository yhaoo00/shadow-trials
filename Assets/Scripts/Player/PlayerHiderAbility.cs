using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHiderAbility : MonoBehaviour
{
    //Ability 1
    public Image abilityImage1;
    public Image durationTint1;
    public GameObject durationImg1;
    private float speed;
    public float hasteCooldownTimer = 10f;
    public float hasteTimer = 5f;
    private float hasteDuration;
    private float hasteCountdownTimer;
    private float nextHasteTimer = 0f;
    bool isAbility1Cooldown = false;

    //Ability 2
    public Image abilityImage2;
    public Image durationTint2;
    public GameObject durationImg2;
    private float enemySpeed;
    public float bindEnemyCooldownTimer = 15f;
    public float bindEnemyTimer = 3.5f;
    private float bindEnemyDuration;
    private float bindEnemyCountdownTimer;
    private float nextBindEnemyTimer = 0f;
    bool isAbility2Cooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        //ability 1
        speed = 5f;
        hasteCountdownTimer = hasteCooldownTimer;
        abilityImage1.fillAmount = 0;
        durationTint1.fillAmount = 0;
        durationImg1.gameObject.SetActive(false);

        //ability 2
        enemySpeed = 400f;
        bindEnemyCountdownTimer = bindEnemyCooldownTimer;
        abilityImage2.fillAmount = 0;
        durationTint2.fillAmount = 0;
        durationImg2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Ability 1
        if (Time.time > nextHasteTimer)
        {
            isAbility1Cooldown = false;
            //Debug.Log("ability 1 is ready");
            hasteCountdownTimer = hasteCooldownTimer;

            if (Input.GetKeyDown(KeyCode.Q) && isAbility1Cooldown == false)
            {
                SoundManager.PlaySound("haste");
                isAbility1Cooldown = true;
                abilityImage1.fillAmount = 1;
                durationTint1.fillAmount = 1;
                durationImg1.gameObject.SetActive(true);
                PlayerMovement.Instance.moveSpeed += 5;
                //Debug.Log("ability 1 pressed, start cooldown.");
                nextHasteTimer = Time.time + hasteCooldownTimer;
                hasteDuration = Time.time + hasteTimer;
            }
        }
        else
        {
            if (isAbility1Cooldown)
            {
                abilityImage1.fillAmount -= 1 / hasteCooldownTimer * Time.deltaTime;

                if (abilityImage1.fillAmount <= 0)
                {
                    abilityImage1.fillAmount = 0;
                }
            }

            durationTint1.fillAmount -= 1 / hasteTimer * Time.deltaTime;

            if (durationTint1.fillAmount <= 0)
            {
                durationTint1.fillAmount = 0;
                durationImg1.gameObject.SetActive(false);
            }

            hasteCountdownTimer -= Time.deltaTime;
            //Debug.Log("Ability 1 Cooldown: " + Mathf.Round(hasteCountdownTimer));

            if (Time.time > hasteDuration)
            {
                //Debug.Log("haste duration end");
                PlayerMovement.Instance.moveSpeed = speed;
            }
        }
        
        //Ability 2
        if (Time.time > nextBindEnemyTimer)
        {
            isAbility2Cooldown = false;
            //Debug.Log("ability 2 is ready");
            bindEnemyCountdownTimer = bindEnemyCooldownTimer;
            if (Input.GetKeyDown(KeyCode.E) && isAbility2Cooldown == false)
            {
                SoundManager.PlaySound("bind");
                isAbility2Cooldown = true;
                abilityImage2.fillAmount = 1;
                durationTint2.fillAmount = 1;
                durationImg2.gameObject.SetActive(true);
                EnemyPathFinding.Instance.speed = 0;
                //Debug.Log("Ability 2 pressed");
                nextBindEnemyTimer = Time.time + bindEnemyCooldownTimer;
                bindEnemyDuration = Time.time + bindEnemyTimer;
            }
        }
        else
        {
            if (isAbility2Cooldown)
            {
                abilityImage2.fillAmount -= 1 / bindEnemyCooldownTimer * Time.deltaTime;

                if (abilityImage2.fillAmount <= 0)
                {
                    abilityImage2.fillAmount = 0;
                }
            }

            durationTint2.fillAmount -= 1 / bindEnemyTimer * Time.deltaTime;

            if (durationTint2.fillAmount <= 0)
            {
                durationTint2.fillAmount = 0;
                durationImg2.gameObject.SetActive(false);
            }

            bindEnemyCountdownTimer -= Time.deltaTime;
            //Debug.Log("Ability 2 cooldown: " + Mathf.Round(bindEnemyCountdownTimer));

            if (Time.time > bindEnemyDuration)
            {
                //Debug.Log("bind duration end");
                EnemyPathFinding.Instance.speed = enemySpeed;
            }
        }
    }
}
