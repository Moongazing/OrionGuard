using Moongazing.OrionGuard.Demo.Models;
using Moongazing.OrionGuard.Demo.Profiles;
using Moongazing.OrionGuard.Demo.Services;
using Moongazing.OrionGuard.Profiles;
using Moongazing.OrionGuard.Core;
using Moongazing.OrionGuard.Extensions;

Console.WriteLine("🔐 OrionGuard Full Demo");

#region 🎯 Real-world usage
GuardProfileRegistry.Register<string>("SafeUsername", CustomProfiles.SafeUsername);

var input = new UserInput
{
    Email = "test@example.com",
    Password = "Test123$",
    Username = "user_01"
};

var registrationService = new RegistrationService();
registrationService.Register(input);
Console.WriteLine("✅ Registration succeeded!");
#endregion

Console.WriteLine("\n---\n");

#region 🧪 Showcase - Built-in Guards

// Guard: Null & Empty
Guard.AgainstNull("test", "testParam");
Guard.AgainstNullOrEmpty("some text", "textParam");

// Guard: Range
Guard.AgainstOutOfRange(25, 18, 60, "age");
// Guard: Numbers
Guard.AgainstNegative(-1,"balance");
Guard.AgainstGreaterThan(100, 100, "score");
Guard.AgainstLessThan(10, 30, "balance");

// Guard: Strings
Guard.AgainstInvalidEmail("\"example@mail.com\".", "email");
Guard.AgainstInvalidUrl("\"https://example.com\"", "url");
StringGuards.AgainstOnlyWhiteSpace("\"     \"", "code");

// Guard: IP / Guid
NetworkGuards.AgainstInvalidIpAddress("\"192.168.1.1\"", "ipAddress");
Guid.NewGuid().ToString().AgainstInvalidGuid("guid");

// Guard: Date
DateTime.Now.AddDays(-1).AgainstPastDate("eventDate");
DateTime.Now.AddDays(1).AgainstFutureDate("startDate");

#endregion

Console.WriteLine("✅ All sample guards passed.");
