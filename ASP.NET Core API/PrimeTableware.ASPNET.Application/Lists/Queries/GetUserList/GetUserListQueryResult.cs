using AutoMapper;
using PrimeTableware.ASPNET.Application.Common.Mappings;
using PrimeTableware.ASPNET.Domain.Entities; 


namespace PrimeTableware.ASPNET.Application.Lists.Queries.GetUserList
{
    public class GetUserListQueryResult
    {
        public IList<UserLookupDto> Users { get; set; }
    }
}