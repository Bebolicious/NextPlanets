using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public class WeatherSun : MonoBehaviour
{
        private const string API_KEY = "b45754393a85ca457643c4d0ba1951e4";
        private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes
        public GameObject SnowSystem;
        public string CityId; // Kiruna 605155 Göteborg 2711537
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
        bool snowing = (await GetWeather()).weather[0].main.Equals("Clear");
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
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?id=" + CityId + "&APPID=b45754393a85ca457643c4d0ba1951e4"));
        HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        return info;
    }
}

