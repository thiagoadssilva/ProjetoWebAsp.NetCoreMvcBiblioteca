﻿namespace Biblioteca.Models.Repositories
{
    public abstract class EntidadeBase
    {
        public string Id { get; set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
