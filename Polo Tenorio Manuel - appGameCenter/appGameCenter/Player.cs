using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Enum country
public enum Country
{
    Spain = 1,
    France = 2,
    USA = 3,
    UnitedKingdom = 4,
    Japan = 5,
    Italy = 6,
    Brazil = 7,
    Germany = 8,
    Australia = 9,
    Canada = 10
}

public class Player
{
    String nickName;
    String email;
    Country country;

    //Constructor vacio clase player
    public Player()
    {
        nickName = "Unknow";
        email = "Unknow";
        country = 0;
    }

    //Constructor clase player con datos
    public Player(String nickName, String email, Country country)
    {
        this.nickName = nickName;
        this.email = email;
        this.country = country;
    }

    //Getters y Setters
    public String GetNickName()
    {
        return nickName;
    }

    //public void SetNickName(String nickName)
    //{
    //    this.nickName = nickName;
    //}

    public String GetEmail()
    {
        return email;
    }

    public void SetEmail(String email)
    {
        this.email = email;
    }

    public Country GetCountry()
    {
        return country;
    }

    public void SetCountry(Country country)
    {
        this.country = country;
    }

    //Criterio igualdad para ver si dos jugadores son iguales
    public override bool Equals(object obj)
    {
        Player p = new Player();

        if(p == obj)
        {
            p = (Player)obj;
            if(p.GetNickName() == this.GetNickName())
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

    //ToString player
    public override string ToString()
    {
        String player = GetNickName() + " - " + GetEmail() + " - " + GetCountry();

        return player;
    }
}

