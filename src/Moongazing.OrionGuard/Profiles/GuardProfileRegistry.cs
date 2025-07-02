namespace Moongazing.OrionGuard.Profiles;

public static class GuardProfileRegistry
{
    private static readonly Dictionary<string, Delegate> _profiles = new();

    public static void Register<T>(string name, Action<T, string> profile)
    {
        _profiles[name] = profile;
    }

    public static void Execute<T>(string name, T value, string parameterName)
    {
        if (_profiles.TryGetValue(name, out var profile) && profile is Action<T, string> typed)
        {
            typed(value, parameterName);
        }
        else
        {
            throw new InvalidOperationException($"No guard profile found with name '{name}' and type '{typeof(T)}'.");
        }
    }
}