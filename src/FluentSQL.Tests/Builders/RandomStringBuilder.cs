using System;
using System.Linq;
using System.Text;

namespace FluentSQL.Tests.Builders
{
    public class RandomStringBuilder : TestDataBuilder<string>
    {
        private static readonly string Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public RandomStringBuilder()
        {
            Random = new Random();

            WithMinimumLength(1);
            WithMaximumLength(Random.Next(2, 10));
        }

        public RandomStringBuilder ThatStartsWithLetter
        {
            get
            {
                StartsWithLetter = true;
                return this;
            }
        }

        private int MinimumLength { get; set; }
        private int MaximumLength { get; set; }
        private Random Random { get; }
        private bool StartsWithLetter { get; set; }

        protected override string OnBuild()
        {
            var stringBuilder = new StringBuilder();
            if (StartsWithLetter)
            {
                stringBuilder.Append(BuildRandomString(Characters.Substring(10), 1));
                MaximumLength--;
            }

            int numberOfCharacters = Random.Next(MinimumLength, MaximumLength);
            stringBuilder.Append(BuildRandomString(Characters, numberOfCharacters));

            return stringBuilder.ToString();
        }

        private string BuildRandomString(string characters, int length)
        {
            char[] value = Enumerable.Range(0, length)
                .Select(x => Random.Next(0, characters.Length))
                .Select(x => characters[x])
                .ToArray();

            return new string(value);
        }

        public RandomStringBuilder WithMinimumLength(int minimumLength)
        {
            MinimumLength = minimumLength;
            return this;
        }

        public RandomStringBuilder WithMaximumLength(int maximumLength)
        {
            MaximumLength = maximumLength;
            return this;
        }
    }
}
