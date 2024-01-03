//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace Week5
//{
//    public class Graph
//    {
//        private int V;
//        private List<int>[] adj;

//        public Graph(int v) 
//        {
//            V = v;
//            adj = new List<int>[V]; //리스트 만들 준비
//            for (int i = 0; i < V; i++)
//            {
//                adj[i] = new List<int>(); //실제 리스트 만드는 과정
//            }
//        }

//        public void AddEdge(int v,int w)
//        {
//            adj[v].Add(w); //v번째 버텍스에서 w번째 버텍스로 엣지를 연결
//        }

//        public void DFS(int v)
//        {
//            bool[] visited = new bool[V]; //방문을 했나 안했나 검사하는 bool
//            DFSUtil(v, visited);
//        }

//        private void DFSUtil(int v, bool[] visited)
//        {
//            visited[v] = true;
//            Console.Write($"{v} ");

//            foreach (int n in adj[v]) //v버텍스에서 다른 곳으로 접근하는거
//            {
//                if (!visited[n])
//                {
//                    DFSUtil(n, visited); //새로운 곳 발견하면 계속 재귀함수. 더 이상 갈 곳이 없으면 돌아와서 다른 다리로 감.
//                }
//            }
//        }

//        public void BFS(int v)
//        {
//            bool[] visited = new bool[v];
//            Queue<int> queue = new Queue<int>(); //선입선출

//            visited[v] = true;
//            queue.Enqueue(v);

//            while (queue.Count >0)//queue에 뭔가 들어있을때만 동작
//            {
//                int n = queue.Dequeue();
//                Console.Write($"{n} ");

//                foreach(int m in adj[n]) //처음 들어왔을때 연결된 다리들 전체를 검색
//                {
//                    if (!visited[m])
//                    {
//                        visited[m] = true;
//                        queue.Enqueue(m);
//                    }
//                }
//            }
//        }
//    }

//    internal class DFS
//    {
//        static void Main(string[] args)
//        {
//            Graph graph = new Graph(6);

//            graph.AddEdge(0, 1);
//            graph.AddEdge(0, 2);
//            graph.AddEdge(1, 3);
//            graph.AddEdge(2, 3);
//            graph.AddEdge(2, 4);
//            graph.AddEdge(3, 4);
//            graph.AddEdge(3, 5);
//            graph.AddEdge(4, 5);

//            Console.WriteLine("DFS travelsal : ");
//            graph.DFS(0);
//            Console.WriteLine();
//        }
//    }
//}
