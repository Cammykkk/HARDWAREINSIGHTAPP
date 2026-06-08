using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Controla la carga de escenas en el juego.
/// Este script se encarga de cambiar de una escena a otra,
/// ya sea de forma instantanea o con una barra de carga.
/// </summary>
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// "instance" guarda una copia de este mismo script para poder usarlo
    /// desde cualquier otro script sin necesidad de buscarlo.
    /// Esto se llama "Singleton" y es muy comun en Unity.
    /// </summary>
    public static SceneController instance;
    //Este orden no debe cambiarse para instanciar.

    /// <summary>
    /// Guarda una referencia al script de la barra de carga
    /// para poder actualizar el progreso mientras se carga una escena.
    /// </summary>
    private LoadingBarController loadingBarController;

    /// <summary>
    /// Awake se ejecuta automaticamente cuando el juego empieza,
    /// incluso antes que Start(). Sirve para preparar cosas.
    /// 
    /// Aqui nos aseguramos de que solo exista UN SceneController
    /// en todo el juego. Si ya hay uno, el nuevo se destruye.
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Cambia a una escena de forma INSTANTANEA (sin barra de carga).
    /// Se usa cuando la escena es chica y carga rapido.
    /// </summary>
    /// <param name="sceneName">El nombre exacto de la escena a cargar (ej: "SegundaEscena")</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Cambia a una escena de forma ASINCRONICA (con barra de carga).
    /// La escena se carga en segundo plano mientras la barra se llena.
    /// </summary>
    /// <param name="sceneName">El nombre exacto de la escena a cargar</param>
    public void LoadSceneAsync(string sceneName)
    {
        if(loadingBarController == null)
        {
            loadingBarController = FindObjectOfType<LoadingBarController>();
        }
        StartCoroutine(LoadAsyncScene(sceneName));
    }

    /// <summary>
    /// Cambia a una escena usando su NUMERO en vez de su nombre.
    /// El numero se asigna en File > Build Settings.
    /// Carga INSTANTANEA (sin barra de carga).
    /// </summary>
    /// <param name="sceneIndex">El numero de la escena en Build Settings (0, 1, 2, etc.)</param>
    public void LoadSceneIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Cambia a una escena por su numero, pero ASINCRONICO (con barra de carga).
    /// </summary>
    /// <param name="sceneIndex">El numero de la escena en Build Settings</param>
    public void LoadSceneAsyncIndex(int sceneIndex)
    {
        if(loadingBarController == null)
        {
            loadingBarController = FindObjectOfType<LoadingBarController>();
        }
        StartCoroutine(LoadAsyncSceneIndex(sceneIndex));
    }

    /// <summary>
    /// CORRUTINA: carga una escena por nombre mientras la barra se va llenando.
    /// Una corrutina es como una funcion que puede pausarse y seguir despues.
    /// "yield return null" significa "espera un frame y continua".
    /// </summary>
    /// <param name="sceneName">El nombre de la escena a cargar</param>
    private IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        while (operation.isDone == false)
        {
            Debug.Log(operation.progress);
            
            loadingBarController.FillProgressBar(operation.progress);
            
            yield return null; 
        }

        loadingBarController = null;
    }

    /// <summary>
    /// CORRUTINA: carga una escena por numero mientras la barra se va llenando.
    /// Es lo mismo que el de arriba pero usando el indice en vez del nombre.
    /// </summary>
    /// <param name="sceneIndex">El numero de la escena en Build Settings</param>
    private IEnumerator LoadAsyncSceneIndex(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        while (operation.isDone == false)
        {
            Debug.Log(operation.progress);
            
            loadingBarController.FillProgressBar(operation.progress);
            
            yield return null; 
        }

        loadingBarController = null;
    }
}