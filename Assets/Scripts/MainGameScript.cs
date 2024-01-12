using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Random = System.Random;

public class MainGameScript : MonoBehaviour
{
    [SerializeField] private Text numberOfIdle, numberOfHarvesting, numberOfMining, numberOfKnights, numberOfPaladins, numberOfEnemies, nextWaveNumber, nextWaveInTime, amountOfWheat, amountOfGold;
    [SerializeField] private Button trainPaladin, summonPeasant, summonKnight, healTheWoundedButton;

    public GameObject assignmentBlock, mainScript, loseScreen, winScreen, nextWaveComplex, healTheWounded;

    private int harvesting = 1;
    private int idle, mining, knights, paladins, paladinsLeft, thisTimeEnemies, nextTimeEnemies, wounded;

    float peasantTimer, knightTimer, paladinTimer, harvestingTimer, miningTimer, nextAttackTimer, woundedTimer, feedingTimer;
    public Image peasantButtonBgImage, knightButtonBgImage, paladinButtonBgImage, woundedButtonImage, breadImage, goldImage;
    int timer, randEnemies;

    private int wheatInStorage, goldInStorage, waveNumber;

    private AudioSource battleHorn;

    Random rnd = new Random();
    void Start()
    {
        battleHorn = GetComponent<AudioSource>();
        numberOfHarvesting.text = "harvesting: " + harvesting.ToString();
        harvestingTimer = 4;
        feedingTimer = 7;
        nextAttackTimer = 60;
        nextTimeEnemies = 1;
        waveNumber = 1;
        numberOfEnemies.text = "Next time there will be " + nextTimeEnemies + " enemies";
        nextWaveNumber.text = $"Wave number {waveNumber} will come in";
        numberOfKnights.text = "Knights: 0";
        numberOfPaladins.text = "Paladins: 0";
        amountOfGold.text = "There is no gold left!";
        amountOfWheat.text = "There is no wheat left!";
    }

    void Update()
    {
        if (wheatInStorage == 0) amountOfWheat.text = "x 0";
        if (goldInStorage == 0) amountOfGold.text = "x 0";
        if (knights == 0) numberOfKnights.text = "You don't have any knights";
        if (paladins == 0) numberOfPaladins.text = "You don't have any paladins";

        nextAttackTimer -= Time.deltaTime;
        timer = Convert.ToInt32(nextAttackTimer);
        nextWaveInTime.text = timer.ToString();

        randEnemies = rnd.Next(1, 4);


        if (nextAttackTimer < 25)
        {
            nextWaveComplex.SetActive(true);
        }

        if (knights > 0 && wheatInStorage > 0 && goldInStorage > 0 && paladinTimer <= 0) trainPaladin.interactable = true;              // If there're neither knights nor wheat
        else trainPaladin.interactable = false;                                                                                         // nor gold, Train-a-paladin button is non-interactable

        if (wheatInStorage > 0 && peasantTimer <= 0) summonPeasant.interactable = true;                                                 // If there's no wheat there will be no peasants))
        else summonPeasant.interactable = false;

        if (wheatInStorage >= 2 && knightTimer <= 0) summonKnight.interactable = true;                                                   // If there's not enough wheat, no knights cam be trained
        else summonKnight.interactable = false;

        if (peasantTimer > 0)                                                                                                            
        {
            peasantTimer -= Time.deltaTime;
            peasantButtonBgImage.fillAmount += Time.deltaTime * 0.33f;
            if (peasantTimer <= 0)
            {
                peasantTimer = 0;
                peasantButtonBgImage.fillAmount = 1;
                SummonPeasant();
            }
        }

        if (knightTimer > 0)                                                                                        
        {
            knightTimer -= Time.deltaTime;
            knightButtonBgImage.fillAmount += Time.deltaTime * 0.2f;
            if (knightTimer <= 0)
            {
                knightTimer = 0;
                knightButtonBgImage.fillAmount = 1;
                SummonKnight();
            }
        }

        if (paladinTimer > 0)                                                                                       
        {
            paladinTimer -= Time.deltaTime;
            paladinButtonBgImage.fillAmount += Time.deltaTime * 0.2f;
            if (paladinTimer <= 0)
            {
                paladinTimer = 0;
                TrainPaladin();
            }
        }

        if (harvestingTimer > 0)                                    // Harvesting timer is launched with the game
        {
            harvestingTimer -= Time.deltaTime;
            breadImage.fillAmount += Time.deltaTime * 0.25f;
            if (harvestingTimer <= 0)
            {
                wheatInStorage = wheatInStorage + 2 * harvesting;
                amountOfWheat.text = "x " + wheatInStorage.ToString();
                breadImage.fillAmount = 0;
                harvestingTimer = 4;

            }

        }
        if (feedingTimer > 0)
        {
            feedingTimer -= Time.deltaTime;
            if (feedingTimer <= 0)
            {
                wheatInStorage = wheatInStorage - mining - harvesting - idle - paladins * 3 - knights * 2;
                amountOfWheat.text = "x " + wheatInStorage.ToString();
                feedingTimer = 7;
            }
        }
        

        if (miningTimer > 0)                        // Mining timer is only launched when at least one peasant is sent mining
        {
            miningTimer -= Time.deltaTime;
            goldImage.fillAmount += Time.deltaTime * 0.077f;
            if (miningTimer <= 0)
            {
                goldInStorage = goldInStorage + 1 * mining;
                amountOfGold.text = "x " + goldInStorage.ToString();
                goldImage.fillAmount = 0;
                miningTimer = 13;
            }
        }

        if (wounded > 0)
        {
            healTheWounded.SetActive(true);
            woundedButtonImage.fillAmount = 1;
            if (wheatInStorage > 0) healTheWoundedButton.interactable = true;
            else healTheWoundedButton.interactable = false;
        }

        if (nextAttackTimer <= 0)                           // Major attack cycle
        {
            battleHorn.Play();
            thisTimeEnemies = nextTimeEnemies;
            if (paladins * 3 >= thisTimeEnemies)                    // Checking battle conditions. Paladins charge first. If the don't die out completely,
            {                                                       // a button to heal the wounded will appear
                wounded = (paladins * 3 - thisTimeEnemies) % 3;
                paladins = ((paladins * 3 - thisTimeEnemies) - wounded) / 3;
                numberOfPaladins.text = "Paladins: " + paladins.ToString();
            }
            else
            {
                knights = knights + paladins * 3 - thisTimeEnemies;
                if (knights < 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);       // Game over conditions
                    numberOfKnights.text = "You don't have any knights";
                    numberOfPaladins.text = "You don't have any paladins";
                }
                else
                {
                    paladins = 0;
                    numberOfPaladins.text = "You don't have any paladins";
                    numberOfKnights.text = "Knights: " + knights.ToString();
                }                
            }
            nextAttackTimer = 25;
            nextTimeEnemies = Convert.ToInt32(nextTimeEnemies + randEnemies);
            waveNumber++;
            nextWaveNumber.text = $"Wave number {waveNumber} will come in";
            numberOfEnemies.text = "Next time there will be " + nextTimeEnemies + " enemies";
        }

        if (woundedTimer > 0)
        {
            woundedTimer -= Time.deltaTime;
            woundedButtonImage.fillAmount -= Time.deltaTime * 0.33f;
                if (woundedTimer <= 0)
            {
                paladins++;
                numberOfPaladins.text = $"Paladins: {paladins}";
                healTheWounded.SetActive(false);
            }
        }

        if (idle > 0) assignmentBlock.SetActive(true);          // Idle peasants assignment block
        else
        {
            assignmentBlock.SetActive(false);
            numberOfIdle.text = "idle 0";
        }

        if (goldInStorage >= 500)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void SetPeasantTimer()           // Setting timer for a peasant
    {
        peasantButtonBgImage.fillAmount = 0;
        peasantTimer = 3;
        wheatInStorage--;
        amountOfWheat.text = "x " + wheatInStorage.ToString();
    }

    public void SetKnightTimer()            // Setting timer for a knight
    {
        knightButtonBgImage.fillAmount = 0;
        knightTimer = 5;
        wheatInStorage = wheatInStorage - 2;
        amountOfWheat.text = "x " + wheatInStorage.ToString();
    }

    public void SetPaladinTimer()           // Setting timer for a paladin
    {
        paladinButtonBgImage.fillAmount = 0;
        paladinTimer = 5;
        knights--;
        numberOfKnights.text = "Knights: " + knights.ToString();
        wheatInStorage--;
        goldInStorage--;
        amountOfWheat.text = "x " + wheatInStorage.ToString();
        amountOfGold.text = "x " + goldInStorage.ToString();
    }
    private void SummonPeasant()
    {
        idle++;
        numberOfIdle.text = "idle: " + idle.ToString();
        summonPeasant.interactable = true;
    }

    private void SummonKnight()
    {
        knights++;
        numberOfKnights.text = ("Knights: " + knights.ToString());
    }

    private void TrainPaladin()
    {
        paladins++;
        numberOfPaladins.text = "Paladins: " + paladins.ToString();
        numberOfKnights.text = "Knights: " + knights.ToString();
    }

    public void SendHimHarvesting()
    {
        idle--;
        numberOfIdle.text = "idle " + idle;
        harvesting++;
        numberOfHarvesting.text = "harvesting " + harvesting.ToString();
    }

    public void SendHimMining()
    {
        idle--;
        numberOfIdle.text = "idle " + idle;
        mining++;
        numberOfMining.text = "mining " + mining.ToString();
        if (mining == 1) miningTimer = 13;

    }
    public void HealTheWounded()
    {
        woundedTimer = 3;
        healTheWoundedButton.interactable = false;        
        wheatInStorage = wheatInStorage - (3 - wounded);
        amountOfWheat.text = "x " + wheatInStorage.ToString();
        wounded = 0;
    }

    public void SetPause()
    {
       Time.timeScale = 0;
    }
}
