using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(WeatherAPI))]
public class WeatherAPIEditor : Editor
{
    private WeatherAPI weatherAPI;
    private bool mostrarPaisActual = false;

    private void OnEnable()
    {
        weatherAPI = (WeatherAPI)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Mostrar los campos generales
        EditorGUILayout.PropertyField(serializedObject.FindProperty("volumeProfile"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("bloomTransitionSpeed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("colorAdjustSpeed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("paisUI"));

        // Mostrar los detalles del pa�s actual en un foldout
        mostrarPaisActual = EditorGUILayout.Foldout(mostrarPaisActual, "Pa�s Actual");
        if (mostrarPaisActual)
        {
            if (weatherAPI.paises.Length > 0 && weatherAPI.paisActual < weatherAPI.paises.Length)
            {
                var paisActual = weatherAPI.paises[weatherAPI.paisActual];
                EditorGUILayout.LabelField($"Nombre: {paisActual.country}");
                EditorGUILayout.LabelField($"Ciudad: {paisActual.city}");
                EditorGUILayout.LabelField($"Latitud: {paisActual.latitud}");
                EditorGUILayout.LabelField($"Longitud: {paisActual.longitude}");
                EditorGUILayout.LabelField($"Temperatura: {paisActual.actualTemp} �c");
                EditorGUILayout.LabelField($"Velocidad del viento: {paisActual.windSpeed}");
            }
            else
            {
                EditorGUILayout.LabelField("No hay pa�ses configurados.");
            }
        }
              
        serializedObject.ApplyModifiedProperties();
    }
}
#endif