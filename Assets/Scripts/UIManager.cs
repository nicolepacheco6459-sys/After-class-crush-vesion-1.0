using UnityEngine;
using TMPro;  //Para que reconozca las opciones te TextMessagePro - Se usa siempre que hay texto

public class UIManager : MonoBehaviour
{
    //Objetos y funciones definidas para usarse
    public GameObject inventario;
    public GameObject pauseMenu;

    public TMP_Text Objeto1CountText;
    public TMP_Text Objeto2CountText;
    public TMP_Text Objeto3CountText;
    public TMP_Text AfinidadText;
    public static UIManager Instance { get; private set; }  


    //Hacer que los objetos desaparezcan o se agreguen a el inventario
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Abrir y cerrar inventario
    public void OpenorCloseInventario()
    {
        inventario.SetActive(!inventario.activeSelf);
    }

    public void UpdateObjeto1(int value)
    {
        Objeto1CountText.text = value.ToString();
    }
    public void UpdateObjeto2(int value)
    {
        Objeto2CountText.text = value.ToString();
    }
    public void UpdateObjeto3(int value)
    {
        Objeto3CountText.text = value.ToString();
    }

    //Actualizar la afinidad del jugador
    public void UpdateAfinidad(int AValue)
    {
        AfinidadText.text = AValue.ToString();
    }

    //Pausar y resumir el juego
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


}
