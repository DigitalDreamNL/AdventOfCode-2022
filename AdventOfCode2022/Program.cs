using AdventOfCode2022.D1;
using AdventOfCode2022.D2;

Console.WriteLine("Advent of Code 2022");

var d1E1 = new D1E1();
var d1E1Result = await d1E1.Execute();
Console.WriteLine($"D1E1: {d1E1Result}");

var d1E2 = new D1E2();
var d1E2Result = await d1E2.Execute();
Console.WriteLine($"D1E2: {d1E2Result}");

var d2E1 = new D2E1();
var d2E1Result = await d2E1.Execute();
Console.WriteLine($"D2E1: {d2E1Result}");

var d2E2 = new D2E2();
var d2E2Result = await d2E2.Execute();
Console.WriteLine($"D2E2: {d2E2Result}");
