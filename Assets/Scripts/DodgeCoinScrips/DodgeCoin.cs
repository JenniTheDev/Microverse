using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCoin : MonoBehaviour {
    [SerializeField] private float startForce = 5.0f;
    [SerializeField] private float maxStartAngle;
    [SerializeField] private float maxMagnitude;
    [SerializeField] private float minMagnitude;

    private LayerMask wallLayer;
    private LayerMask player;
    private Rigidbody2D rBody;

    #region Properties

    #endregion

    #region MonoBehavior

    private void Awake() {
        rBody = GetComponent<Rigidbody2D>();
        wallLayer = LayerMask.NameToLayer("Wall");
        player = LayerMask.NameToLayer("Player");
    } 

    public void LaunchCoin() {
        
    }


    #endregion


}
