using System;

namespace ApiGames.Exceptions
{
    public class GameNotRegisteredException : Exception
    {
        public GameNotRegisteredException()
            :base("Este jogo não está cadastrado")
            {}
    }
}