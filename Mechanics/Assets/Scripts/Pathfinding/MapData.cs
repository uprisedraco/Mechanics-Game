﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MapData : MonoBehaviour
{
    public int width = 10;
    public int heigth = 5;

    public TextAsset textAsset;
    public Texture2D textureMap;

    public string resoursePath = "Pathfinding";

    public List<string> GetMapFromTextFile(TextAsset tAsset)
    {
        List<string> lines = new List<string>();

        if(tAsset != null)
        {
            string textData = tAsset.text;
            string[] delimiters = { "\r\n", "\n" };
            lines.AddRange(textData.Split(delimiters, System.StringSplitOptions.None));
            lines.Reverse();
        }
        else
        {
            Debug.LogWarning("MapData: GetMapFromText Error invalid tAsset");
        }

        return lines;
    }

    public List<string> GetMapFromTextFile()
    {
        return GetMapFromTextFile(textAsset);
    }

    public List<string> GetMapFromTexture(Texture2D texture)
    {
        List<string> lines = new List<string>();

        if (texture != null)
        {

            for (int y = 0; y < texture.height; y++)
            {
                string newLine = "";

                for (int x = 0; x < texture.width; x++)
                {
                    if (texture.GetPixel(x, y) == Color.black)
                    {
                        newLine += '1';
                    }
                    else if (texture.GetPixel(x, y) == Color.white)
                    {
                        newLine += '0';
                    }
                    else
                    {
                        newLine += ' ';
                    }
                }

                lines.Add(newLine);
            }
        }
        else
        {
            Debug.LogWarning("MapData: GetMapFromTexture Error invalid texture");
        }

        return lines;
    }

    public void SetDimensions(List<string> textLines)
    {
        heigth = textLines.Count;
        foreach(string line in textLines)
        {
            if(line.Length > width)
            {
                width = line.Length;
            }
        }
    }

    public int[,] MakeMap()
    {
        List<string> lines = new List<string>();

        if(textureMap != null)
        {
            lines = GetMapFromTexture(textureMap);
        }
        else
        {
            lines = GetMapFromTextFile();
        }

        SetDimensions(lines);

        int[,] map = new int[width, heigth];

        for(int y = 0; y < heigth; y++)
        {
            for(int x = 0; x < width; x++)
            {
                if(lines[y].Length > x)
                {
                    map[x, y] = (int)Char.GetNumericValue(lines[y][x]);
                }

            }
        }

        return map;
    }
}
