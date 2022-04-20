using static System.Console;

//var array = Array.Empty<string>();
//var array = new[] { "1st" };
//var array = new[] { "1st", "2nd", "3rd" };
//var array = new[] { "1st", "2nd", "3rd", "4th" };
var array = new[] { new[] {1, 2, 3, 4}, new[] { 5, 6, 7, 8 }, new[] { 9, 10, 11, 12 } };

var tmpString = array switch
{
    [] => "Empty array of string",
    [.., [_, .. int[] middle, _]] => string.Join(",", middle),
    //[string item1] => $"1st=\"{item1}\"",
    //[string item1, string item2, string item3] => $"1st=\"{item1}\", 2nd =\"{item2}\", 3rd=\"{item3}\"",
    //[_, string item2, _] => $"2nd =\"{item2}\"",
    //[_, .. string[] theRest] => string.Join(",", theRest),
    //[_, .. string[] theRest, _] => string.Join(",", theRest),
    _ => "Default"
};

WriteLine(tmpString);