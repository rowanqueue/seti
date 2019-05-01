using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glyph : MonoBehaviour
{
    public string word;
    public List<Sprite> sprites;
    LineRenderer lr;
    List<Vector2Int> directions;
    List<Vector2> points;

    GameObject spritePrefab;
    // Start is called before the first frame update
    void Start()
    {
        spritePrefab = transform.GetChild(0).gameObject;
        points = new List<Vector2>();
        lr = GetComponent<LineRenderer>();
        directions = new List<Vector2Int>
        {
            Vector2Int.up,Vector2Int.right,Vector2Int.down,Vector2Int.left
        };
        directions = new List<Vector2Int>
        {
            new Vector2Int(1,1),new Vector2Int(1,-1),new Vector2Int(-1,-1),new Vector2Int(-1,1)
        };
        DrawWord();
    }
    void DrawWord()
    {
        List<int> nums = new List<int>();
        foreach(char c in word)
        {
            nums.Add(c-96);
        }
        int d = 1;
        Vector2Int pos = Vector2Int.zero;
        points.Add(pos);
        lr.positionCount = 1;
        lr.SetPosition(lr.positionCount-1, (Vector3Int)pos);
        foreach (int i in nums)
        {
            int iD = i / 9;
            int iS = ((i - 1) % 9) / 3;
            int iE = i % 3;
            switch (iD)
            {
                case 0:
                    d -= 1;
                    break;
                case 1:
                    d += 1;
                    break;
            }
            if (d == -1) { d = 3; } else if (d == 4) { d = 0; }
            Vector2Int move = directions[d];
            int which = 0;
            switch (iE)
            {
                case 0:
                    which = 1;
                    break;
                case 1:
                    which = 2;
                    break;
            }
            if (which == 1)
            {
                int newD = d - 1;
                if (newD == -1) { newD = 3; }
                Vector2 fakePos = pos + ((Vector2)move * 0.5f)+((Vector2)directions[newD]*0.25f);
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, fakePos);
            }
            if (which == 2)
            {
                int newD = d + 1;
                if (newD == 4) { newD = 0; }
                Vector2 fakePos = pos + ((Vector2)move * 0.5f) + ((Vector2)directions[newD] * 0.25f);
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, fakePos);
            }
            pos += move;
            lr.positionCount += 1;
            lr.SetPosition(lr.positionCount-1, (Vector3Int)pos);
            points.Add(pos);
            GameObject obj = Instantiate(spritePrefab,(Vector3Int)pos,Quaternion.identity, transform);
            obj.GetComponent<SpriteRenderer>().sprite = sprites[iS];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
