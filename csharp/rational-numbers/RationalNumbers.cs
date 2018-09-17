using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber, (double)r.Numerator / r.Denominator);
    }
}

public struct RationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public RationalNumber Add(RationalNumber r)
    {
        // (a1 * b2 + a2 * b1) / (b1 * b2)
        return new RationalNumber(Numerator * r.Denominator + r.Numerator * Denominator, Denominator * r.Denominator).Reduce();
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return r1.Add(r2);
    }

    public RationalNumber Sub(RationalNumber r)
    {
        return Add(new RationalNumber(-1 * r.Numerator, r.Denominator));
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return r1.Sub(r2);
    }

    public RationalNumber Mul(RationalNumber r)
    {
        // (a1 * a2) / (b1 * b2)
        return new RationalNumber(Numerator * r.Numerator, Denominator * r.Denominator).Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return r1.Mul(r2);
    }

    public RationalNumber Div(RationalNumber r)
    {
        // `r1 / r2 = (a1 * b2) / (a2 * b1)` if `a2 * b1` is not zero.
        if (r.Numerator * Denominator != 0)
        {
            return new RationalNumber(Numerator * r.Denominator, r.Numerator * Denominator).Reduce();
        }
        else
            throw new Exception("Not permissible division");
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return r1.Div(r2);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));
    }

    public RationalNumber Reduce()
    {
        int num = Numerator;
        int denum = Denominator;

        if (num == 0)
        {
            return new RationalNumber(0, 1);
        }
        if ((num > 0 && denum < 0) || (num < 0 && denum < 0))
        {
            num *= -1;
            denum *= -1;
        }

        int gcd = GCD(num, denum);
        return new RationalNumber(num / gcd, denum / gcd);
    }

    public RationalNumber Exprational(int power)
    {
        // Exponentiation of a rational number `r = a/b` to a non-negative integer power `n` is `r^n = (a^n)/(b^n)`
        power = Math.Abs(power);
        return new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power));
    }

    public double Expreal(int baseNumber)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    private int GCD(int m, int n)
    {
        m = Math.Abs(m);

        if (m == 0)
            return n;
        if (n == 0)
            return m;
        if (m == n)
            return m;
        if (n == 1 || m == 1)
            return 1;

        if (m % 2 == 0 && n % 2 == 0)
            return 2 * GCD(m / 2, n / 2);
        if (m % 2 == 0 && n % 2 != 0)
            return GCD(m / 2, n);
        if (m % 2 != 0 && n % 2 == 0)
            return GCD(m, n / 2);
        if (m % 2 != 0 && n % 2 != 0)
            if (n > m)
                return GCD((n - m) / 2, m);
            else
                return GCD((m - n) / 2, n);

        throw new Exception("Problem in GCD algorithm");
    }
}