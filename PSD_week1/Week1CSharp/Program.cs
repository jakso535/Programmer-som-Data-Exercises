using System.Collections.Generic;
public abstract class Expr
{
    public abstract int Eval(Dictionary<string, int> env);
    public override string ToString()
    {
        
    }
}

public class CstI : Expr
{
    protected int i;
    
    public override int Eval(Dictionary<string,int> env) {
        return i;
    }
    
}

public class Var : Expr
{
    protected string name;
    
    public override int Eval(Dictionary<string,int> env) {
        return env.ContainsKey(name) ? env[name] : 0;
    }

}

public abstract class Binop : Expr
{

}

public class Add : Binop
{

}

public class Mul : Binop
{

}

public class Sub : Binop
{

}

public class AccessExample
{
    public static void Main(string[] args)
    {
        Object[] env = [("a", 3), ("c", 78), ("baf", 666), ("b", 111)];
        Console.WriteLine("Hello World!");
    }
}


