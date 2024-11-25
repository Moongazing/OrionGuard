# OrionGuard

OrionGuard is a lightweight and extensible library for guarding your application's parameters, ensuring input validation, and throwing meaningful exceptions. This library is ideal for developers who want to improve code quality and enforce input validation consistently.

---

## **Features**

- 🛡️ **Guard Clauses** for common scenarios:
  - Null and Empty String Validation
  - Range Checks for Numeric Values
  - Enum Value Validation
  - Regex Pattern Matching
  - Date Validation (Future/Past Dates)
  - Email Address Validation
- 🚀 Easy to use and highly extensible.
- ✅ Fully unit-tested and ready for production.

---

## **Installation**

OrionGuard is available as a NuGet package. You can install it using the .NET CLI or Package Manager in Visual Studio.

### **Using .NET CLI**


dotnet add package OrionGuard


### **Using Package Manager**

Install-Package OrionGuard


Getting Started
1. Null Check

Guard.AgainstNull(testObject, nameof(testObject));
// Throws NullValueException if testObject is null.

2. Range Check

Guard.AgainstOutOfRange(5, 1, 10, nameof(value));
// Throws OutOfRangeException if value is outside the range.

3. Regex Validation

"abc123".AgainstRegexMismatch(@"^\d+$", nameof(value));
// Throws RegexMismatchException if value does not match the pattern.

4. Email Validation

"example.com".AgainstInvalidEmail(nameof(email));
// Throws InvalidEmailException if the email is invalid.

Extensibility

You can define custom guard clauses by implementing the IGuardClause interface:

public class MyCustomGuard : IGuardClause
{
    public void Validate()
    {
        // Custom validation logic
    }
}

Contributing

We welcome contributions! To contribute:

    Fork the repository on GitHub.
    Create a new branch for your feature or bug fix.
    Submit a pull request.

License

OrionGuard is licensed under the MIT License. You are free to use, modify, and distribute this library under the terms of the license.


Support

If you encounter any issues or have questions, please visit the GitHub Issues page or contact us at tunahan.ali.ozturk@outlook.com.

