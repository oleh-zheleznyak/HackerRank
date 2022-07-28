using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems;

public class SherlockAndTheValidString
{
    private static int range = 'z' - 'a' + 1;

    public bool IsValid(string input)
    {
        var counterArray = CountChars(input);
        
        var min = counterArray.Min();
        var max = counterArray.Max();
        var diff = max - min;

        if (diff == 0) return true; // same count of all chars

        var countMin = counterArray.Where(x => x == min).Count();
        var singleLooseChar = ((countMin == 1) && (min == 1));
        
        var countMax = counterArray.Where(x => x == max).Count();
        
        if (diff > 1) return singleLooseChar && (countMax == counterArray.Length - 1); 

        return countMax == 1 || singleLooseChar;
    }

    private int[] CountChars(string input)
    {
        var counterArray = new int[range];

        for (var i = 0; i < input.Length; i++)
        {
            var index = input[i] - 'a';
            counterArray[index]++;
        }

        return counterArray.Where(x=>x>0).ToArray();
    }
}
