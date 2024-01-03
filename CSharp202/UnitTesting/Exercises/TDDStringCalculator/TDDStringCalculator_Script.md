# Script: TDDStringCalculator

In this video, we're going to walk through the first task of the String Calculator Kata using test-first development. I've already set up a class library project and added the NuGet packages to enable UnitTesting with NUnit. This is a class library project because the nature of this exercise is only about unit testing, so no user interface is required.

With TDD, we always write the failing test first and we should start with the simplest case from our task. I would say that this is the empty string returning zero.

So, what I'm going to do is create my test class, and then add a test method:

```c#
[Test]
public void EmptyStringReturnsZero()
{
    StringCalculator c = new StringCalculator();
    int val = c.Add("");

    Assert.AreEqual(0, val);
}
```

Now, how can I write the code to make this pass? Well, it's only checking for a zero value, so the simplest way to make this work is to return 0 from the method:

```c#
public class StringCalculator
{
    public int Add(string numbers)
    {
	    return 0;
    }
}
```

Ok, now this is where beginners get confused. Yes, I know that this code will not work for the rest of the task. That is not the point. In TDD, we approach things in a very incremental like this because you sometimes end up with a simpler solution than you would if you tried to do multiple things at once.

Trust the process. We run the test, it goes from red to green, and we have an opportunity to refactor. I don't think that's necessary with one line of code, so we move to the next easiest test which I think is that a single number returns the number:

```c#
[Test]
public void SingleNumberReturnsNumber()
{
    StringCalculator c = new StringCalculator();
    int val = c.Add("1");

    Assert.AreEqual(1, val);
}
```

We run our tests, it fails, so now we need to write the code to make both tests pass:

```c#
if(string.IsNullOrEmpty(numbers))
{
    return 0;
}
else
{
    return int.Parse(numbers);
}
```

Both tests are green ,do we want to refactor? Not really, this is pretty simple code. Let's move on to the next test, handling only two numbers. I'm going to show you a trick with NUnit, let's test multiple values using the TestCase attribute:

```c#
[TestCase("1,2", 3)]
[TestCase("3,4", 7)]
public void TwoNumbersReturnsSum(string data, int expected)
{
    StringCalculator c = new StringCalculator();
    int val = c.Add(data);

    Assert.AreEqual(expected, val);
}
```

A method can have multiple attributes and by stacking test cases like this on it we can run a unit test multiple times with different values. The parenthesis in the test case contain parameters to pass to the method. It is typical to have one or more parameters with data to pass to our code and the last value to be the expected result.

In these two cases we are passing string values for the calculator along with the integer expected result.

Once again, we run our tests and the fail, so it's time to make the code work in as simple of a manner as possible. We can use string.split() for this if the parameter contains a comma.

```c#
if(string.IsNullOrEmpty(numbers))
{
    return 0;
}
else if (numbers.IndexOf(',') != -1)
{
    string[] vals = numbers.Split(",");
    return int.Parse(vals[0]) + int.Parse(vals[1]);
}
else
{
    return int.Parse(numbers);
}
```

And this is how we will continue going through the tasks in the kata. Continue adding more test and test cases and continue updating the code throughout. There will be times when you delete some code entirely and replace it with something else, and that's ok, incremental improvements is the goal of TDD.

Remember that it is important to test your code. Many developers are indifferent to whether you use TDD or write your tests after, but you will find that your code will be more testable overall if you use a TDD approach since you cannot write the code without the test.

I recommend you give TDD a try even beyond this exercise and see if it grows on you.