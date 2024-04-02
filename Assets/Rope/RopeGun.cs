using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{

    public Hook Hook;
    public Transform Spawn;
    public float Speed;
    public SpringJoint SpringJoint;

    public Transform RopeStart;

    private float _ropeLength;

    public RopeState CurrentRopeState;

    public RopeRenderer RopeRenderer;

    public PlayerMove PlayerMove;

    public float MaxLength = 10f;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetKeyDown(KeyCode.LeftAlt)))
        {
            Shot();
        }

        if (CurrentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(Hook.transform.position, RopeStart.position);
            if (distance > MaxLength)
            {
                Hook.gameObject.SetActive(false);
                CurrentRopeState = RopeState.Disabled;
                RopeRenderer.Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (CurrentRopeState == RopeState.Active)
            {
                if (PlayerMove.Grounded == false)
                {
                  PlayerMove.PlayerJump();
                }

            }
            DestroyRope();
        }

        if (CurrentRopeState == RopeState.Fly || CurrentRopeState == RopeState.Active)
        {
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _ropeLength);
        }
    }

    private void Shot()
    {

        _ropeLength = 1f;

        Hook.gameObject.SetActive(true);

        if (SpringJoint)
        {
            Destroy(SpringJoint);
            RopeRenderer.Hide();
        }

        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.Rigidbody.velocity = Spawn.forward * Speed;
        CurrentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (SpringJoint == null)
        {
            SpringJoint = gameObject.AddComponent<SpringJoint>();

            SpringJoint.anchor = RopeStart.localPosition;
            SpringJoint.connectedBody = Hook.Rigidbody;
            SpringJoint.autoConfigureConnectedAnchor = false;
            SpringJoint.connectedAnchor = Vector3.zero;
            SpringJoint.spring = 100f;
            SpringJoint.damper = 5f;


            _ropeLength = Vector3.Distance(Hook.transform.position, RopeStart.position);
            SpringJoint.maxDistance = _ropeLength;

            CurrentRopeState = RopeState.Active;

        }

    }

    public void DestroySpring()
    {
        if (SpringJoint)
        {
            Destroy(SpringJoint);
            CurrentRopeState = RopeState.Disabled;
            Hook.gameObject.SetActive(false);
        }
    }

    public void DestroyRope()
    {
        DestroySpring();
        RopeRenderer.Hide();
    }
}
