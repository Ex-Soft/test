using System;
using DevExpress.Xpo;

namespace TestFilter.Db
{
    [Persistent("TestTable4Types")]
    public class TestTable4Types : XPCustomObject
    {
        public TestTable4Types(Session session) : base(session)
        {}

        [Key(true)]
        public long Id
        {
            get { return GetPropertyValue<long>(nameof(Id)); }
            set { SetPropertyValue(nameof(Id), value); }
        }

        public bool FBool
        {
            get { return GetPropertyValue<bool>(nameof(FBool)); }
            set { SetPropertyValue(nameof(FBool), value); }
        }

        public bool? FBoolNullable
        {
            get { return GetPropertyValue<bool?>(nameof(FBoolNullable)); }
            set { SetPropertyValue(nameof(FBoolNullable), value); }
        }

        public string FString
        {
            get { return GetPropertyValue<string>(nameof(FString)); }
            set { SetPropertyValue(nameof(FString), value); }
        }

        [NonPersistent]
        public string NonPersistentFString => !string.IsNullOrWhiteSpace(FString) ? $"FString = \"{FString}\" (Length = {FString.Length})" : "IsNullOrWhiteSpace";

        public int FInt
        {
            get { return GetPropertyValue<int>(nameof(FInt)); }
            set { SetPropertyValue(nameof(FInt), value); }
        }

        public int? FIntNullable
        {
            get { return GetPropertyValue<int?>(nameof(FIntNullable)); }
            set { SetPropertyValue(nameof(FIntNullable), value); }
        }

        public long FLong
        {
            get { return GetPropertyValue<long>(nameof(FLong)); }
            set { SetPropertyValue(nameof(FLong), value); }
        }

        public long? FLongNullable
        {
            get { return GetPropertyValue<long?>(nameof(FLongNullable)); }
            set { SetPropertyValue(nameof(FLongNullable), value); }
        }

        public double FDouble
        {
            get { return GetPropertyValue<double>(nameof(FDouble)); }
            set { SetPropertyValue(nameof(FDouble), value); }
        }

        public double? FDoubleNullable
        {
            get { return GetPropertyValue<double?>(nameof(FDoubleNullable)); }
            set { SetPropertyValue(nameof(FDoubleNullable), value); }
        }

        public decimal FDecimal
        {
            get { return GetPropertyValue<decimal>(nameof(FDecimal)); }
            set { SetPropertyValue(nameof(FDecimal), value); }
        }

        public decimal? FDecimalNullable
        {
            get { return GetPropertyValue<decimal?>(nameof(FDecimalNullable)); }
            set { SetPropertyValue(nameof(FDecimalNullable), value); }
        }

        public DateTime FDateTime
        {
            get { return GetPropertyValue<DateTime>(nameof(FDateTime)); }
            set { SetPropertyValue(nameof(FDateTime), value); }
        }

        public DateTime? FDateTimeNullable
        {
            get { return GetPropertyValue<DateTime?>(nameof(FDateTimeNullable)); }
            set { SetPropertyValue(nameof(FDateTimeNullable), value); }
        }

        public TimeSpan FTimeSpan
        {
            get { return GetPropertyValue<TimeSpan>(nameof(FTimeSpan)); }
            set { SetPropertyValue(nameof(FTimeSpan), value); }
        }

        public TimeSpan? FTimeSpanNullable
        {
            get { return GetPropertyValue<TimeSpan?>(nameof(FTimeSpanNullable)); }
            set { SetPropertyValue(nameof(FTimeSpanNullable), value); }
        }
    }
}
