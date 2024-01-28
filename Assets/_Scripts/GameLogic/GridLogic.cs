using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class GridLogic
{
    public static int[] Shuffle(List<int> numbers)
    {
        System.Random random = new System.Random();
        numbers.Sort((x, y) => random.Next(-1, 1));
        return numbers.ToArray();
    }
    public static int[] GetGrid(int gridSize)
    {
        List<int> numbers = new List<int>();
        for (int i = 0; i < gridSize * gridSize; i++)
            numbers.Add(i);
        Shuffle(numbers);
        Shuffle(numbers);
        Shuffle(numbers);
        Shuffle(numbers);
        while (!IsSolvable(numbers, gridSize) && GetInvCount(numbers) > 2)
            Shuffle(numbers);
        return numbers.ToArray();
    }        
    public static bool IsSolvable(List<int> numbers, int gridSize)
    {
        int countInversions = GetInvCount(numbers);
        if(countInversions < 4) return false;

        if (gridSize % 2 != 0)
            return countInversions % 2 == 0;
        else
        {
            int emptyCellLine = (gridSize - (Mathf.FloorToInt((float)GetEmptyIndex(numbers) / gridSize)));
            PrintList(numbers);
            Debug.Log($"positionFromBottom: {emptyCellLine}\n" +
                $"Inv count: {countInversions}");
            if ((gridSize - emptyCellLine) % 2 == 0)
                return countInversions % 2 != 0;
            else
                return countInversions % 2 == 0;
        }
    }
    public static int GetEmptyIndex(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)                
        {
            if (numbers[i] == 0)            
                return i;            
        }
        return -1;
    }
    public static int GetInvCount(List<int> numbers)
    {
        int countInversions = 0;
        for (int x = 0; x < numbers.Count; x++)
        {
            if (numbers[x] == 0)
                continue;
            for (int y = x + 1; y < numbers.Count; y++)
            {
                if (numbers[y] == 0)
                    continue;

                if (numbers[x] > numbers[y])
                    countInversions++;
            }
        }
        return countInversions;
    }
    static void PrintList(List<int> lst)
    {
        string s = "";
        foreach (var item in lst)
        {
            s += item.ToString() + " ";
        }
        Debug.Log(s);
    }    
}
