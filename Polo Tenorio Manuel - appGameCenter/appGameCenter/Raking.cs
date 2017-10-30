using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ranking
{
    String name;
    List<Score> scores;

    //Constructor vacio ranking
    public Ranking()
    {
        this.name = "Unknow";
        this.scores = null;
    }

    //Constructor con parametros ranking
    public Ranking(String name, List<Score> scores)
    {
        this.name = name;
        this.scores = scores;
    }

    //Getters y setters
    public String GetName()
    {
        return name;
    }

    public void SetName(String name)
    {
        this.name = name;
    }

    public List<Score> GetScores()
    {
        return scores;
    }

    //ToString ranking
    public override string ToString()
    {

        String ranking = GetName();
        String scorePlayer = "";
        int i = 1;

        foreach(Score score in scores)
        {
            scorePlayer += i + ". "  + score.GetNickName() + " - " + score.GetPoint() + "\n";
            i++;
        }

        return ranking + "\n" + scorePlayer;
    }
}
