﻿// Copyright 2017 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Google.Cloud.EntityFrameworkCore.Spanner.IntegrationTests
{
    public class BuiltInDataTypesSpannerTest : BuiltInDataTypesTestBase<BuiltInDataTypesSpannerFixture>
    {
        public BuiltInDataTypesSpannerTest(BuiltInDataTypesSpannerFixture fixture)
            : base(fixture)
        {
        }

        [Fact(Skip = "unknown")]
        public virtual void Can_insert_and_read_back_all_mapped_data_types()
        {
            using (var context = CreateContext())
            {
                context.Set<MappedDataTypes>().Add(
                    new MappedDataTypes
                    {
                        Tinyint = 80,
                        Smallint = 79,
                        Int = 77,
                        Bigint = 78L,
                        Real = 84.4f,
                        Double_precision = 85.5,
                        Decimal = 101.1m,
                        Numeric = 103.3m,

                        Text = "Gumball Rules!",
                        Bytea = new byte[] {86},

                        Timestamp = new DateTime(2016, 1, 2, 11, 11, 12),
                        //Timestamptz = new DateTime(2016, 1, 2, 11, 11, 12, DateTimeKind.Utc),
                        Date = new DateTime(2015, 1, 2, 10, 11, 12),
                        Time = new TimeSpan(11, 15, 12),
                        //Timetz = new DateTimeOffset(0, 0, 0, 12, 0, 0, TimeSpan.FromHours(2)),
                        Interval = new TimeSpan(11, 15, 12),

                        Uuid = new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11"),
                        Bool = true,

                        Jsonb = @"{""a"": ""b""}",
                        Hstore = new Dictionary<string, string> {{"a", "b"}},

                        //SomeComposite = new SomeComposite { SomeNumber = 8, SomeText = "foo" }
                        PrimitiveArray = new[] {2, 3},
                        NonPrimitiveArray = new[]
                            {PhysicalAddress.Parse("08-00-2B-01-02-03"), PhysicalAddress.Parse("08-00-2B-01-02-04")},

                        Xid = (uint) int.MaxValue + 1
                    });

                Assert.Equal(1, context.SaveChanges());
            }

            using (var context = CreateContext())
            {
                var connString = context.Database.GetDbConnection().ConnectionString;
                var entity = context.Set<MappedDataTypes>().Single(e => e.Int == 77);

                Assert.Equal(80, entity.Tinyint);
                Assert.Equal(79, entity.Smallint);
                Assert.Equal(77, entity.Int);
                Assert.Equal(78, entity.Bigint);
                Assert.Equal(84.4f, entity.Real);
                Assert.Equal(85.5, entity.Double_precision);
                Assert.Equal(101.1m, entity.Decimal);
                Assert.Equal(103.3m, entity.Numeric);

                Assert.Equal("Gumball Rules!", entity.Text);
                Assert.Equal(new byte[] {86}, entity.Bytea);

                Assert.Equal(new DateTime(2016, 1, 2, 11, 11, 12), entity.Timestamp);
                //Assert.Equal(new DateTime(2016, 1, 2, 11, 11, 12), entity.Timestamptz);
                Assert.Equal(new DateTime(2015, 1, 2, 0, 0, 0), entity.Date);
                Assert.Equal(new TimeSpan(11, 15, 12), entity.Time);
                //Assert.Equal(new DateTimeOffset(0, 0, 0, 12, 0, 0, TimeSpan.FromHours(2)), entity.Timetz);
                Assert.Equal(new TimeSpan(11, 15, 12), entity.Interval);

                Assert.Equal(new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11"), entity.Uuid);
                Assert.True(entity.Bool);

                Assert.Equal(@"{""a"": ""b""}", entity.Jsonb);
                Assert.Equal(new Dictionary<string, string> {{"a", "b"}}, entity.Hstore);

                //Assert.Equal(new SomeComposite { SomeNumber = 8, SomeText = "foo" }, entity.SomeComposite);
                Assert.Equal(new[] {2, 3}, entity.PrimitiveArray);
                Assert.Equal(
                    new[] {PhysicalAddress.Parse("08-00-2B-01-02-03"), PhysicalAddress.Parse("08-00-2B-01-02-04")},
                    entity.NonPrimitiveArray);
                Assert.Equal((uint) int.MaxValue + 1, entity.Xid);
            }
        }

        [Fact(Skip = "unknown")]
        public virtual void Can_insert_and_read_back_all_mapped_data_types_set_to_null()
        {
            using (var context = CreateContext())
            {
                context.Set<MappedNullableDataTypes>().Add(
                    new MappedNullableDataTypes
                    {
                        Int = 78
                    });

                Assert.Equal(1, context.SaveChanges());
            }

            using (var context = CreateContext())
            {
                var entity = context.Set<MappedNullableDataTypes>().Single(e => e.Int == 78);

                Assert.Null(entity.Tinyint);
                Assert.Null(entity.Smallint);
                Assert.Null(entity.Bigint);
                Assert.Null(entity.Real);
                Assert.Null(entity.Double_precision);
                Assert.Null(entity.Decimal);
                Assert.Null(entity.Numeric);

                Assert.Null(entity.Text);
                Assert.Null(entity.Bytea);

                Assert.Null(entity.Timestamp);
                Assert.Null(entity.Timestamptz);
                Assert.Null(entity.Date);
                Assert.Null(entity.Time);
                Assert.Null(entity.Timetz);
                Assert.Null(entity.Interval);

                Assert.Null(entity.Uuid);
                Assert.Null(entity.Bool);

                Assert.Null(entity.Jsonb);
                Assert.Null(entity.Hstore);

                //Assert.Null(entity.SomeComposite);
                Assert.Null(entity.PrimitiveArray);
                Assert.Null(entity.NonPrimitiveArray);
                Assert.Null(entity.Xid);
            }
        }

        [Fact(Skip = "unknown")]
        public virtual void Can_insert_and_read_back_all_mapped_nullable_data_types()
        {
            using (var context = CreateContext())
            {
                context.Set<MappedNullableDataTypes>().Add(
                    new MappedNullableDataTypes
                    {
                        Tinyint = 80,
                        Smallint = 79,
                        Int = 77,
                        Bigint = 78L,
                        Real = 84.4f,
                        Double_precision = 85.5,
                        Decimal = 101.1m,
                        Numeric = 103.3m,

                        Text = "Gumball Rules!",
                        Bytea = new byte[] {86},

                        Timestamp = new DateTime(2016, 1, 2, 11, 11, 12),
                        //Timestamptz = new DateTime(2016, 1, 2, 11, 11, 12, DateTimeKind.Utc),
                        Date = new DateTime(2015, 1, 2, 10, 11, 12),
                        Time = new TimeSpan(11, 15, 12),
                        //Timetz = new DateTimeOffset(0, 0, 0, 12, 0, 0, TimeSpan.FromHours(2)),
                        Interval = new TimeSpan(11, 15, 12),

                        Uuid = new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11"),
                        Bool = true,

                        Jsonb = @"{""a"": ""b""}",
                        Hstore = new Dictionary<string, string> {{"a", "b"}},

                        //SomeComposite = new SomeComposite { SomeNumber = 8, SomeText = "foo" }
                        PrimitiveArray = new[] {2, 3},
                        NonPrimitiveArray = new[]
                            {PhysicalAddress.Parse("08-00-2B-01-02-03"), PhysicalAddress.Parse("08-00-2B-01-02-04")},
                        Xid = (uint) int.MaxValue + 1
                    });

                Assert.Equal(1, context.SaveChanges());
            }

            using (var context = CreateContext())
            {
                var entity = context.Set<MappedNullableDataTypes>().Single(e => e.Int == 77);

                Assert.Equal(80, entity.Tinyint.Value);
                Assert.Equal(79, entity.Smallint.Value);
                Assert.Equal(77, entity.Int);
                Assert.Equal(78, entity.Bigint);
                Assert.Equal(84.4f, entity.Real);
                Assert.Equal(85.5, entity.Double_precision);
                Assert.Equal(101.1m, entity.Decimal);
                Assert.Equal(103.3m, entity.Numeric);

                Assert.Equal("Gumball Rules!", entity.Text);
                Assert.Equal(new byte[] {86}, entity.Bytea);

                Assert.Equal(new DateTime(2016, 1, 2, 11, 11, 12), entity.Timestamp);
                //Assert.Equal(new DateTime(2016, 1, 2, 11, 11, 12), entity.Timestamptz);
                Assert.Equal(new DateTime(2015, 1, 2, 0, 0, 0), entity.Date);
                Assert.Equal(new TimeSpan(11, 15, 12), entity.Time);
                //Assert.Equal(new DateTimeOffset(0, 0, 0, 12, 0, 0, TimeSpan.FromHours(2)), entity.Timetz);
                Assert.Equal(new TimeSpan(11, 15, 12), entity.Interval);

                Assert.Equal(new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11"), entity.Uuid);
                Assert.True(entity.Bool);

                Assert.Equal(@"{""a"": ""b""}", entity.Jsonb);
                Assert.Equal(new Dictionary<string, string> {{"a", "b"}}, entity.Hstore);

                //Assert.Equal(new SomeComposite { SomeNumber = 8, SomeText = "foo" }, entity.SomeComposite);

                Assert.Equal(new[] {2, 3}, entity.PrimitiveArray);
                Assert.Equal(
                    new[] {PhysicalAddress.Parse("08-00-2B-01-02-03"), PhysicalAddress.Parse("08-00-2B-01-02-04")},
                    entity.NonPrimitiveArray);
                Assert.Equal((uint) int.MaxValue + 1, entity.Xid);
            }
        }

        [Fact(Skip = "unknown")]
        public override void Can_insert_and_read_back_all_non_nullable_data_types()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_non_null()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_insert_and_read_back_all_nullable_data_types_with_values_set_to_null()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_insert_and_read_back_with_binary_key()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_insert_and_read_back_with_null_binary_foreign_key()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_insert_and_read_back_with_null_string_foreign_key()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_insert_and_read_back_with_string_key()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_insert_and_read_with_max_length_set()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_perform_query_with_max_length()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_query_using_any_data_type()
        {
        }

        [Fact(Skip = "unknown")]
        public virtual void Can_query_using_any_mapped_data_type()
        {
            using (var context = CreateContext())
            {
                context.Set<MappedNullableDataTypes>().Add(
                    new MappedNullableDataTypes
                    {
                        Tinyint = 80,
                        Smallint = 79,
                        Int = 999,
                        Bigint = 78L,
                        Real = 84.4f,
                        Double_precision = 85.5,
                        Decimal = 101.7m,
                        Numeric = 103.9m,

                        Text = "Gumball Rules!",
                        Bytea = new byte[] {86},

                        Timestamp = new DateTime(2015, 1, 2, 10, 11, 12),
                        //Timestamptz = new DateTime(2016, 1, 2, 11, 11, 12, DateTimeKind.Utc),
                        Date = new DateTime(2015, 1, 2, 0, 0, 0),
                        Time = new TimeSpan(11, 15, 12),
                        //Timetz = new DateTimeOffset(0, 0, 0, 12, 0, 0, TimeSpan.FromHours(2)),
                        Interval = new TimeSpan(11, 15, 12),

                        Uuid = new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11"),
                        Bool = true,

                        Jsonb = @"{""a"": ""b""}",
                        Hstore = new Dictionary<string, string> {{"a", "b"}},

                        PrimitiveArray = new[] {2, 3},
                        NonPrimitiveArray = new[]
                            {PhysicalAddress.Parse("08-00-2B-01-02-03"), PhysicalAddress.Parse("08-00-2B-01-02-04")},

                        Xid = (uint) int.MaxValue + 1
                    });

                Assert.Equal(1, context.SaveChanges());
            }

            using (var context = CreateContext())
            {
                var entity = context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999);

                byte? param1 = 80;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Tinyint == param1));

                short? param2 = 79;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Smallint == param2));

                long? param3 = 78L;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Bigint == param3));

                float? param4 = 84.4f;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Real == param4));

                double? param5 = 85.5;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Double_precision == param5));

                decimal? param6 = 101.7m;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Decimal == param6));

                decimal? param7 = 103.9m;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Numeric == param7));

                var param8 = "Gumball Rules!";
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Text == param8));

                var param9 = new byte[] {86};
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Bytea == param9));

                DateTime? param10 = new DateTime(2015, 1, 2, 10, 11, 12);
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Timestamp == param10));

                //DateTime? param11 = new DateTime(2019, 1, 2, 14, 11, 12, DateTimeKind.Utc);
                //Assert.Same(entity, context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Timestamptz == param11));

                DateTime? param12 = new DateTime(2015, 1, 2, 0, 0, 0);
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Date == param12));

                TimeSpan? param13 = new TimeSpan(11, 15, 12);
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Time == param13));

                //DateTimeOffset? param14 = new DateTimeOffset(0, 0, 0, 12, 0, 0, TimeSpan.FromHours(2));
                //Assert.Same(entity, context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Timetz == param14));

                TimeSpan? param15 = new TimeSpan(11, 15, 12);
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Interval == param15));

                Guid? param16 = new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11");
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Uuid == param16));

                bool? param17 = true;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Bool == param17));

                var param20 = @"{""a"": ""b""}";
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Jsonb == param20));

                var param21 = new Dictionary<string, string> {{"a", "b"}};
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Hstore == param21));

                var param23 = new[] {2, 3};
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.PrimitiveArray == param23));

                var param24 = new[]
                    {PhysicalAddress.Parse("08-00-2B-01-02-03"), PhysicalAddress.Parse("08-00-2B-01-02-04")};
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.NonPrimitiveArray == param24));

                var param25 = (uint) int.MaxValue + 1;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 999 && e.Xid == param25));
            }
        }

        [Fact(Skip = "unknown")]
        public virtual void Can_query_using_any_mapped_data_types_with_nulls()
        {
            using (var context = CreateContext())
            {
                context.Set<MappedNullableDataTypes>().Add(
                    new MappedNullableDataTypes
                    {
                        Int = 911
                    });

                Assert.Equal(1, context.SaveChanges());
            }

            using (var context = CreateContext())
            {
                var entity = context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911);

                byte? param1 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Bigint == param1));

                short? param2 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Smallint == param2));

                long? param3 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Bigint == param3));

                float? param4 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Real == param4));

                double? param5 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Double_precision == param5));

                decimal? param6 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Decimal == param6));

                decimal? param7 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Numeric == param7));

                string param8 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Text == param8));

                byte[] param9 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Bytea == param9));

                DateTime? param10 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Timestamp == param10));

                DateTime? param11 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Timestamptz == param11));

                DateTime? param12 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Date == param12));

                TimeSpan? param13 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Time == param13));

                DateTimeOffset? param14 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Timetz == param14));

                TimeSpan? param15 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Interval == param15));

                Guid? param16 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Uuid == param16));

                bool? param17 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Bool == param17));

                string param20 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Jsonb == param20));

                Dictionary<string, string> param21 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Hstore == param21));

                int[] param23 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.PrimitiveArray == param23));

                PhysicalAddress[] param24 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.NonPrimitiveArray == param24));

                uint? param25 = null;
                Assert.Same(entity,
                    context.Set<MappedNullableDataTypes>().Single(e => e.Int == 911 && e.Xid == param25));
            }
        }

        [Fact(Skip = "unknown")]
        public override void Can_query_using_any_nullable_data_type()
        {
        }

        [Fact(Skip = "unknown")]
        public override void Can_query_with_null_parameters_using_any_nullable_data_type()
        {
        }

        // TODO: Other tests from original?
    }
}