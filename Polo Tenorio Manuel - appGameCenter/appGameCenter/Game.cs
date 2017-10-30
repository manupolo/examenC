using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Enum tipo de juego
public enum Genre
{
    Unknow = 0,
    Action = 1,
    Strategy = 2,
    RPG = 3,
    Puzzles = 4,
    Adventure = 5,
    Simulation = 6,
    SurvivalHorror = 7,
    Sandbox = 8

}

//Enum plataformas
public enum Platforms
{
    Unknow = 0,
    PC = 1,
    MAC = 2,
    Linux = 3,
    PS4 = 4,
    XBOXONE = 5
}

public class Game
{
    String name;
    Genre genre;
    List<Platforms> platforms;
    int releaseDate;
    Dictionary<Platforms, Ranking> rankings;

    public Game()
    {
        this.name = "Unknow";
        this.genre = Genre.Unknow;
        this.platforms = null;
        this.releaseDate = 1980;
        this.rankings = null;
    }

    public Game(String name, Genre genre, List<Platforms> platforms, int releaseDate, Dictionary<Platforms, Ranking> rankings)
    {
        this.name = name;
        this.genre = genre;
        this.platforms = platforms;
        if(releaseDate<1980 || releaseDate > 2018)
        {
            this.releaseDate = 1980;
        }
        else
        {
            this.releaseDate = releaseDate;
        }
        
        this.rankings = rankings;
    }

    public String GetName()
    {
        return name;
    }

    public Genre GetGenre()
    {
        return genre;
    }

    public List<Platforms> GetPlatforms()
    {
        return platforms;
    }

    public int GetReleaseDate()
    {
        return releaseDate;
    }

    public Dictionary<Platforms, Ranking> GetRankings()
    {
        return rankings;
    }

    //Condicion de igualdad para dos juegos iguales
    public override bool Equals(object obj)
    {
        Game g = new Game();
        if(g == obj)
        {
            g = (Game)obj;
            if(this.GetName()== g.GetName())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //ToString game
    public override string ToString()
    {
        String plat = "";
        String game = "--- " + GetName() + " (" + GetReleaseDate() + ") - ";
        String rank = "";

        foreach (Platforms p in platforms)
        {
            plat += p.ToString() + ", ";
        }

        game += plat + " - " + GetGenre() + " ---\n";

        foreach(Ranking r in rankings.Values){

            rank += "- " + r.GetName() + " (" + r.GetScores().Count + ")\n";
            
        }

        rank = "Ranking \n" + rank;

        game += rank;

        return game;
    }
}

