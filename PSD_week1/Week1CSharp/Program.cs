using System.Collections.Generic;
public abstract class Expr
{
    public abstract int Eval(Dictionary<string, int> env);

    public abstract override string ToString();

}

public class CstI(int i) : Expr
{
    protected int I = i;

    public override int Eval(Dictionary<string,int> env) {
        return I;
    }

    public override string ToString()
    {
        return I.ToString();
    }
}

public class Var (string str) : Expr
{
    protected readonly string Name = str;
    
    public override int Eval(Dictionary<string,int> env) {
        return env.ContainsKey(Name) ? env[Name] : 0;
    }

    public override string ToString()
    {
        return Name;
    }
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
    }
}


