using SOEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JSButton : MonoBehaviour
{
    [SerializeField] private GameEventJSButton onButtonClick;
    [SerializeField] private Animation buttonAnimation;

    public Animation ButtonAnimation { get => buttonAnimation; }

    public void ActivateButton() {
        onButtonClick.Raise(this);
    }
}
