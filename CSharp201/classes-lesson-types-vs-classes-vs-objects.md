# Lesson: Types vs Classes vs Objects

## Metadata

This element is current as of January 2024.

## Quote

"A computer once beat me at chess, but it was no match for me at kick boxing." 

- Emo Philips

## Introduction

Before starting our object-oriented programming journey, we must step back and discuss some terminology and concepts. A learner must use the same technical terms that professional developers use to work together effectively.

It's important to know the difference between "type," "class," and "object" when learning to program. Experienced programmers sometimes use these words in ways that can be confusing for beginners. They understand each other because of their experience, but if you're just starting, you might need some extra explanation to catch the differences.

This lesson will discuss the differences with examples and introduce a professional programming paradigm: The Single Responsibility Principle.

## Learning Outcomes

By the end of this lesson, you should be able to:

1. Describe the relationship between types, classes, and objects.
2. Define the Single Responsibility Principle and describe how it relates to classes and types.

## What is a Type?

A type is a definition that tells us (and the compiler) what data and behaviors are available in our code.

<!--Image: Stock Image of a blueprint of an office space.--> 

You can think of a type as a blueprint. A type definition in C# strictly defines how to build an object, just as a blueprint strictly defines how to build a structure like a house or an office building.

We frequently use the general terms data and behaviors, but in C#, when referring to the data and behaviors of a type collectively, we refer to them as members. This is because the data and behavior definitions belong to a type like club members. Consider this code that we have frequently used.

<!--Was an image in articulate: Caption - The Console type invoking its WriteLine() method member.-->

```c#
Console.WriteLine();
```

In formal language, we would say that WriteLine() is a member of the Console type. The dot syntax in C# enables us to access an object's members. The type definition is what is used to validate our code. The compiler does this by raising **syntax errors** when we misspell or misuse a type or its member. 

We know from our fundamentals that if we incorrectly type a member name like WriteLine(), we will get an error, and our code will not run. The compiler checks everything we write in code against the type definition.

Another way type definitions validate code is by checking compatibility. This is why you cannot directly store a string in an integer variable. You have to parse or convert the data into a compatible type. If a type does not contain specific instructions for converting to another type, they cannot be automatically used together.

## What is a Class?

A class is the most common way to create a type definition. In the base class library or BCL, we have many built-in types like Console, Random, int, and string. But, when we write our applications, we will need a way to organize the data and behaviors that are specific to what we need.

For example, suppose we were creating a banking application. In that case, we might create a class named Account to store data like the account number, owner, current balance, and behaviors like deposit, withdraw, etc. To create a class in C#, we use the class keyword and provide the name of the type like so:

```c#
class Account
{
	// Members go in the code block
	// ex: balance, deposit(), withdraw(), etc.

}
```

<!--Caption: The class keyword used to create an Account Type Definition-->

Then we could define all the data, like the balance, owner, and so forth, and the behavior, like deposit, withdraw, and other members inside the class code block. At its simplest, a class is just a code block with a name that defines the members of a type.

Class is the most common way to create a type definition. You can also define types using keywords like struct, enum, record, and interface. We will cover these keywords later because 'class' will be the keyword you will use most of the time when building an application. It is important to mention them now to emphasize a key point: a class is only one way to define a type definition.

**A class is only one way to define a type definition!**

Because class is the most common way to create a type definition, developers use the word class instead of the word type, even if that's not the correct language. Because of its common use, a type in code we refer to is likely defined as a class, but that is not always the case.

## The Single Responsibility Principle (SRP)

The introduction of classes can fill a beginner's mind with questions like

- When should we define a class?

- How many classes do we need?
- How do I decide how to organize my data and behaviors effectively?

This is where as experienced professionals, we get excited because now we are introducing the artistic part of software development. Over time, professionals have embraced key principles and concepts that help make our code better organized and easier to maintain and extend.

The first of these concepts we want to introduce is the Single Responsibility Principle, or SRP for short. The key idea of this principle is that each type should have only one responsibility, and we should not mix code with unrelated tasks inside the same type definition. By responsibilities, we generally talk about broader tasks that our applications perform. As an example, if we were building an online store application, some of the responsibilities we might need to handle are:

<!--Image: An online storefront-->

- Authentication - Logging in and out.
- User Account Management - Letting users update their profile information.
- Inventory - What products we have for sale, how much they cost, how much stock is available, etc.
- Search - Helping users find the products they're seeking.
- Shopping Cart - To hold orders in progress.
- Billing - To pay for orders.
- Shipping - To send orders to customers.

Each of these functionalities can be encapsulated within its class in C#. For instance, we can have an 'Authentication' class responsible for user logins and logouts, an 'UserAccount' class for managing user profiles, and so forth. This way, we're adhering to the Single Responsibility Principle. 

In real-world applications, we might want to break down these responsibilities further. For example, the 'Billing' class could be split into 'CreditCardPayment', 'PaypalPayment', and 'BankTransferPayment' classes. 

The more unrelated responsibilities you stuff into a single place, the more opportunities you have to break things when you make code changes.

<!--Image: Pile of working tools.-->

**Organizationally it is much harder for other developers to locate code if it's all mixed together like a pile on your floor. It's much easier to find your tools if they are neatly organized into the drawers of a tool chest.**

Mastering the art of good organization is an essential skill for professional developers. Nothing technically stops you from writing all of your code into one giant class, creating what is known as a '**god class**'. Much like a Swiss Army knife, a god class tries to do everything, leading to complex and hard-to-maintain code. This is similar to what we've been doing so far, putting all our solution code into a single file. If we continue this way, our code will become unwieldy and hard to navigate, like trying to use a multi-tool for every job.

Experienced developers value organization, striving to encapsulate neatly arranged, related functionalities within their classes. SRP is a principle you'll hone and improve over time. Much like appreciating a well-crafted piece of art, describing the beauty of a well-organized class can be challenging, but you'll recognize it when you see it!

There is an old joke about SRP: if you ask ten developers how to organize some code, you'll get eleven answers. In this course, we aim to teach you not a single 'correct' way to structure your code but to think carefully about how you're organizing your code and continually improve your techniques over time. Remember, it's an ongoing process, and each step you take brings you closer to mastering this essential skill.

## How do Objects Relate?

Let's explore the relationship between objects and types.

Keeping with our blueprint metaphor of a type, an object is a specific instance of that blueprint created in your application's memory. Despite sharing the same type definition, each object can be unique. Let's illustrate this with an example:

```c#
int a = 5;
int b = 10;
int c = 5;
```

<!--Caption: Declaring 3 integer variables. Each variable holds an object instance of type int.-->

Here, we declare three integer values: a, b, and c. Although a and c have the same value of 5, they are two distinct objects. They all share the same type definition—integer—but we have three separate integer objects. 

When you create an object instance from a type definition, it comes with its state. In programming, '**state**' refers to the data an object holds at a specific moment. Let's revisit our account example:

```c#
Account a = new Account();
a.Owner = "John";
a.Balance = 100M;

Account b = new Account();
b.Owner = "Mary";
b.Balance = 300M;
```

<!--Caption: Two account objects instantiated with the new keyword, each with their own state.-->

In C#, the 'new' keyword indicates the creation of a new instance of an object, a process known as **instantiation**. After instantiation, you can access and manipulate the members of that object by using the dot syntax. Each object instance maintains its data or state. 

In the sample code, 'owner' and 'balance' are our hypothetical Account type members. Executing this code creates two distinct Account objects, 'a' and 'b'. Even though they both are of the Account type, they will each have their state, holding their unique data. And it's a good thing too! Imagine a banking application that didn't keep account states separate – that would be less of a bank and more of a financial free-for-all!

### Interactive: Matching

- Class - Common way to create a type definition. It's a code block with a name that defines members.
- Type - A definition that specifies the data and behaviors available in code.
- Object - A specific instance of a type, created in the application's memory.
