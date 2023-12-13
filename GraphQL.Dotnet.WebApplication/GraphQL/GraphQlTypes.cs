
using GraphQL.Dotnet.WebApplication.Model;

namespace GraphQL.Dotnet.WebApplication.GraphQL
{

    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor
                .Field(t => t.Id)
                .Type<IdType>();
            descriptor
                .Field(t => t.Name)
                .Type<StringType>();
            descriptor
                .Field(t => t.Description)
                .Type<StringType>();
        }
    }

    public class CourseType : ObjectType<Course>
    {
        protected override void Configure(IObjectTypeDescriptor<Course> descriptor)
        {
            descriptor
               .Field(t => t.Id)
               .Type<IdType>();
            descriptor
                .Field(t => t.Name)
                .Type<StringType>();
            descriptor
                .Field(t => t.Description)
                .Type<StringType>();
        }
    }

    public class NewCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class NewCategoryType : InputObjectType<NewCategoryDto>
    {

    }

    public class NewCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
    
    public class NewCourseType : InputObjectType<NewCourseDto>
    {
    }
}
