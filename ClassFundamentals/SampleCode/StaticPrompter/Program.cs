using System;
using PromptMethods.UI;

string firstName = Prompter.GetRequiredString("Enter first name: ");
string lastName = Prompter.GetRequiredString("Enter last name: ");

Console.WriteLine($"Name: {lastName}, {firstName}");
