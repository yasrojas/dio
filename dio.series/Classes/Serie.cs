using System;

namespace dio.series
{
    public class Serie : EntidadeBase
    {
        //atributos da serie
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;} //tirar quando implementar banco de dados

        //construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id; 
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        //metodos
        public override string ToString()
        {
            string retorno = " ";
            retorno += $"Gênero: {this.Genero}" + Environment.NewLine;
            retorno += $"Título: {this.Titulo}" + Environment.NewLine;
            retorno += $"Descrição: {this.Descricao}" + Environment.NewLine;
            retorno += $"Ano de Lançamento: {this.Ano}" + Environment.NewLine;
            retorno += $"Excluido: {this.Excluido}";
            
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}