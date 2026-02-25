using UnityEngine;

public class PlayerResourceCollector : MonoBehaviour
{
    private int Objeto1 = 0;
    private int Objeto2 = 0;
    private int Objeto3 = 0;

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.CompareTag("Objeto1"))
        {
            Destroy(collision.gameObject);
            Objeto1++;
            //Los debug están en comentarios porque ya se agregó al UIManager
            //Debug.Log("Tenemos: " +Objeto1+ " de objeto1");
            UIManager.Instance.UpdateObjeto1(Objeto1);
        }

        if (collision.gameObject.CompareTag("Objeto2"))
        {
            Destroy(collision.gameObject);
            Objeto2++;
            //Debug.Log("Conseguimos un: " +Objeto2);
            UIManager.Instance.UpdateObjeto2(Objeto2);
        }

        if (collision.gameObject.CompareTag("Objeto3"))
        {
            Destroy(collision.gameObject);
            Objeto3++;
           // Debug.Log("Tenemos: " +Objeto3+ " de Objeto3 ");
            UIManager.Instance.UpdateObjeto3(Objeto3);
        }
    }
}
