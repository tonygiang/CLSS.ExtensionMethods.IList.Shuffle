# CLSS.ExtensionMethods.IList.Shuffle

### Problem

Shuffling a list is a common use case without built-in support in the standard library. A naive and short approach can be done like this:

```
var rng = new System.Random();
var shuffledElements = elements.OrderBy(e => rng.Next());
```

This is the most obvious solution but hides performance costs. It has a time complexity of O(n log n). It forces an allocation of a new collection and does not allow in-place shuffling, thus introducing a space complexity of O(n).

### Solution

`Shuffle` in this package is an implementation of the [Fisher-Yates shuffle algorithm](https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle) for all `IList<T>` types. It is an in-place operation with a time complexity of O(n) and a space complexity of O(1).

```
using CLSS;

var shuffled = new int[] { 0, 1, 2, 3, 4 }.Shuffle(); // { 4, 0, 3, 2, 1 }
```

`Shuffle` returns the source `Ilist<T>` to be friendly to a functional-style call chain. The exact return type will be determined by the invocation syntax of `Shuffle`. With an implicit type invocation, it returns an `IList<T>`. With an explicit type invocation, it returns the original collection type.

```
using CLSS;

var numbers = new int[] { 0, 1, 2, 3, 4 };
numbers.Shuffle(); // returns IList<int>
numbers.Shuffle<int[], int>(); // returns int[];
```

Internally, this package uses and depends on the `DefaultRandom` package in CLSS to save on the allocation of a new `System.Random` instance.

Optionally, `Shuffle` also takes in a `System.Random` of your choosing in case you want a custom-seeded random number generator:

```
using CLSS;

var shuffled = new int[] { 0, 1, 2, 3, 4 }.Shuffle(rng);
```

If you are on .NET 6, you can pass in [`System.Random.Shared`](https://docs.microsoft.com/en-us/dotnet/api/system.random.shared).

**Note**: `Shuffle` works on all types implementing the [`IList<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist-1) interface, *including raw C# array*.

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).