using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SignalSent : ScriptableObject
{
    public List<SignalReceiver> listeners = new List<SignalReceiver>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalReceiver receiver)
    {
        listeners.Add(receiver);
    }

    public void DeregisterListener(SignalReceiver receiver)
    {
        listeners.Remove(receiver);
    }
}
