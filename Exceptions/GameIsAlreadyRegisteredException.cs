using System;

namespace ApiGames.Exceptions
{
    public class GameIsAlreadyRegisteredException : Exception
    {
        public GameIsAlreadyRegisteredException()
            :base("Este jogo já está cadastrado")
            {}
    }
}