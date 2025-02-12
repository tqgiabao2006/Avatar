using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{   [SerializeField]GameObject ghostPrefab;
GameManager _gameManager;

   
    public void CreateGhost(PlayerController player, Vector3 postion)
    {
       GameObject ghost = ObjectPooling.Instant.GetObj(ghostPrefab.gameObject);
        SpriteRenderer ghostSprite = ghost.GetComponent<SpriteRenderer>();
        SpriteRenderer playerSprite = player._spriteRenderer;
        ghostSprite.sprite = playerSprite.sprite;
        ghostSprite.transform.localScale = new Vector3(playerSprite.transform.localScale.x,1,1);
        ghost.transform.position = postion;
        ghost.SetActive(true);
    }
}
