using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour{
    public Texture2D texture;
    public ObjectInfo[] objectInfo;
    public Vector3 offset = Vector3.zero;

    private Vector2 pos;

    void Start(){
        this.ReadTexture();
    }

    private void ReadTexture()
    {
        for (int x = 0; x < this.texture.width; x++)
        {
            for (int y = 0; y < this.texture.height; y++)
            {
                this.pos = new Vector2(x, y);
                this.getColor(x, y);
        }
        }
    }

    private void getColor(int x, int y)
    {
        Color c = this.texture.GetPixel(x, y);
        if(c.a < 2)
            return;

        this.CreateObject(c);
    }

    private void CreateObject(Color c)
    {
        foreach (ObjectInfo info in objectInfo){
            if(info.color == c){
                Instantiate(info.prefab, new Vector3(this.pos.x, 0, this.pos.y)+ offset, Quaternion.identity, this.transform);
            }
        }
    }
}
