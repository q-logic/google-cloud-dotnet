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

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using Xunit;

namespace Google.Cloud.EntityFrameworkCore.Spanner.IntegrationTests
{
#pragma warning disable xUnit1000 // Test classes must be public
    /// <summary>
    /// TODO: implement tests for Spanner
    /// </summary>
    internal class OptimisticConcurrencySpannerTest : OptimisticConcurrencyTestBase<SpannerTestStore, F1SpannerFixture>
#pragma warning restore xUnit1000 // Test classes must be public
    {
        public OptimisticConcurrencySpannerTest(F1SpannerFixture fixture) : base(fixture)
        {
        }

        protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
            => facade.UseTransaction(transaction.GetDbTransaction());

        [Fact]
        public async Task Modifying_concurrency_token_only_is_noop()
        {
            using (var c = CreateF1Context())
            {
                await c.Database.CreateExecutionStrategy().ExecuteAsync(c, async context =>
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var driver = context.Drivers.Single(d => d.CarNumber == 1);
                        Assert.NotEqual(1u, context.Entry(driver).Property<uint>("xmin").CurrentValue);
                        driver.Podiums = StorePodiums;
                        var firstVersion = context.Entry(driver).Property<uint>("xmin").CurrentValue;
                        await context.SaveChangesAsync();

                        using (var innerContext = CreateF1Context())
                        {
                            innerContext.Database.UseTransaction(transaction.GetDbTransaction());
                            driver = innerContext.Drivers.Single(d => d.CarNumber == 1);
                            Assert.NotEqual(firstVersion,
                                innerContext.Entry(driver).Property<uint>("xmin").CurrentValue);
                            Assert.Equal(StorePodiums, driver.Podiums);

                            var secondVersion = innerContext.Entry(driver).Property<uint>("xmin").CurrentValue;
                            innerContext.Entry(driver).Property<uint>("xmin").CurrentValue = firstVersion;
                            await innerContext.SaveChangesAsync();
                            using (var validationContext = CreateF1Context())
                            {
                                validationContext.Database.UseTransaction(transaction.GetDbTransaction());
                                driver = validationContext.Drivers.Single(d => d.CarNumber == 1);
                                Assert.Equal(secondVersion,
                                    validationContext.Entry(driver).Property<uint>("xmin").CurrentValue);
                                Assert.Equal(StorePodiums, driver.Podiums);
                            }
                        }
                    }
                });
            }
        }
    }
}