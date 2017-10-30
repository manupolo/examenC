using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameServices
{
    //Tipo lista players
    private static List<Player> players;
    //consultar lista player
    public static List<Player> Players
    {
        get { return players; }
        set { players = value; }
    }

    //Tipo lista games
    private static List<Game> games;
    //Consultar lista games
    public static List<Game> Games
    {
        get { return games; }
        set { games = value; }
    }

    //-------------------Import y export----------------------

    //En este metodo concatenamos todos los jugadores con todos los juegos y rankings
    public static String getExport()
    {
        String res = "";

        res = GetExportPlayers() + "\n" + "*+*+*+*" + "\n" + GetExportGames() + "\n" + "*+*+*+*" + "\n" + GetExportRanking() + "\n";

        try
        {
            //Leer el fichero o crearlo si no existe
            StreamWriter fichero = File.CreateText("../../Resources");
            fichero.WriteLine(res);
            fichero.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al abrir o crear el archivo de texto");
            throw;
        }

        return res;
    }

    //Exporta cadena de jugadores
    public static String GetExportPlayers()
    {
        String play = "";

        foreach (Player p in players)
        {
            play += p.GetNickName() + " - " + p.GetEmail() + " - " + p.GetCountry() + "\n";
        }

        return play;
    }

    //Exporta cadena de juegos
    public static String GetExportGames()
    {
        int plat = 0;
        String pl = "";
        String game = "";

        foreach (Game g in games)
        {
            foreach (Platforms p in g.GetPlatforms())
            {
                plat += (int)p;
                pl = plat + ", ";
            }
            game += g.GetName() + " - " + g.GetGenre() + " - " + g.GetReleaseDate() + " - " + pl;
        }

        return game;
    }

    //Exporta cadena de rankings
    public static String GetExportRanking()
    {
        String ranking = "";
        String score = "";
        Ranking rr = null;

        foreach (Game g in games)
        {
            foreach (Ranking r in g.GetRankings().Values)
            {
                rr = r;
                foreach (Score s in r.GetScores())
                {
                    score = s.GetNickName() + " = " + s.GetPoint() + ", ";
                }
            }

            ranking += g.GetName() + " - " + rr.GetName() + " - " + score;
        }

        return ranking;
    }

    //-------------------Funcionalidades----------------------

    //Juego mas antiguo de la empresa
    public static Game GetOldestGame()
    {
        Game game = null;

        foreach (Game g in games)
        {
            if(game == null || g.GetReleaseDate() < game.GetReleaseDate())
            {
                game = g;
            }
        }

        return game;
    }

    //Cuatas puntuaciones tiene registrada un ranking
    public static int GetRankingCount(String gameName, String rankingName)
    {
        int n = 0;
        foreach (Game g in games)
        {
            if (g.GetName() == gameName)
            {
                if (g.GetRankings().Values.ToString() == rankingName)
                {
                    n = g.GetRankings().Count();
                }
                
            }
        }

        return n;
    }

    //Cuantos juegos de un genero existen publicados
    public static int GetGenreGames(Genre genre)
    {
        int i = 0;
        foreach (Game g in games)
        {
            if (g.GetGenre() == genre)
            {
                i++;
            }
        }
        return i;
    }

    //Juego con mas puntuaciones registradas
    public static Game MoreScoresGame()
    {
        Game game = null;

        foreach (Game g in games)
        {
            if(game == null || game.GetRankings().Values.Count < g.GetRankings().Values.Count)
            {
                game = g;
            }
        }

        return game;
    }

    //Existe algun juego con la palabra call
    public static bool GameContainsCall()
    {
        bool res = false;
        foreach (Game g in games)
        {
            if (g.GetName().Contains("Call"))
            {
                res = true;
            }
            else
            {
                res = false;
            }
        }
        return res;
    }

    //Juegos a los que ha jugado un determinado jugador
    public static List<Game> GetPlayerGame(String nickName)
    {

        List<Game> gamePlayer = null;
        //Recorremos lista de juegos
        foreach (Game g in games)
        {
            Dictionary<Platforms, Ranking> rank = g.GetRankings();
            //Recorremos lista de rankings
            foreach (Ranking r in rank.Values)
            {
                List<Score> scor = r.GetScores();
                //Recorremos lista de scores y comparamos los niknames
                foreach (Score s in scor)
                {
                    if (s.GetNickName() == nickName)
                    {
                        gamePlayer.Add(g);
                    }
                }
            }
        }

        return gamePlayer;
    }

    //A que juegos ha jugado cada jugador
    public static Dictionary<String, List<Game>> GetPlayersGames()
    {
        List<Game> gam = null;
        Dictionary<String, List<Game>> gamesPlayers = null;
        //Buscar nikname jugadore
        foreach (Player p in players)
        {
            p.GetNickName();

            //buscar nikname juegos
            foreach (Game g in games)
            {
                Dictionary<Platforms, Ranking> rank = g.GetRankings();

                foreach (Ranking r in rank.Values)
                {
                    List<Score> scor = r.GetScores();

                    foreach (Score s in scor)
                    {
                        //Si coinciden nik de juego y de jugador se añade a una lista de juegos el juego
                        if (s.GetNickName() == p.GetNickName())
                        {
                            gam.Add(g);
                            
                        }
                    }
                }
            }
            //Añadimos al diccionario el jugador con su lista de juegos correspondientes
            gamesPlayers.Add(p.GetNickName(), gam);
        }
        
        return gamesPlayers;
    }
}
