﻿Console.WriteLine(new List<string[]>(){File.ReadAllLines("input.txt")}.Select(j => j.Select((c, row) => c.Select((w, col) => w == '#' ? new Tuple<int,int,int>(row, col, 1) : new Tuple<int,int,int>(row, col, 0)).ToList()).ToList()).Select(j => new{ map = j, rowsum = j.Select((row, i) => new{ct = row.Sum(t => t.Item3), ind = i}), colsum = Enumerable.Range(0, j[0].Count()).Select((col, i) => new{ind = i, ct = j.Select(row => row[col]).Sum(t => t.Item3)}).ToList()}).Select(j => j.map.Aggregate(new List<Tuple<int,int>>(), (previous, current) => current.Aggregate(previous, (prev, c) => (c.Item3 == 1) ? [.. prev, new Tuple<int,int>(c.Item1 + j.rowsum.Count(t => t.ind < c.Item1 && t.ct == 0), c.Item2 + j.colsum.Count(t => t.ind < c.Item2 && t.ct == 0))] : prev))).SelectMany(j => j.SelectMany(t => j.Select(r => Math.Abs(t.Item1 - r.Item1) + Math.Abs(t.Item2 - r.Item2)))).Sum() / 2);