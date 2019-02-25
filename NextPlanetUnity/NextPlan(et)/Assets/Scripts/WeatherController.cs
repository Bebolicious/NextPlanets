using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
        private const string API_KEY = "91dbd6f2dc24ab132e13385fdb3631a6";
        private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes
        public GameObject SnowSystem;
        public GameObject CloadSystem;
        public GameObject RainSystem;
        public GameObject SunSystem; 


    public string CityId; // Kiruna 605155 Göteborg 2711537
        private float apiCheckCountdown = API_CHECK_MAXTIME;
        void Start()
        {
        CheckSnowStatusAsync();
        
        }
        void Update()
        {
     

            apiCheckCountdown -= Time.deltaTime;
            if (apiCheckCountdown <= 0)
            {
                CheckSnowStatusAsync(); 
                apiCheckCountdown = API_CHECK_MAXTIME;
            }
        }
    public async Task CheckSnowStatusAsync()
    {
        SnowSystem.SetActive(false);
        CloadSystem.SetActive(false);
        RainSystem.SetActive(false);
        SunSystem.SetActive(false);


        WeatherInfo x = await GetWeather();
        string typeOfWeather = x.weather[0].main;                
        if (typeOfWeather == "Thunderstorm" || typeOfWeather == "Drizzle" || typeOfWeather == "Rain")
        {
            RainSystem.SetActive(true);
        }
        else if (typeOfWeather == "Snow")
        {
            SnowSystem.SetActive(true);

        }
        else if (typeOfWeather == "Clouds")
        {
            CloadSystem.SetActive(true);
        }
        else if (typeOfWeather == "Clear")
        {
            SunSystem.SetActive(true);

        }
 
    }
    private async Task<WeatherInfo> GetWeather()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?id=" + CityId + "&APPID=" + API_KEY));

        WebResponse response = await request.GetResponseAsync();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        string weatherString = info.weather[0].main;       
        return info;

        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22"));
        //HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
        //StreamReader reader = new StreamReader(response.GetResponseStream());
        //string jsonResponse = reader.ReadToEnd();
        //WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
        //return info;
        //// http://api.openweathermap.org/data/2.5/weather?id=" + CityId + "&APPID=b45754393a85ca457643c4d0ba1951e4
    }
}

