namespace AdventOfCode2023.Day2;

public static class Day2
{
    static StreamReader reader = new ("../../../Day2/Input.txt");

    // trying to refactor puzzle 1 broke the code somehow so um. we will just leave this alone...
    public static void SolvePuzzle1()
    {
        string? line = reader.ReadLine();
        var answer = 0;
        var bluelimit = 14;
        var redlimit = 12;
        var greenlimit = 13;
        while (line != null)
        {
            var invalid = false;
            var game = line.Split(":");
            var gameid = game[0][4..];
            var hands = game[1].Split(";");
            
            foreach (var hand in hands)
            {
                var colors = hand.Split(",");
                foreach (var color in colors)
                {
                    if (color.Contains("blue"))
                    {
                        if (int.Parse(color[..3]) > bluelimit)
                        {
                            invalid = true;
                            break;
                        }
                    }
                    else if (color.Contains("red"))
                    {
                        if (int.Parse(color[..3]) > redlimit)
                        {
                            invalid = true;
                            break;
                        }
                    }
                    else if (color.Contains("green"))
                    {
                        if (int.Parse(color[..3]) > greenlimit)
                        {
                            invalid = true;
                            break;
                        }
                    }
                }

                if (invalid)
                {
                    break;
                }
            }

            if (!invalid)
            {
                answer += int.Parse(gameid);
            }
            
            line = reader.ReadLine();
        }
        Console.WriteLine(answer);
    }

    public static void SolvePuzzle2()
    {
        string? line = reader.ReadLine();
        var answer = 0;
        
        while (line != null)
        {
            var maxblue = 0;
            var maxred = 0;
            var maxgreen = 0;
            
            var game = line.Split(":");
            var gameid = game[0][4..];
            var hands = game[1].Split(";");
            foreach (var hand in hands)
            {
                var colors = hand.Split(",");
                foreach (var color in colors)
                {
                    if (color.Contains("blue"))
                    {
                        var num = int.Parse(color[..3]);
                        if (maxblue < num)
                        {
                            maxblue = int.Parse(color[..3]);
                        }
                    }
                    else if (color.Contains("red"))
                    {
                        var num = int.Parse(color[..3]);
                        if (maxred < num)
                        {
                            maxred = int.Parse(color[..3]);
                        }
                    }
                    else if (color.Contains("green"))
                    {
                        var num = int.Parse(color[..3]);
                        if (maxgreen < num)
                        {
                            maxgreen = int.Parse(color[..3]);
                        }
                    }
                }
            }

            answer += maxred * maxgreen * maxblue;
            line = reader.ReadLine();
        }
        Console.WriteLine(answer);
    }
}