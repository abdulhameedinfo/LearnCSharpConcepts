// High Order Function
public static class HOF
{
    public static Func<int, int, int> devide = (t1, t2) => t1 / t2;

    // High order function to swap the arguments 

    public static Func<typeParam2, typeParam1, returnType> SwapHOC<typeParam1, typeParam2, returnType>(this Func<typeParam1, typeParam2, returnType> f)
        => (typeParam1, typeParam2) => f(typeParam2, typeParam1);

}