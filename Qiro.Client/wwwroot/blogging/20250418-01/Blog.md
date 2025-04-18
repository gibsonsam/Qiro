# 💡 Modern C# Feature Spotlight: Records & `with` Expressions

When C# 9 landed, it brought with it a breath of fresh air in the form of **Records**. If you've ever found yourself writing boilerplate code for value objects, overriding `Equals`, or mutating objects just a little too much — **Records are here to save the day**.

Today, we’ll explore what Records are, how `with` expressions make them even more powerful, and where they shine in real-world scenarios.

---

## 🚀 What Are Records?

Put simply, **Records are reference types with value-based equality semantics**. They’re designed for immutability, concise syntax, and clean code — perfect for data-centric objects like DTOs or domain events.

Here's a basic example:

```csharp
public record Person(string FirstName, string LastName);

var person1 = new Person("Sam", "Gibson");
var person2 = new Person("Sam", "Gibson");

Console.WriteLine(person1 == person2); // True — compared by value!
```

> In contrast to `class`, `record` compares the *contents* of the object rather than the reference. No need to override `Equals` or `GetHashCode` manually. 🙌

---

## ✨ Modifying with `with` Expressions

Need to update a value on an existing object, but keep the rest the same?

With Records, you don't mutate — you **clone and tweak**.

```csharp
var original = new Person("Sam", "Gibson");

var modified = original with { FirstName = "Samuel" };

Console.WriteLine(modified); // Person { FirstName = Samuel, LastName = Gibson }
```

No messy constructors. No side-effects. Just clean, expressive object updates.

---

## 🧰 Records with Mutable Properties (Yes, You Can)

While immutability is preferred, you can define properties using `init` for one-time settable properties — ideal for configuration models or API contracts.

```csharp
public record Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
}
```

Usage:

```csharp
var apple = new Product { Name = "Apple", Price = 0.50m };
var banana = apple with { Name = "Banana" };

Console.WriteLine(banana); // Product { Name = Banana, Price = 0.50 }
```

> Think of `init` like `set`, but only usable during object initialization or with expressions.

---

## 🔎 Pattern Matching with Records

Records integrate beautifully with C#'s pattern matching features:

```csharp
if (modified is Person { FirstName: "Samuel" })
{
    Console.WriteLine("Hey, Samuel!");
}
```

You can destructure or match deeply nested records cleanly and concisely.

---

## 🧠 Real-World Use Cases

✅ **Immutable domain models** in DDD  
✅ **Event models** for systems using event sourcing  
✅ **API DTOs** where equality matters  
✅ **Configuration objects** in ASP.NET Core apps  
🚫 Avoid for deep inheritance or behavior-rich objects (use `class` instead)

---

## 🛠️ Under the Hood

When you declare a record like this:

```csharp
public record Person(string FirstName, string LastName);
```

The compiler secretly generates:

- A constructor
- Properties with `init` accessors
- `Equals`, `GetHashCode`, and `ToString`
- A `Clone()` method used behind the scenes in `with`

You get all this, *for free*.

---

## 🧪 Try It Yourself

Want to experiment locally? Open a terminal and create a new console app:

```bash
dotnet new console -n RecordDemo
cd RecordDemo
```

Paste this into `Program.cs`:

```csharp
public record Person(string FirstName, string LastName);

var original = new Person("Sam", "Gibson");
var updated = original with { FirstName = "Samuel" };

Console.WriteLine(original); // Person { FirstName = Sam, LastName = Gibson }
Console.WriteLine(updated);  // Person { FirstName = Samuel, LastName = Gibson }
Console.WriteLine(original == updated); // False
```

Then run it:

```bash
dotnet run
```

---

## 🧵 Wrapping Up

C# Records and `with` expressions bring clarity, safety, and elegance to your codebase. They encourage immutability, reduce boilerplate, and make your intentions explicit.

> Next time you’re creating a data model, skip the class — try a `record` instead.

Happy coding! 🎉

---