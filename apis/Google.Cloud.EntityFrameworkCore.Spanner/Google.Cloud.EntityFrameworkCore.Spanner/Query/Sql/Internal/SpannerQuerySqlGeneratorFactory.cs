// Copyright 2017 Google Inc. All Rights Reserved.
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

using Google.Api.Gax;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace Microsoft.EntityFrameworkCore.Query.Sql.Internal
{
    /// <summary>
    /// This is internal functionality and not intended for public use.
    /// </summary>
    public class SpannerQuerySqlGeneratorFactory : QuerySqlGeneratorFactoryBase
    {
        /// <summary>
        /// This is internal functionality and not intended for public use.
        /// </summary>
        public SpannerQuerySqlGeneratorFactory(
            QuerySqlGeneratorDependencies dependencies)
            : base(dependencies)
        {
        }

        /// <inheritdoc />
        public override IQuerySqlGenerator CreateDefault(SelectExpression selectExpression)
            => new SpannerQuerySqlGenerator(
                Dependencies,
                GaxPreconditions.CheckNotNull(selectExpression, nameof(selectExpression)));
    }
}