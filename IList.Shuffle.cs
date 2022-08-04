// A part of the C# Language Syntactic Sugar suite.

using System;
using System.Collections.Generic;

namespace CLSS
{
  public static partial class IListShuffle
  {
    /// <summary>
    /// Shuffles a collection in place using the Fisher-Yates/Knuth algorithm.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="IList{T}"/> to shuffle.
    /// </typeparam>
    /// <typeparam name="TElement">The type of the elements of
    /// <paramref name="source"/>.</typeparam>
    /// <param name="source">The <see cref="IList{T}"/> to shuffle.</param>
    /// <param name="rng">Optional custom-seeded random number generator to use
    /// for the sample rolls.</param>
    /// <returns>The source collection.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is
    /// null.</exception>
    public static T Shuffle<T, TElement>(this T source, Random rng = null)
      where T : IList<TElement>
    {
      if (source == null) throw new ArgumentNullException("source");
      if (rng == null) rng = DefaultRandom.Instance;
      for (int i = 0; i < source.Count - 1; ++i)
      {
        var indexToSwap = rng.Next(i, source.Count);
        var e = source[i];
        source[i] = source[indexToSwap];
        source[indexToSwap] = e;
      }
      return source;
    }

    /// <inheritdoc cref="Shuffle{T, TElement}(T, Random)"/>
    public static IList<TElement> Shuffle<TElement>(this IList<TElement> source,
      Random rng = null)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (rng == null) rng = DefaultRandom.Instance;
      for (int i = 0; i < source.Count - 1; ++i)
      {
        var indexToSwap = rng.Next(i, source.Count);
        var e = source[i];
        source[i] = source[indexToSwap];
        source[indexToSwap] = e;
      }
      return source;
    }
  }
}