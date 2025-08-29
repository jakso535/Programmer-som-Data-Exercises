using System.Collections.Generic;
public abstract class Expr
{
    public abstract int Eval(Dictionary<string, int> env);
    /*
     * public override string ToString()
     *  {
        
        }
     */
   
}

public class CstI(int i) : Expr
{
    protected int I = i;

    public override int Eval(Dictionary<string,int> env) {
        return I;
    }
    
}

public class Var (string str) : Expr
{
    protected readonly string Name = str;
    
    public override int Eval(Dictionary<string,int> env) {
        return env.ContainsKey(Name) ? env[Name] : 0;
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
}

public class Mul(Expr e1, Expr e2) : Binop(e1, e2)
{
    public override int Eval(Dictionary<string, int> env)
    {
        return E1.Eval(env) * E2.Eval(env);
    }
}

public class Sub(Expr e1, Expr e2) : Binop(e1, e2)
{
    public override int Eval(Dictionary<string, int> env)
    {
        return E1.Eval(env) - E2.Eval(env);
    }
}

public class AccessExample
{
    public static void Main(string[] args)
    {
        Object[] env = [("a", 3), ("c", 78), ("baf", 666), ("b", 111)];
        Console.WriteLine("Hello World!");
    }
}


