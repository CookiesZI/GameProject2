using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Sword swordAttack;
    private Bow bowAttack;
    [SerializeField] int currentExp, maxExp, currentLevel;

    private void Start()
    {
        swordAttack = GetComponent<Sword>();
        bowAttack = GetComponent<Bow>();
    }

    private void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bowAttack.PerformRangedAttack();
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized;
        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    private void OnEnable()
    {
        expmanager.instance.OnExpChange += HandleExpChange;
    }

    private void OnDisable()
    {
        expmanager.instance.OnExpChange -= HandleExpChange;
    }

    private void HandleExpChange(int newExp)
    {
        currentExp += newExp;
        if(currentExp >= maxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentExp = 0;
        maxExp += 100;
    }
}
