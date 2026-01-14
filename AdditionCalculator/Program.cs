using System.Globalization;

double n1 = 0.0;
double n2 = 0.0;

Console.WriteLine("Type in the first number");
string userInput = Console.ReadLine();
n1 = double.Parse(userInput, CultureInfo.InvariantCulture);

Console.WriteLine("Type in the second number");
userInput = Console.ReadLine();
n2 = double.Parse(userInput, CultureInfo.InvariantCulture);

double sum = Math.Round(n1 + n2, 2);

Console.WriteLine(
    $"Sum {n1.ToString(CultureInfo.InvariantCulture)} + {n2.ToString(CultureInfo.InvariantCulture)} = {sum.ToString(CultureInfo.InvariantCulture)}"
);

// Convert data
string myString = "false";
Console.WriteLine(myString);
bool myBool = Convert.ToBoolean(myString); // myBool = False
float myFloat = 9.23456f;
int myInt = (int)myFloat; //myInt = 9


// ############################################################
//                       PARSE X CONVERT
// ############################################################
// ------------ PARSE ------------
// - accepts only strings as inputs
// - if entry is null, yields an exception
// - used mainly if user is certain that the string is valid

// ------------ CONVERT ------------
// - accepts several types of inputs (object, bool, int etc)
// - returns the standard value (ex: 0)
// - used when data comes from uncertain sources (DB, UI)
