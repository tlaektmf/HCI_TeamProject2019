using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float attacktime = 1f;
    bool grounded = true;
    Animator animator;
    Rigidbody2D rigid;
    BoxCollider2D col;
    float actionDelay = 0.3f;
    float delay = 0.0f;

    Vector2 v1, v2;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();

        v1 = new Vector2(0, 0);
        v2 = new Vector2(0.5f, 0);
        
        SoundManager.Instance.PlayMusicWithPath("audio/game2/game2bgm");
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        attacktime += Time.deltaTime;
        
        if(attacktime > 0.08f && attacktime < 0.25f)
        {
            col.offset = v2;
        }
        else
        {
            col.offset = v1;
        }

        if (Mathf.Abs(rigid.velocity.y) <= 0 && !grounded) Ground();

        if(transform.position.y < -12.8f)
        {
            Die();
        }

        if (transform.position.x < -1.8)
        {
            transform.Translate(Time.deltaTime, 0, 0);
        }
    }

    void Die()
    {
        if (Game2Controller.state == 1) return;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        Game2Controller.state = 1;
        Game2Controller.speed = 0;
        rigid.bodyType = RigidbodyType2D.Static;
        animator.Play("dead");
        SoundManager.Instance.Stop();
        SoundManager.Instance.PlayEffectWithPath("audio/common/gameover_tetris");
    }

    public void Jump(float thurst)
    {
        if (Game2Controller.state > 0) return;
        if (!grounded || delay>0) return;
        grounded = false;
        animator.Play("jumping");
        rigid.velocity = new Vector2(0, thurst);
        delay = actionDelay;

        SoundManager.Instance.PlayEffectWithPath("audio/game2/jumping");
    }

    public void Punch()
    {
        if (Game2Controller.state > 0) return;
        if (!grounded || delay > 0) return;
        animator.Play("attack");
        delay = actionDelay;
        attacktime = 0;

    }

    void Ground()
    {
        if(!grounded)
            animator.Play("walking");
        grounded = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
        if (tag == "enemy")
        {
            if (attacktime > 0.08f && attacktime < 0.25f)
            {
                Enemy e = (Enemy)other.gameObject.GetComponent<Enemy>();
                SoundManager.Instance.PlayEffectWithPath("audio/game2/punch");
                e.Die();
            }
            else
            {
                Die();
            }
        }
        if (tag == "ground")
        {
            Ground();
        }
    }
}
