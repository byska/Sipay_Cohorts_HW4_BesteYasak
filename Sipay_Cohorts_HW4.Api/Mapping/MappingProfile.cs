using AutoMapper;
using Sipay_Cohorts_HW4.Entities.DbSets;
using Sipay_Cohorts_HW4.Entities.Enums;
using static Sipay_Cohorts_HW4.Api.BookOperations.GetByIdQuery;
using static Sipay_Cohorts_HW4.Api.BookOperations.UpdateBookCommand;

namespace Sipay_Cohorts_HW4.Api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.GenreId, opt => opt.MapFrom(src => (Genre)src.GenreId)).ToString();
            CreateMap<UpdateBookModel, Book>();
        }
    }
}
