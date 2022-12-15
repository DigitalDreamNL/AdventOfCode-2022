using AdventOfCode2022.D12.Exceptions;
using AdventOfCode2022.D12.Models;

namespace AdventOfCode2022.D12;

public class PathFinder
{
    private Heightmap Heightmap { get; }

    public PathFinder(Heightmap heightmap)
    {
        Heightmap = heightmap;
    }

    public List<Node> DetermineShortestPath()
    {
        var startNode = Node.CreateStartNode(Heightmap.Start, 1 + Heightmap.MaxClimbHeight);
        var nodes = new List<Node> {startNode};

        while (!nodes.Any(n => n.IsTarget))
        {
            var cheapestNode = nodes.Where(n => !n.Done).OrderBy(n => n.Score).FirstOrDefault();
            if (cheapestNode == null)
                throw new RouteNotPossibleException();

            var reachableNeighbors = FindReachableNeighbors(cheapestNode, nodes);
            nodes = nodes.Concat(reachableNeighbors).ToList();
        }

        var lastNode = nodes.Single(n => n.IsTarget);
        
        var path = new List<Node>();

        while (true)
        {
            lastNode = lastNode.PreviousNode;
            path.Add(lastNode!);

            if (lastNode!.X == Heightmap.Start.X && lastNode.Y == Heightmap.Start.Y)
                break;
        }

        return path;
    }

    private List<Node> FindReachableNeighbors(Node node, List<Node> path)
    {
        var nodes = new List<Node>();
        
        if (node.X > 0)
            AddNeighborIfAccessible(-1, 0, node, nodes, path);

        if (node.X < Heightmap.Map.GetLength(0) - 1)
            AddNeighborIfAccessible(1, 0, node, nodes, path);

        if (node.Y > 0)
            AddNeighborIfAccessible(0, -1, node, nodes, path);

        if (node.Y < Heightmap.Map.GetLength(1) - 1)
            AddNeighborIfAccessible(0, 1, node, nodes, path);
    
        node.Done = true;
        
        return nodes;
    }
    
    private void AddNeighborIfAccessible(int dX, int dY, Node node, List<Node> nodes, List<Node> path)
    {
        var neighborValue = Heightmap.Map[node.X + dX, node.Y + dY];
        if (node.MaxClimbValue < neighborValue) return;

        var newNode = Node.FromPreviousNode(node, dX, dY, Heightmap);

        var previouslyVisitedNode = path.FirstOrDefault(n => n.X == node.X + dX && n.Y == node.Y + dY);
        if (previouslyVisitedNode == null)
        {
            nodes.Add(newNode);
            return;
        }

        if (newNode.Score >= previouslyVisitedNode.Score)
            return;

        path.Remove(previouslyVisitedNode);
        nodes.Add(newNode);
    }
}