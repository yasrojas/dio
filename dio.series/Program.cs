using System;

namespace dio.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série");

            ListarSeries();

            Console.WriteLine("Digite o ID da série que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(id);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir série");

            ListarSeries();

            Console.WriteLine("Digite o ID da série que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine($"Deseja mesmo excluir a série com ID:{id}? S/N");
            string opcaoExcluir = Console.ReadLine();
            
            if(opcaoExcluir == "S")
            {
                repositorio.Exclui(id);
            }
            else
            {
                return;
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar série");

            ListarSeries();

            Console.WriteLine("Digite o ID da série que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine()); 
            
            //mostra as opçoes de genero de acordo com o enum Genero
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine("Digite o novo gênero entre as opções acima: ");
            int generoAtualizado = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o novo título da série: ");
            string tituloAtualizado = Console.ReadLine();
            
            Console.WriteLine("Digite o ano de lançamento da série: ");
            int anoAtualizado = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite a nova descricao da série: ");
            string descricaoAtualizada = Console.ReadLine();
            
            Serie serieAtualizada = new Serie(
                
                id: id,
                genero: (Genero)generoAtualizado,
                titulo: tituloAtualizado,
                descricao: descricaoAtualizada,
                ano: anoAtualizado );

            repositorio.Atualiza(id ,serieAtualizada);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir série");
            
            //mostra as opçoes de genero de acordo com o enum Genero
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite a descricao da série: ");
            string entradaDescricao = Console.ReadLine();
            
            Serie novaSerie = new Serie(
                
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno );

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} {(excluido ? "*Excluido*" : "")} ");

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!");
            Console.WriteLine("Informe a opção desejada: ");
            
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
