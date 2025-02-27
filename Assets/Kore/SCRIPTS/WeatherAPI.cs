using System.Collections;
using SimpleJSON;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class WeatherAPI : MonoBehaviour
{
    [SerializeField] public WeatherData[] paises = new WeatherData[10];
    [SerializeField] public int paisActual = 0;
    private static readonly string apiKey = "f53e6727021a710a90fa9b47b3fd459b";
    private string json;
    private string url;
    [SerializeField] private VolumeProfile volumeProfile;
    [SerializeField] private float bloomTransitionSpeed;
    [SerializeField] private float colorAdjustSpeed;
    [SerializeField] TextMeshProUGUI paisUI;
    private Color actualColor;
    private float intensity;


    public void Start()
    {
        url = $"https://api.openweathermap.org/data/3.0/onecall?lat={paises[paisActual].latitud}&lon={paises[paisActual].longitude}&appid={apiKey}&lang=sp&units=metric";
        StartCoroutine(RetrieveWeatherData());
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

                intensity = GetIntensityByWindSpeed();

                StartCoroutine(VigneteByWindSpeed());

                StartCoroutine(BloomColorTransition());

            }
            yield return new WaitForSeconds(90);

            if (paisActual < paises.Length - 1)
            {
                paisActual++;
                url = $"https://api.openweathermap.org/data/3.0/onecall?lat={paises[paisActual].latitud}&lon={paises[paisActual].longitude}&appid={apiKey}&lang=sp&units=metric";
            }

            else
            {
                paisActual = 0; // Reiniciar el ciclo
                url = $"https://api.openweathermap.org/data/3.0/onecall?lat={paises[paisActual].latitud}&lon={paises[paisActual].longitude}&appid={apiKey}&lang=sp&units=metric";
            }

        }
    }


    #region Bloom

    private void DecodeJson()
    {
        var weatherJson = JSON.Parse(json);
        paises[paisActual].timeZone = weatherJson["timezone"].Value;
        paises[paisActual].actualTemp = float.Parse(weatherJson["current"]["temp"].Value);
        paises[paisActual].description = weatherJson["current"]["weather"][0]["description"].Value;
        paises[paisActual].windSpeed = float.Parse(weatherJson["current"]["wind_speed"].Value);
    }

    private IEnumerator BloomColorTransition()
    {
        yield return new WaitUntil(() => TransitionColor() == actualColor);
        Debug.Log("Color Cambiado");
    }

    private IEnumerator VigneteByWindSpeed()
    {
        yield return new WaitUntil(() => TransitionIntensity() == intensity);
    }

    private float TransitionIntensity()
    {
        volumeProfile.TryGet(out Vignette vignette);
        vignette.intensity.value = Mathf.MoveTowards(vignette.intensity.value, intensity, bloomTransitionSpeed * Time.deltaTime);
        return vignette.intensity.value;
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
        switch (paises[paisActual].actualTemp)
        {
            case var color when paises[paisActual].actualTemp <= 8:
                {
                    actualColor = Color.cyan;
                    return actualColor;
                }

            case var color when paises[paisActual].actualTemp > 8 && paises[paisActual].actualTemp < 24:
                {
                    actualColor = new Color(176, 154, 0);
                    return actualColor;
                }

            case var color when paises[paisActual].actualTemp > 24 && paises[paisActual].actualTemp < 45:
                {
                    actualColor = new Color(255, 179, 0);
                    return actualColor;
                }

            case var color when paises[paisActual].actualTemp >= 45:
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

    private float GetIntensityByWindSpeed()
    {
        switch (paises[paisActual].windSpeed)
        {
            case var color when paises[paisActual].windSpeed <= 1:
                {
                    intensity = .1f;
                    return intensity;
                }

            case var color when paises[paisActual].windSpeed > 1 && paises[paisActual].windSpeed < 2:
                {
                    intensity = .4f;
                    return intensity;
                }

            case var color when paises[paisActual].windSpeed > 2 && paises[paisActual].windSpeed < 4:
                {
                    intensity = .75f;
                    return intensity;
                }

            case var color when paises[paisActual].windSpeed >= 4:
                {
                    intensity = 1f;
                    return intensity;
                }

            default:
                {
                    return intensity;
                }
        }
    }

    private void Update()
    {
        paisUI.text = "Clima de " + paises[paisActual].city;
    }

}
