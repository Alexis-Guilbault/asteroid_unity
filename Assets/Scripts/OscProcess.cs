using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OscProcess : MonoBehaviour
{
    public OSCReceiver oscReceiver;
    public OSCTransmitter oscTransmitter;

    public AsteroidDodger asteroidDodger;

    
    public int betaInMin = 0;
    public int betaInMax = 1023;
    public float betaOutMin = 0.0f;
    public float betaOutMax = 1.0f;


    void Start()
    {
        oscReceiver.Bind("/photo", traiterMessagePhoto);
    }

    void Update()
    {
        if ( asteroidDodger.GetShipIsVisible() ) {
            var oscMessage = new OSCMessage("/lumiere"); 
            oscMessage.AddValue(OSCValue.Int(1) );
            oscTransmitter.Send(oscMessage );
        } else {
            var oscMessage = new OSCMessage("/lumiere"); 
            oscMessage.AddValue(OSCValue.Int(0));
            oscTransmitter.Send(oscMessage);
        }
    }

    void traiterMessagePhoto(OSCMessage message)
    {
        // Traiter un entier et l’appliquer à une propriété (flux continu)

        // Récupérer la valeur du premier argument en taant qu’entier :
        int valeur = message.Values[0].IntValue;

        Debug.Log("Reçu : " + message.Address + " " + valeur);

        // Ajustement de la valeur
        float ajustee = (
            ((float)valeur - betaInMin) / (betaInMax - betaInMin) * (betaOutMax - betaOutMin) + betaOutMin
        );
        
        asteroidDodger.SetShipY(ajustee);
    }
}
