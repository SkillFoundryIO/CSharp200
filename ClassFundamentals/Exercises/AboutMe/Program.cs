using System;
using AboutMe;

string fName, lName, status;
DateTime dob;
int age;

fName = Prompter.GetRequiredString("Enter First Name: ");
lName = Prompter.GetRequiredString("Enter Last Name: ");
dob = Prompter.GetPastDate("Enter Date of Birth: ");
age = Prompter.GetIntInRange("Enter Age: ", 1, 120);
status = Prompter.GetMaritalStatus();

Printer.PrintHeader();
Printer.PrintAboutMe(fName, lName, dob, age, status);