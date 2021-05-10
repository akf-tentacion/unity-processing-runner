using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unicessing;

public class Matrix_Texts : UGraphics
{
    [SerializeField] Color bgColor;
    [SerializeField] Color textColor;
    [SerializeField] int seedNum;
    // Start is called before the first frame update
    protected override void Setup()
    {

        background(bgColor);

    }
    protected override void Draw()
    {
        Vector3 pos = Vector3.zero;
        randomSeed(seedNum);
        for(int i = 0; i < 40; i++)
        {
            pushMatrix();
            pos.x = -100+10f * i;
            pos.y = 0;
            pos.z = 0;

            translate(pos);
            //rotate(radians(-90));
            //fill(textColor);
            //text(GetText());
            DrawVerticalText(GetText());
            popMatrix();
        }
    }

    void DrawVerticalText(string target)
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < target.Length; i++)
        {
            var c = target[i];
            pos.y = -10;
            translate(pos);
            fill(textColor);
            text(c.ToString());
        }
    }

    string GetText()
    {
        char[] textArray;
        int min = 0;
        int max = 10;
        int digits = 0;
        digits = (int)((random(0, 20) + random(0, 20) + random(0, 20)) / 3);
        textArray = new char[digits];
        if(digits == 0)
        {
            return " ";
        }
        for (int i = 0; i < digits; i++)
        {
            char c;
            var num = random(min, max);
            num--;
            if(num < 0)
            {
                c = ' ';
                textArray[i] = c;
                continue;
            }
            c = num.ToString()[0];
            textArray[i] = c;
        }
        return new string(textArray);
    }
}
