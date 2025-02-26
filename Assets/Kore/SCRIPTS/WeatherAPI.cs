using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using SimpleJSON;
using System;
using Unity.VisualScripting;

public class WeatherAPI : MonoBehaviour
{
    [SerializeField] WeatherData data;
    private static readonly float latitud = 37.566f;
    private static readonly float longitud = -126.9784f;
    private static readonly string apiKey = "f53e6727021a710a90fa9b47b3fd459b";
    private string json;
    private string url;
    [SerializeField] private VolumeProfile volumeProfile;
    [SerializeField] private float bloomTransitionSpeed;
    private Color actualColor;


    void Start()
    {
        url = $"https://api.openweathermap.org/data/3.0/onecall?lat={latitud}&lon={longitud}&appid={apiKey}&lang=sp&units=metric";
    }

    IEnumerator RetrieveWeatherData()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(5);

            UnityWebRequest request = new UnityWebRequest(url);
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }

            else
            {
                Debug.Log(request.downloadHandler.text);

                json = request.downloadHandler.text;

                DecodeJson();

                yield return new WaitForSeconds(2);

                actualColor = GetColorByTemp();

                StartCoroutine(BloomColorTransition());


            }
        }
    }
       

    #region Bloom

    private void DecodeJson()
    {
        var weatherJson = JSON.Parse(json);
        data.timeZone = weatherJson["timezone"].Value;
        data.actualTemp = float.Parse(weatherJson["current"]["weather"][0]["description"].Value);
        data.description = weatherJson["current"]["weather"][0]["description"].Value;
        data.windSpeed = float.Parse(weatherJson["current"]["wind_speed"].Value);
    }

    private IEnumerator BloomColorTransition()
    {
        yield return new WaitUntil(() => TransitionColor() == actualColor);
        Debug.Log("Color Cambiado");
    }

    private Color TransitionColor()
    {
        volumeProfile.TryGet(out Bloom bloom);
        bloom.tint.value = Color.Lerp(bloom.tint.value, actualColor, bloomTransitionSpeed * Time.deltaTime);
        return bloom.tint.value;
    }
    #endregion

    private Color GetColorByTemp()
    {
        switch (data.actualTemp)
        {
            case var color when data.actualTemp <= 8:
                {
                    actualColor = Color.cyan;
                    return actualColor;
                }

            case var color when data.actualTemp > 8 && data.actualTemp < 24:
                {
                    actualColor = new Color(176, 154, 0);
                    return actualColor;
                }

            case var color when data.actualTemp > 24 && data.actualTemp < 45:
                {
                    actualColor = new Color(255, 179, 0);
                    return actualColor;
                }

            case var color when data.actualTemp >= 45:
                {
                    actualColor = Color.red;
                    return actualColor;
                }

            default:
                {
                    return actualColor;
                }
        }
    }

}
