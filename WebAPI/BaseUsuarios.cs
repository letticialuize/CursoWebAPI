﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public static class BaseUsuarios
    {
        public static IEnumerable<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario { Nome = "Fulano", Senha = "123456"},
                new Usuario { Nome = "Beltrano", Senha = "123456"},
                new Usuario { Nome = "Siclano", Senha = "123456"}
            };
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}