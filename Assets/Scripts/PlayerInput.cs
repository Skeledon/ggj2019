using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerInput : MonoBehaviour
{
    public PaguroMovement myPaguroMovement;
    public PaguroAttack myPaguroAttack;
    public AnemoneAttack myAnemoneAttack;
    public int PlayerID;

    private Player myRewiredPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myRewiredPlayer = ReInput.players.GetPlayer(PlayerID);
    }

    // Update is called once per frame
    void Update()
    {
        if(myRewiredPlayer.GetButtonDown("Jump"))
            myPaguroMovement.Jump(1);
        if (myRewiredPlayer.GetButtonDown("Dive"))
            myPaguroMovement.Jump(-1);
        if (myRewiredPlayer.GetButtonDown("Attack"))
            myPaguroAttack.Attack();
        if (myRewiredPlayer.GetButtonDown("Eat"))
            myAnemoneAttack.Attack();
        if (myRewiredPlayer.GetButtonUp("Jump"))
            myPaguroMovement.InterruptJump();


        myPaguroMovement.Move(myRewiredPlayer.GetAxis("Horizontal"));
    }
}
