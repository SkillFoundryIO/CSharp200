# Exercise: TDD with the String Calculator Kata

The string calculator kata is a coding exercise specifically designed to allow developers to practice test driven development (TDD). This means that before we write any code, we first write a test to express the behavior we want. That test will start off in a failing state and then we write the minimum amount of code necessary to make it pass.

We need to give full credit where credit is due, this kata was created by [Roy Osherove](https://osherove.com/tdd-kata-1), a well-known developer and consultant. Here is the link to his site which also has solutions to the kata. Because of this, I will not be providing a solution video, but I will demonstrate how to get started and some extra advice and commentary.

For this project, feel free to combine your unit tests and code into a single console application.

## Kata Rules

To do this kata correctly, you need to follow some rules:

1. You must write a failing test before writing any code.
2. You should not read ahead, tasks should be done sequentially, since this also demonstrates how to refactor and extend code using TDD.
3. Naturally, this means only do one task at a time.
4. You only need to test for correct inputs, this exercise is more about the journey than it is about input sanitation.

## Instructions

We start with a class named StringCalculator with one method:

```c#
public class StringCalculator
{
    public int Add(string numbers)
    {
        
    }
}
```

### Getting Started (Task 1)

*See the provided video for how to get started through task 1, then try to complete the rest of the tasks on your own.*

The method should be able to receive up to two numbers, separated by commas, and will return their sum.

- An empty string "" will return 0
- A single number "1" will return the number (1).
- Two numbers, ex: "1,2" will return the sum (3).

We should start with the simplest test (empty string) and move on to one and two numbers. We should always write the simplest code possible to pass the test then refactor once it's working.

TDD developers have a saying: "Red, Green Refactor" that reinforces this workflow. Failing test followed by passing test following by cleaning up your code.

### Remaining Tasks

Here are the rest of the tasks. You can stop at task 5 as a beginner, but if you want a challenge keep going!

1. Allow the Add method to handle an unknown amount of numbers.

2. Allow the Add method to handle new lines between numbers (instead of commas).
   - The following input is ok: "1\\n2,3" (will equal 6).
   - The following input is NOT ok: "1,\\n" (no need to prove it - just clarifying).

3. Support different delimiters:
   - To change a delimiter, the beginning of the string will contain a separate line that looks like this: "//[delimiter]\\n[numbers…]" for example "//;\\n1;2" should return three where the default delimiter is ';'.
   - The first line is optional. all existing scenarios should still be supported.

4. Calling Add with a negative number will throw an exception "negatives not allowed" - and the negative that was passed.
   - If there are multiple negatives, show all of them in the exception message.

5. STOP HERE if you are a beginner. Continue if you can finish the steps so far in less than 30 minutes.

6. Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2.

7. Delimiters can be of any length with the following format: "//[delimiter]\\n" for example: "//[***]\\n1***2***3" should return 6.

8. Allow multiple delimiters like this: "//[delim1]\[delim2]\\n" for example "//[*]\[%]\\n1*2%3" should return 6.

9. Make sure you can also handle multiple delimiters with length longer than one char.