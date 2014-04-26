﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Projac
{
    /// <summary>
    ///     Represents a T-SQL DATETIMEOFFSET parameter value.
    /// </summary>
    public class TSqlDateTimeOffsetValue : ITSqlParameterValue
    {
        private readonly DateTimeOffset _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TSqlDateTimeOffsetValue" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public TSqlDateTimeOffsetValue(DateTimeOffset value)
        {
            _value = value;
        }

        /// <summary>
        ///     Creates a <see cref="SqlParameter" /> instance based on this instance.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>
        ///     A <see cref="SqlParameter" />.
        /// </returns>
        public SqlParameter ToSqlParameter(string parameterName)
        {
            return new SqlParameter(
                parameterName,
                SqlDbType.DateTimeOffset,
                7,
                ParameterDirection.Input,
                false,
                0,
                0,
                "",
                DataRowVersion.Default,
                _value);
        }

        private bool Equals(TSqlDateTimeOffsetValue other)
        {
            return _value == other._value;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TSqlDateTimeOffsetValue) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}