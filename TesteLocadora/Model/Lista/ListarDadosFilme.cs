﻿using TesteLocadora.View.Produtos;

namespace TesteLocadora.Model.Lista
{
    public class ListaCadastroFilme
    {
        public List<Filme> ListaFilme { get; set; }
        public ListaCadastroFilme()
        {
            if (ListaFilme == null)
            {
                ListaFilme = new List<Filme>();
                Filme filme1 = new Filme(1, "Pantera Negra",2, true);
                Filme filme2 = new Filme(2, "Cinderela",1, true);


                ListaFilme.Add(filme1);
                ListaFilme.Add(filme2);
            }
        }
    }
}
