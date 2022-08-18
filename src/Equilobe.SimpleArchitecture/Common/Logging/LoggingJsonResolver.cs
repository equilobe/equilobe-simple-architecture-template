using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Equilobe.SimpleArchitecture.Common.Logging
{
    public class LoggingJsonResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var members = base.GetSerializableMembers(objectType);
            return members.Where(x => !Attribute.IsDefined(x, typeof(SkipLoggingAttribute))).ToList();
        }
    }
}
