﻿using BS.Domain.Common.Models;

namespace BS.Domain.Host.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; private set; }

        private HostId(Guid value)
        {
            Value = value;
        }

        public static HostId CreateUnique()
        {
            return new HostId(Guid.NewGuid());
        }

        public static HostId Create(Guid value)
        {
            return new HostId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}