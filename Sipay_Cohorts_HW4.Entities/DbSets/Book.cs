using Sipay_Cohorts_HW4.Entities.BaseModel;
using Sipay_Cohorts_HW4.Entities.Enums;

namespace Sipay_Cohorts_HW4.Entities.DbSets
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
