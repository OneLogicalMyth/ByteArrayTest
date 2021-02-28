using ByteArrayTest.Data;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace ByteArrayTest.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApiDbContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets a list of objects!")]
        public IQueryable<MyObject> GetObjects([ScopedService] ApiDbContext context)
        {
            return context.Objects;
        }
    }
}