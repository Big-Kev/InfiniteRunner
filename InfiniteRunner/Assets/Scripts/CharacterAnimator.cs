using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    SideScrollerPlayer player;

    public SpriteRenderer spriteRender;
    public Sprite[] sprites;
    public Sprite stand;
    public Sprite slash;
    public Sprite slide;
    public float AnimSpeed = 0.2f;
    float timer;
    int runIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<SideScrollerPlayer>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > AnimSpeed)
        {
            timer = 0;
            runIndex++;
            if(runIndex > sprites.Length -1)
            {
                runIndex = 0;
            }
        }

        switch (player.m_movetype)
        {
            case SideScrollerPlayer.MoveType.Run:
                spriteRender.sprite = sprites[runIndex];
                break;
            case SideScrollerPlayer.MoveType.Slide:
                spriteRender.sprite = slide;
                break;
            case SideScrollerPlayer.MoveType.Jump:
                spriteRender.sprite = sprites[0];
                break;
        }
    }
}
