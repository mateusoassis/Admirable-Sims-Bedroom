using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class WoodHandler : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject woodBar;

    [SerializeField] private int startingWood;
    public int totalWood;
    [SerializeField] private TextMeshProUGUI woodTextHolder;

    [SerializeField] private string woodLootName;
    [SerializeField] private string[] woodChopName;
    [SerializeField] private float woodChopInterval;
    private float chopIntervalTimer;
    [SerializeField] private float woodChopDuration;

    [SerializeField] private Image sprite;

    public bool pressing;

    void Awake()
    {
        pressing = false;
    }

    void Start()
    {
        totalWood = startingWood;
        UpdateWood(0);
        woodBar.SetActive(false);
    }

    void Update()
    {
        if(pressing == true)
        {
            sprite.fillAmount += Time.deltaTime/woodChopDuration;
            chopIntervalTimer += Time.deltaTime;
            if(chopIntervalTimer > woodChopInterval)
            {
                GameObject.Find("SoundManager").GetComponent<AudioClipManager>().PlayOneShot(woodChopName[UnityEngine.Random.Range(0, woodChopName.Length)]);
                chopIntervalTimer = 0;
            }
        }
        else
        {
            chopIntervalTimer = 0;
            sprite.fillAmount = 0;
            woodBar.SetActive(false);
        }
        if(sprite.fillAmount == 1)
        {
            GameObject.Find("SoundManager").GetComponent<AudioClipManager>().PlayOneShot(woodLootName);
            sprite.fillAmount = 0;
            chopIntervalTimer = 0;
            UpdateWood(1);
        }
    }

    public void UpdateWood(int sum)
    {
        totalWood += sum;
        woodTextHolder.text = totalWood.ToString() + " Wood";
    }

    public void ActivateObject()
    {
        woodBar.SetActive(true);
    }
}
