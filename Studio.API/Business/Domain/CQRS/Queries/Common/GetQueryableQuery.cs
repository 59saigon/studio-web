using Studio.API.Business.Domain.CQRS.Queries.Base;

namespace Studio.API.Business.Domain.CQRS.Queries.Common
{
    public class GetQueryableQuery : BaseQuery
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set;}
    }
}
