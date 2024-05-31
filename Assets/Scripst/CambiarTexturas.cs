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
        public Button botonSiguiente;
        public Button botonAnterior;
        private int currentIndex = 0;

        public void Inicializar()
        {
            if (botonSiguiente != null)
            {
                botonSiguiente.onClick.AddListener(CambiarAlSiguienteMaterial);
            }

            if (botonAnterior != null)
            {
                botonAnterior.onClick.AddListener(CambiarAlMaterialAnterior);
            }
        }

        // M�todo para cambiar al siguiente material
        public void CambiarAlSiguienteMaterial()
        {
            if (materiales.Count == 0)
            {
                Debug.LogWarning("La lista de materiales est� vac�a.");
                return;
            }

            currentIndex = (currentIndex + 1) % materiales.Count;
            ActualizarMaterial();
        }

        // M�todo para cambiar al material anterior
        public void CambiarAlMaterialAnterior()
        {
            if (materiales.Count == 0)
            {
                Debug.LogWarning("La lista de materiales est� vac�a.");
                return;
            }

            currentIndex = (currentIndex - 1 + materiales.Count) % materiales.Count;
            ActualizarMaterial();
        }

        // M�todo para actualizar el material del objeto
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

    // M�todo p�blico para cambiar al siguiente material de un objeto espec�fico
    public void CambiarAlSiguienteMaterial(int objectIndex)
    {
        if (objectIndex >= 0 && objectIndex < listaDeObjetos.Count)
        {
            listaDeObjetos[objectIndex].CambiarAlSiguienteMaterial();
        }
        else
        {
            Debug.LogWarning("�ndice de objeto fuera de rango.");
        }
    }

    // M�todo p�blico para cambiar al material anterior de un objeto espec�fico
    public void CambiarAlMaterialAnterior(int objectIndex)
    {
        if (objectIndex >= 0 && objectIndex < listaDeObjetos.Count)
        {
            listaDeObjetos[objectIndex].CambiarAlMaterialAnterior();
        }
        else
        {
            Debug.LogWarning("�ndice de objeto fuera de rango.");
        }
    }
}
