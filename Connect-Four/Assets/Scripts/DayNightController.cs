/*
 * Author: AshenTales
 * Day/Night controller script for GGJ jam project Voided(warranty)
 * Uses set limits to select an amount of customers and creates a timer to track the current time.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    // init vars
    [SerializeField] private int[] dayCustomerMinMax = { 3, 5 };
    [SerializeField] private int[] nightCustomerMinMax = { 1, 2 };
    [SerializeField] private float timePerDay = 8f; // Time per day in game hours
    [SerializeField] private float timePerNight = 6f; // Time per night in game hours
    [SerializeField] private float timePerHour = 60f; // Time in seconds per game hour

    public int currentDayCustomers = 0;
    public int currentNightCustomers = 0;
    public float currentTime = 0f;
    public int currentHour = 0;
    public bool day = true;

    void Start()
    {
        GenerateCustomerCounts(dayCustomerMinMax[0], dayCustomerMinMax[1], nightCustomerMinMax[0], nightCustomerMinMax[1]);
    }

    void Update()
    {
        KeepTime();
    }

    void GenerateCustomerCounts(int dayMin, int dayMax, int nightMin, int nightMax) // Generate customer counts based on given min and max values
    {
        currentDayCustomers = Random.Range(dayMin, dayMax);
        currentNightCustomers = Random.Range(nightMin, nightMax);
    }

    void KeepTime() //Keeps time and will eventualy swap between day and night.
    {
        currentTime += Time.deltaTime;
        currentHour = ((int)currentTime) / ((int)timePerHour);
        if (day)
        {
            if (currentTime >= timePerDay * timePerHour)
            {
                //Insert day to night transitional code here
                currentTime = 0f;
                day = false;
            }
        }
        else if (!day)
        {
            if (currentTime >= timePerNight * timePerHour)
            {
                //Insert night to day transitional code here
                currentTime = 0f;
                day = true;
            }
        }
    }
}
