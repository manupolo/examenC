using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        //Test Player-------------------------------------------
        //Player p = new Player("TheNotorius", "TheNot@gmail.com", Country.Spain);
        //Console.WriteLine(p.ToString());
        //Console.ReadLine();

        //Test taking--------------------------------
        //Score s1 = new Score("pepe",3);
        //Score s2 = new Score("Marco",4);
        //Score s3 = new Score("Keyor",3);
        //Score s4 = new Score("Nonaino",3);

        //List<Score> scor = new List<Score>();
        //scor.Add(s1);
        //scor.Add(s2);
        //scor.Add(s3);
        //scor.Add(s4);
        //Ranking r = new Ranking("Juanfe", scor);

        //Console.WriteLine(r.ToString());
        //Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Elija la opcion que desee: \n");
            String comando = Console.ReadLine();

            switch (comando)
            {
                case "import":

                    break;

                case "export":

                    break;

                case "oldest":
                    Console.WriteLine(GameServices.GetOldestGame().ToString());                    
                    break;

                case "scoreCount":
                    Console.WriteLine("Introduce el nombre del juego");
                    String gameName = Console.ReadLine();
                    Console.WriteLine("Introduce el nombre del ranking");
                    String rankName = Console.ReadLine();

                    Console.WriteLine("El numero de puntuaciones del juego " + gameName + " es: " + GameServices.GetRankingCount(gameName, rankName));

                    break;

                case "gamesCountByGenre":
                    Console.WriteLine("Introduce el nombre del genero");
                    String genreName = Console.ReadLine();
                    Genre genre = (Genre)Enum.Parse(typeof(Genre), genreName);
                    Console.WriteLine("La plataforma: " + genreName + " contiene " + GameServices.GetGenreGames(genre) + " juegos");
                    break;

                case "gamesByPlayer":
                    String key = "";
                    String game = "";
                    String gameList = "";
                    Dictionary<String, List<Game>> playersGames = GameServices.GetPlayersGames();

                    foreach (KeyValuePair<string, List<Game>> dic in playersGames)
                    {
                        key = dic.Key;
                        foreach (Game g in dic.Value)
                        {
                            game +=", " + g.GetName();
                        }
                        gameList = "->" + key + "\n" + "=======> " + game + "\n";
                    }

                    Console.WriteLine(gameList);

                    break;

            }
        }
        

    }

}

