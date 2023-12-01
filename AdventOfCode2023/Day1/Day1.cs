namespace AdventOfCode2023.Day1;

/***
 * Solving this in two different ways. First one is the jank way. Second one is more efficient
 * I would explain each algorithm...buut whats the point if this is supposed to be a challenge for you
 * 
 * And just because AOC didnt make this clear here is some annoying test cases...
 * Test cases: three---6; three---six; three---eightwo; fgsthree---6erh; fgsthree---sixerh;
 */
public static class Day1
{
    static StreamReader reader = new ("../../../Day1/Input.txt");
    public static void SolvePuzzle1()
    {
        string? line = reader.ReadLine();
        var answer = 0;
        while (line != null)
        {
            var num = "";
            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    num += c;
                    break;
                }
            }

            for (int i = line.Length - 1; i >= 0; i--)
            {
                char c = line[i];
                if (char.IsDigit(c))
                {
                    num += c;
                    break;
                }
            }

            answer += int.Parse(num);
            line = reader.ReadLine();
        }
        Console.WriteLine(answer);
    }

    public static void SolvePuzzle2()
    {
        string? line = reader.ReadLine();
        var answer = 0;
        var word = "";
        var i = 0;
        while (line != null)
        {
            var num = ' ';
            var secondnum = ' ';
            foreach (char c in line)
            {
                word += c;
                char number = GetNumber(word);
                if (char.IsDigit(number))
                {
                    if (char.IsDigit(num))
                    {
                        secondnum = number;
                    }
                    else
                    {
                        num = number;
                        secondnum = number;
                    }
                    word = "";
                    word += c;
                }
                else if (char.IsDigit(c))
                {
                    if (char.IsDigit(num))
                    {
                        secondnum = c;
                    }
                    else
                    {
                        num = c;
                        secondnum = c;
                    }
                }
            }

            Console.WriteLine($"{line} (line {i+1}): {num}{secondnum}");
            answer += int.Parse($"{num}{secondnum}");
            line = reader.ReadLine();
            i++;
        }
        Console.WriteLine(answer);
    }

    private static char GetNumber(string word)
    {
        // Id use a dictionary if i didnt have to check for random characters smh...
        if (word.Contains("one"))
        {
            return '1';
        }
        if (word.Contains("two"))
        {
            return '2';
        }
        if (word.Contains("three"))
        {
            return '3';
        }
        if (word.Contains("four"))
        {
            return '4';
        }
        if (word.Contains("five"))
        {
            return '5';
        }

        if (word.Contains("six"))
        {
            return '6';
        }
        if (word.Contains("seven"))
        {
            return '7';
        }
        if (word.Contains("eight"))
        {
            return '8';
        }
        if (word.Contains("nine"))
        {
            return '9';
        }

        return ' ';
    }
}