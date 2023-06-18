﻿namespace Biblioteca.Models.Entidades
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public StatusCliente StatusCliente { get; set; }
    }
}
