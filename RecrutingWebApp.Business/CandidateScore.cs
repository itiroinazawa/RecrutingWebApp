using RecrutingWebApp.Model;
using RecrutingWebApp.Util;
using System;

namespace RecrutingWebApp.Application 
{
    public class CandidateScore
    {
        private readonly int[,] graph;
        private readonly int numberOfVertex;

        public CandidateScore()
        {
            graph = new int[,]
              {
                {0, 5, 0, 0, 0, 0},
                {5, 0, 7, 3, 0, 0},
                {0, 7, 0, 0, 4, 0},
                {0, 3, 0, 0, 10, 8},
                {0, 0, 4, 10, 0, 0},
                {0, 0, 0, 8, 0, 0}
              };

            numberOfVertex = 6;
        }

        /// <summary>
        /// Metodo responsavel por calcular o score do candidato para a vaga
        /// </summary>
        /// <param name="candidateLocation">Localizacao do Candidato</param>
        /// <param name="candidateLevel">Nivel de experiencia da Candidato</param>
        /// <param name="jobLocation">Localizacao da vaga</param>
        /// <param name="jobLevel">Nivel de experiencia da vaga</param>
        /// <returns>Score do candidato</returns>
        public int CalculateCandidateScore(Location candidateLocation, ExperienceLevel candidateLevel, Location jobLocation, ExperienceLevel jobLevel)
        {
            int score = 0;
            int D = 0;

            int NV_ND = Math.Abs(Convert.ToInt32(jobLevel) - Convert.ToInt32(candidateLevel));

            int N = 100 - (25 * NV_ND);       

            D = CalculateDistanceValue(candidateLocation, jobLocation);

            score = (N + D) / 2;
            
            return score;
        }

        /// <summary>
        /// Metodo responsavel por calcular o valor da distancia baseado no algoritmo de Dijkstra e de seu retorno
        /// </summary>
        /// <param name="candidateLocation">Localizacao do Candidato</param>
        /// <param name="jobLocation">Localizacao da Vaga</param>
        /// <returns></returns>
        private int CalculateDistanceValue(Location candidateLocation, Location jobLocation)
        {
            Dijkstra algorithm = new Dijkstra();
            int shortestPathValue = algorithm.GetShortestPath(graph, Convert.ToInt32(candidateLocation), Convert.ToInt32(jobLocation), numberOfVertex);

            if (shortestPathValue <= 5)
                return 100;
            else if (shortestPathValue > 5 && shortestPathValue <= 10)
                return 75;
            else if (shortestPathValue > 10 && shortestPathValue <= 15)
                return 50;
            else if (shortestPathValue > 15 && shortestPathValue <= 20)
                return 25;
            else
                return 0;
        }
    }
}
