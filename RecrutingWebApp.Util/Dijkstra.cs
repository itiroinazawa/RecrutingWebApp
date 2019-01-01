namespace RecrutingWebApp.Util
{
    public class Dijkstra
    {
        /// <summary>
        /// Metodo responsavel por retornar a menor distancia entre os dois pontos
        /// </summary>
        /// <param name="distanceArray">Array responsavel por guardar as informacoes de distancia entre os pontos</param>
        /// <param name="shortestPathTreeSet">Array responsavel por verificar se a informacao de distancia ja foi preenchida</param>
        /// <param name="numberOfVertex">Numero de vertices</param>
        /// <returns>Index da menor distancia</returns>
        private int MinDistance(int[] distanceArray, bool[] shortestPathTreeSet, int numberOfVertex)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < numberOfVertex; v++)
            {
                if (shortestPathTreeSet[v] == false && distanceArray[v] <= min)
                {
                    min = distanceArray[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        /// <summary>
        /// Metodo responsavel por encontrar o menor caminho entre dois vertices 
        /// </summary>
        /// <param name="originalMatrix">Matrix que contem as informacoes de todos os pontos com suas distancias</param>
        /// <param name="src">Indice de partida</param>
        /// <param name="target">Indice de chegada</param>
        /// <param name="numberOfVertex">Numero de vertices</param>
        /// <returns>Valor da distancia entre os pontos</returns>
        public int GetShortestPath(int[,] originalMatrix, int src, int target, int numberOfVertex)
        {
            int[] distanceArray = new int[numberOfVertex];

            bool[] shortestPathTreeSet = new bool[numberOfVertex];

            for (int i = 0; i < numberOfVertex; i++)
            {
                distanceArray[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distanceArray[src] = 0;

            for (int count = 0; count < numberOfVertex - 1; count++)
            {
                int u = MinDistance(distanceArray, shortestPathTreeSet, numberOfVertex);

                shortestPathTreeSet[u] = true;

                for (int v = 0; v < numberOfVertex; v++)
                {
                    if (!shortestPathTreeSet[v] 
                        && originalMatrix[u, v] != 0
                        && distanceArray[u] != int.MaxValue
                        && distanceArray[u] + originalMatrix[u, v] < distanceArray[v])
                    {
                        distanceArray[v] = distanceArray[u] + originalMatrix[u, v];
                    }
                }
            }

            return distanceArray[target];
        }
    }
}
