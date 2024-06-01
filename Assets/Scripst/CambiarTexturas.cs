using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarTextura : MonoBehaviour
{
    [System.Serializable]
    public class ObjectMaterials
    {
        public GameObject objeto;
        public List<Material> materiales;
        public Button botonCambiar; // Ahora solo tenemos un botón
        private int currentIndex = 0;

        public void Inicializar()
        {
            if (botonCambiar != null)
            {
                botonCambiar.onClick.AddListener(CambiarMaterial); // El mismo botón para cambiar materiales
            }
        }

        // Método para cambiar al siguiente material
        public void CambiarMaterial()
        {
            if (materiales.Count == 0)
            {
                Debug.LogWarning("La lista de materiales está vacía.");
                return;
            }

            currentIndex = (currentIndex + 1) % materiales.Count;
            ActualizarMaterial();
        }

        // Método para actualizar el material del objeto
        private void ActualizarMaterial()
        {
            if (objeto != null)
            {
                objeto.GetComponent<Renderer>().material = materiales[currentIndex];
            }
        }
    }

    [SerializeField]
    private List<ObjectMaterials> listaDeObjetos = new List<ObjectMaterials>();

    void Start()
    {
        foreach (var obj in listaDeObjetos)
        {
            obj.Inicializar();
        }
    }

    // Método público para cambiar al siguiente material de un objeto específico
    public void CambiarMaterial(int objectIndex)
    {
        if (objectIndex >= 0 && objectIndex < listaDeObjetos.Count)
        {
            listaDeObjetos[objectIndex].CambiarMaterial();
        }
        else
        {
            Debug.LogWarning("Índice de objeto fuera de rango.");
        }
    }
}
