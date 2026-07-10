// // Brazilian phone number formats:
// // 551712239884
// // 5548932118740
// // +551132216554
// // +5567987465321
// // 55 (18) 91234-5487
// // +55 (17) 91234-5487
// // 55 (35) 998745462
// // 55 (48) 33221100

using System.Text.RegularExpressions;

string pattern =
    @"[+]?55(([0-9]{2})|([ ][0-9]{2}[ ])|([ ]\([0-9]{2}\)[ ]))[0-9]{4,5}(-|[ ])?[0-9]{4}";
Regex regex = new Regex(pattern);
string text = "My number is 551712239884, or +55 (17) 91234-5487";

MatchCollection matchColletion = regex.Matches(text);
Console.WriteLine($"String: {text}");
Console.WriteLine($"Hits found: {matchColletion.Count}\n{text}");

int i = 0;
foreach (Match hit in matchColletion)
{
    GroupCollection group = hit.Groups;
    Console.WriteLine(
        $"Match {i.ToString(), -5}: {group[0].Value, -20} | Position {group[0].Index}"
    );
    i++;
}

// using System.ComponentModel.DataAnnotations;
// using System.Text.RegularExpressions;

// void ExtractPatterns(string input)
// {
//     string emailPattern = @"[a-zA-Z0-9._\-+%]+@[a-zA-Z0-9]+.[a-zA-Z]{2,}";
//     Regex emailRegex = new Regex(emailPattern);
//     MatchCollection allMatches = emailRegex.Matches(input);
//     foreach (Match email in allMatches)
//     {
//         GroupCollection group = email.Groups;
//         Console.WriteLine($"{group[0].Value}");
//     }
// }

// ExtractPatterns("my email is lkasdjfa@gmail.com, yours is kl1j23%-_54@gmail.ruru");
