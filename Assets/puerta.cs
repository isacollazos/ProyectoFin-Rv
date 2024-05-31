using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ManijaController : MonoBehaviour
{
    public Transform puerta; // Referencia a la puerta
    public float anguloApertura = 90f; // Ángulo de apertura de la puerta
    public float umbralRotacion = 30f; // Umbral de rotación para activar la puerta
    private bool puertaAbierta = false; // Estado de la puerta
    private XRGrabInteractable grabInteractable;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnSelectExited);

        // Guardar la posición y rotación inicial de la manija
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        // Restringir la posición de la manija para evitar que se separe
        transform.localPosition = initialPosition;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        if (DetectarRotacionManija())
        {
            if (!puertaAbierta)
            {
                AbrirPuerta();
            }
        }

        // Restaurar la rotación inicial de la manija después de soltarla
        transform.localRotation = initialRotation;
    }

    private bool DetectarRotacionManija()
    {
        // Supongamos que la manija gira alrededor del eje X local
        float anguloRotacion = transform.localEulerAngles.x;

        // Detectar si la manija ha sido girada más allá del umbral
        return anguloRotacion > umbralRotacion;
    }

    private void AbrirPuerta()
    {
        puerta.Rotate(Vector3.up, anguloApertura); // Gira la puerta alrededor del eje Y
        puertaAbierta = true;
    }
}