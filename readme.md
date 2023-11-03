# Accelerate xUnit library
## Introduction
This library help us to increase the speed for develop unit and integration tests, providing classes for that.  
## How to install
For installing this package, you must execute the following command:  
```
dotnet add package accelerate.testing.xunit
```
## How to use
The first step is create a file called appsettings.json in your project. In this fiel you must include the connections string, application settings, tests settings, tests data or test data filenames, etc.  
After, you must add a class that inherits from Accelerate.Testing.Fixture to your project. In this class, you must expose the properties (services, providers, etc.) that your tests will need.  
``` csharp
public class MyFixture : Fixture
{
    // Declare properties to expose

    protected override OnTestDestroy()
    {
        // Add your code for test end step
        // f.e. clean memory from your services, providers, etc.
    }
    protected override OnTestInit()
    {
        // Add your code for test begin step
        // f.e. initialize your services, providers, etc.
    }
}
```
And the last action is declare your test class.  
``` csharp
public class MyTest : Test<MyFixture>
{
    [Fact]
    public void TestName()
    {
        // Do something
    }
}
```
## Changes history
**Version 6.0.0**
- Changed version to a system based on .NET Core version supported.  
**Version 1.0.0**
- Include base class for tests.  
- Include mixture class for expose services, providers, etc. and do activities at the begining and at the end of each test.  