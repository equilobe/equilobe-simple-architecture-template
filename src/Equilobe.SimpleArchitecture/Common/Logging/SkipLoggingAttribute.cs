using System;

namespace Equilobe.SimpleArchitecture.Common.Logging
{
    /// <summary>
    /// A marker interface to skip logging of certain field/properties.
    /// Example where this can be used: skip GDPR info
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SkipLoggingAttribute : Attribute
    {
    }
}
