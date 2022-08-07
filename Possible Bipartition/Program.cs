using System;
using System.Collections.Generic;

namespace Possible_Bipartition
{
  class Program
  {
    static void Main(string[] args)
    {
			var dislikes = new int[5][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5 }, new int[] { 1, 5 } };
			Solution s = new Solution();
			var answer = s.PossibleBipartition(5, dislikes);
			Console.WriteLine(answer);
    }
  }

  public class Solution
  {
		public bool PossibleBipartition(int N, int[][] dislikes)
		{
			if (dislikes.Length < 2)
			{
				return true;
			}

			Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
			for (int i = 1; i <= N; i++)
			{
				graph.Add(i, new List<int>());
			}

			foreach (var p in dislikes)
			{
				graph[p[0]].Add(p[1]);
				graph[p[1]].Add(p[0]);
			}


			bool?[] visited = new bool?[N + 1];
			foreach (var node in graph.Keys)
			{
				if (!visited[node].HasValue && !Dfs(graph, node, visited, true))
				{
					return false;
				}
			}

			return true;
		}


		private bool Dfs(Dictionary<int, List<int>> graph, int node, bool?[] visited, bool currentColor)
		{
			if (visited[node].HasValue)
			{
				return visited[node].Value == currentColor;
			}

			visited[node] = currentColor;

			foreach (var neighbour in graph[node])
			{
				if (!Dfs(graph, neighbour, visited, !currentColor))
				{
					return false;
				}
			}

			return true;
		}
	}
}
