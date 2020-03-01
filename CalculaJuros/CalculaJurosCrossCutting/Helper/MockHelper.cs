using CalculaJuros.Domain;
using System;
using System.Collections.Generic;

namespace CalculaJuros.CrossCutting.Helper
{
    public static class MockHelper
    {
        private const string URL_PROJETO_TAXA = "https://github.com/brunoesantana/TaxaJuros";
        private const string URL_PROJETO_CALCULO = "https://github.com/brunoesantana/CalculaJuros";

        public static List<Projeto> GetProjeto()
        {
            return new List<Projeto>
            {
                new Projeto{ Id = Guid.NewGuid(), Url = URL_PROJETO_TAXA },
                new Projeto{ Id = Guid.NewGuid(), Url = URL_PROJETO_CALCULO }
            };
        }

        public static Calculo GetCalculo()
        {
            return new Calculo { Id = Guid.NewGuid() };
        }
    }
}