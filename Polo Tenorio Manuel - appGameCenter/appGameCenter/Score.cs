using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Score
{

    String nickName;
    int point;

    public Score()
    {
        this.nickName = "Unknow";
        this.point = 0;
    }

    public Score(String nickName, int point)
    {
        this.nickName = nickName;
        if (point < 0)
        {
            this.point = 0;
        }
        else
        {
            this.point = point;
        }
        
    }

    public String GetNickName()
    {
        return nickName;
    }

    //public void SetNickName(String nickName)
    //{
    //    this.nickName = nickName;
    //}

    public int GetPoint()
    {
        return point;
    }

    public void SetPoint(int point)
    {
        if (point < 0)
        {
            this.point = 0;
        }
        else
        {
            this.point = point;
        }
    }

    //ToString clase score
    public override string ToString()
    {
        String score = GetNickName() + " - " + GetPoint();

        return score;
    }
}
