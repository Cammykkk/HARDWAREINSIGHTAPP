using Unity.VectorGraphics;
using UnityEngine;

/// <summary>
/// Este script se pone en los BOTONES de la interfaz (UI).
/// Cuando el jugador hace clic en un boton, este script le dice
/// al SceneController que cargue la escena que corresponde.
/// 
/// Es como un "mensajero" entre el boton y el SceneController.
/// </summary>
public class ButtonSceneController : MonoBehaviour
{
    /// <summary>
    /// Guarda una referencia al SceneController para poder llamar sus metodos.
    /// </summary>
    private SceneController sceneController;

    /// <summary>
    /// Start se ejecuta automaticamente cuando el juego empieza.
    /// Aqui buscamos el SceneController que ya deberia existir en la escena.
    /// </summary>
    void Start()
    {
        sceneController = SceneController.instance;
        if (sceneController == null)
        {
            Debug.Log("No se encontro scene controller");

        }
    }

    /// <summary>
    /// Cambia a una escena usando su NOMBRE.
    /// Este metodo se conecta desde el boton en el Inspector de Unity.
    /// Carga INSTANTANEA (sin barra de carga).
    /// </summary>
    /// <param name="sceneName">Nombre de la escena (ej: "SegundaEscena")</param>
    public void ChangeScene(string sceneName)
    {
        if(sceneController != null)
        sceneController.LoadScene(sceneName);
    }

    /// <summary>
    /// Cambia a una escena por nombre, pero CON barra de carga.
    /// La escena se carga mientras ves el progreso.
    /// </summary>
    /// <param name="sceneName">Nombre de la escena a cargar</param>
    public void ChangeSceneAsync(string sceneName)
    {
        if(sceneController != null)
        sceneController.LoadSceneAsync(sceneName);
    }

    /// <summary>
    /// Cambia a una escena usando su NUMERO en vez del nombre.
    /// Carga INSTANTANEA.
    /// </summary>
    /// <param name="sceneIndex">Numero de la escena (0, 1, 2...)</param>
    public void ChangeSceneIndex(int sceneIndex)
    {
        if(sceneController != null)
        sceneController.LoadSceneIndex(sceneIndex);
    }

    /// <summary>
    /// Cambia a una escena por numero, pero CON barra de carga.
    /// </summary>
    /// <param name="sceneIndex">Numero de la escena en Build Settings</param>
    public void ChangeSceneAsyncIndex(int sceneIndex)
    {
        if(sceneController != null)
        sceneController.LoadSceneAsyncIndex(sceneIndex);
    }
}
