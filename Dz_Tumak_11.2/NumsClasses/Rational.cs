using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    [DeveloperInfo("Alexey Gabov", "19.01.2025")]
    [DeveloperInfo("Grigory Chopirin", "19.01.2025")]
    public class Rational
    {

        private int numerator;
        private int denominator;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю");
            }

            this.numerator = numerator;
            this.denominator = denominator;
            Simplify();
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        public override string ToString()
        {
            return denominator == 1 ? numerator.ToString() : $"{numerator}/{denominator}";
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.denominator - b.numerator * a.denominator, a.denominator * b.denominator);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Rational(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public static implicit operator float(Rational r)
        {
            return (float)r.numerator / r.denominator;
        }

        public static implicit operator int(Rational r)
        {
            return r.numerator / r.denominator;
        }
    }
}
