using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
public class WeatherCload : MonoBehaviour
{
    private const string API_KEY = "91dbd6f2dc24ab132e13385fdb3631a6";
    private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes
    public GameObject SnowSystem;
    public string CityId; // Göteborg = 2711537
    private float apiCheckCountdown = API_CHECK_MAXTIME;
    void Start()
    {
        CheckSnowStatus();
    }
    void Update()
    {


        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            CheckSnowStatus();
            apiCheckCountdown = API_CHECK_MAXTIME;
        }
    }
    public async void CheckSnowStatus()
    {
        bool snowing = (await GetWeather()).weather[0].main.Equals("Clouds");
        if (snowing)
        {
            SnowSystem.SetActive(true);
        }
        else
        {
            SnowSystem.SetActive(false);
        }
    }
    private async Task<WeatherInfo> GetWeather()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("api.openweathermap.org/data/2.5/weather?q=London"));
        HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        return info;
    }
}
