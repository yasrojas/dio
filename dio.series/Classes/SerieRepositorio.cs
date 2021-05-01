using System.Collections.Generic;

namespace dio.series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            /*pode usar quando tiver banco de dados
            listaSeries.RemoveAt(id); */

            listaSeries[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSeries.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }
        
    }
}