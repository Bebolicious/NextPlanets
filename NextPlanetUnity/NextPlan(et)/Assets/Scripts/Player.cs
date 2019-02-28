using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public Animator animator;
    private bool isAlive = true;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(x));
        animator.SetFloat("Speed2", Mathf.Abs(y));
        if (isAlive)
        {
            UpdateMotor(new Vector3(x, y, 0));
        }

    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive)
            return;

        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitpointChange();
    }
    protected override void Death()
    {
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
        isAlive = false;
    }

    public void OnLevelUp()
    {
        maxHitpoint++;
        hitPoint = maxHitpoint;
    }
    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }
    public void Heal(int healingAmount)
    {
        hitPoint += healingAmount;
        if (hitPoint > maxHitpoint)
            hitPoint = maxHitpoint;
        else
        {
            GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
            GameManager.instance.OnHitpointChange();

        }
       
    }
    public void Respawn()
    {
        Heal(maxHitpoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }

    //public void SwapSprite(int skinId)
    //{
    //    spriteRenderer.sprite = GameManager.instance.playerSprites[skinId];
    //}

}
