# Net-LogWrapper
Log Wrapper library for .Net projects using NLog

This project is a Wrapper for NLog to avoid make your project dependent to a particular logging library like NLog.

## Usage

You only have to create an instance using the LogFactory class like this.

```
private static readonly Lib.Log.Logger.ILogging logger  = Lib.Log.Logger.LogFactory.GetLogger(typeof(YourClass))
```

Then you can use the interface methods to make your logs.

## Requisites
You will have to include this dll in you project and also NLog dlls. You have a NLog config xml file for example whitch is configured for database and csv files.
