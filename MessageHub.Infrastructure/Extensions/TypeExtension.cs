namespace MessageHub.Infrastructure.Extensions;

public static class TypeExtension
{
    public static IEnumerable<Type> GetDerivedTypes(this Type type)
    {
        return type.Assembly
            .GetTypes()
            .Where(potentialDerivedType => IsDerivedType(type, potentialDerivedType));
    }

    private static bool IsDerivedType(Type type, Type potentialDerivedType)
        => potentialDerivedType != type
           && type.IsAssignableFrom(potentialDerivedType)
           && !potentialDerivedType.IsAbstract;
}