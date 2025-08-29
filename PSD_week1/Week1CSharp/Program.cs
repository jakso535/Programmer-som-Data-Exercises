
public abstract class Expr
{
    public override string ToString()
    {
        //return 
    }
}

public class CstI : Expr
{
    
}

public class Var : Expr
{

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


