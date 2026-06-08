using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla la barra de carga que aparece en pantalla
/// mientras una escena nueva se esta cargando.
/// 
/// Tiene dos imagenes: el fondo de la barra y el relleno
/// que se va llenando de izquierda a derecha.
/// </summary>
public class LoadingBarController : MonoBehaviour
{
    /// <summary>
    /// La parte de la barra que se va LLENANDO (la barra de progreso).
    /// Se conecta desde el Inspector de Unity arrastrando la imagen.
    /// </summary>
    public Image loadingBarFill;

    /// <summary>
    /// El FONDO de la barra (detras del relleno).
    /// Se conecta desde el Inspector.
    /// </summary>
    public Image loadingBarBackground;

    /// <summary>
    /// Llena la barra de carga con un porcentaje.
    /// "progressPercentage" va de 0 a 1.
    /// 0 = vacio, 0.5 = mitad, 1 = completo.
    /// </summary>
    /// <param name="progressPercentage">El progreso de 0 a 1</param>
    public void FillProgressBar(float progressPercentage)
    {
        loadingBarFill.fillAmount = progressPercentage;
    }

    /// <summary>
    /// Muestra u oculta el fondo de la barra de carga.
    /// A veces queremos esconder la barra cuando no se esta usando.
    /// </summary>
    /// <param name="isActive">true = mostrar, false = ocultar</param>
    public void loadingBarBackgroundVisible(bool isActive)
    {
        loadingBarBackground.gameObject.SetActive(isActive);
    }

}
