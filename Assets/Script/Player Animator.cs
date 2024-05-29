using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    private Animator animotor;

    [SerializeField] private Player player;

    private void Awake()
    {
        animotor = GetComponent<Animator>();
        animotor.SetBool(IS_WALKING, player.IsWalking());
    }

    private void Update()
    {
        animotor.SetBool(IS_WALKING, player.IsWalking());
    }

}
