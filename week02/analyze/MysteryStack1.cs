public static class MysteryStack1 {
    public static string Run(string text)
     {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
    class Program
{
    static void Main()
    {
        Console.WriteLine(MysteryStack1.Run("racecar")); // Outputs: "racecar"
        Console.WriteLine(MysteryStack1.Run("stressed")); // Outputs: "desserts"
        Console.WriteLine(MysteryStack1.Run("a nut for a jar of tuna")); // Outputs: "anut fo raj a rof tun a"
    }
}
}