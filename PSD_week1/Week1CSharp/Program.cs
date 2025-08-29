using System.Collections.Generic;
public abstract class Expr
{
    public abstract int Eval(Dictionary<string, int> env);

    public abstract override string ToString();

    public abstract Expr Simplify();
}

public class CstI(int i) : Expr
{
    protected int I = i;

    public int GetValue => I;
    
    public override int Eval(Dictionary<string,int> env) {
        return I;
    }

    public override string ToString() => I.ToString();

    public override Expr Simplify() => this;
}

public class Var (string str) : Expr
{
    protected readonly string Name = str;
    
    public override int Eval(Dictionary<string,int> env) {
        return env.ContainsKey(Name) ? env[Name] : 0;
    }

    public override string ToString() => Name;
    
    public override Expr Simplify() => this;
}

public abstract class Binop(Expr e1, Expr e2) : Expr
{
    protected readonly Expr E1 = e1, E2 = e2;
}

public class Add(Expr e1, Expr e2) : Binop(e1, e2)
{
    public override int Eval(Dictionary<string, int> env)
    {
        return E1.Eval(env) + E2.Eval(env);
    }

    public override string ToString()
    {
        return E1 + " + " + E2;
    }

    public override Expr Simplify()
    {
        var e1 = E1.Simplify();
        var e2 = E2.Simplify();

        if (e1 is CstI c1 && c1.GetValue == 0) return e2;

        if (e2 is CstI c2 && c2.GetValue == 0) return e1;
        
        return new Add(e1, e2);
    }
}

public class Mul(Expr e1, Expr e2) : Binop(e1, e2)
{
    public override int Eval(Dictionary<string, int> env)
    {
        return E1.Eval(env) * E2.Eval(env);
    }

    public override string ToString()
    {
        return "(" + E1 + ")" + " * " + "(" + E2 + ")" ;
    }
    
    public override Expr Simplify()
    {
        var e1 = E1.Simplify();
        var e2 = E2.Simplify();

        if (e1 is CstI c1 && c1.GetValue == 1) return e2;

        if (e2 is CstI c2 && c2.GetValue == 1) return e1;
        
        if (e1 is CstI c3 && c3.GetValue == 0) return new CstI(0);
        
        if (e2 is CstI c4 && c4.GetValue == 0) return new CstI(0);
        
        return new Mul(e1, e2);
    }
}

public class Sub(Expr e1, Expr e2) : Binop(e1, e2)
{
    public override int Eval(Dictionary<string, int> env)
    {
        return E1.Eval(env) - E2.Eval(env);
    }

    public override string ToString()
    {
        return E1 + " - " + E2;
    }
    
    public override Expr Simplify()
    {
        var e1 = E1.Simplify();
        var e2 = E2.Simplify();

        if (e1.Equals(e2)) return new CstI(0);

        if (e2 is CstI c2 && c2.GetValue == 0) return e1;
        
        return new Sub(e1, e2);
    }
}

public class AccessExample
{
    public static void Main(string[] args)
    {
        Expr e1 = new Add(new CstI(17), new Var("z"));
        Expr e2 = new Add(e1, new Var("x"));
        Expr e3 = new Mul(e2, new Var("y"));
        Expr e4 = new Sub(e3, new Var("z"));
        Console.WriteLine(e1);
        Console.WriteLine(e2);
        Console.WriteLine(e3);
        Console.WriteLine(e4);
        Dictionary<string,int> newEnv = new Dictionary<string, int>();
        newEnv.Add("z", 17);
        newEnv.Add("x", 1);
        newEnv.Add("y", 2);
        Console.WriteLine(e4.Eval(newEnv));
        
        Expr zeroPlus = new Add(new CstI(0), new Var("a"));
        Expr plusZero = new Add(new Var("b"), new CstI(0));
        Expr oneTimes = new Mul(new CstI(1), new Var("c"));
        Expr timesOne = new Mul(new Var("d"), new CstI(1));
        Expr zeroTimes = new Mul(new CstI(0), new Var("e"));
        Expr timesZero = new Mul(new Var("f"), new CstI(0));
        Expr minusZero = new Sub(new Var("g"), new CstI(0));
        Expr self = new Add(new Var("h"), new CstI(0));
        Expr minusSelf = new Sub(self, self);

        Expr mega =
            new Sub(
                new Add(
                    new Add(zeroPlus, plusZero),
                    new Add(new Add(oneTimes, timesOne),
                        new Add(new Add(zeroTimes, timesZero), minusZero))
                ),
                new CstI(0)
            );

        var e6 = new Add(mega, minusSelf);
        Console.WriteLine(e6);
        Console.WriteLine(e6.Simplify());
    }
}


