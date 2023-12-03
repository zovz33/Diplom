using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Domain.Entities; 


namespace Diplom.ASPNET.Application.Lists.Queries.GetUserList
{
    public class GetUserListQueryResult
    {
        public IList<UserLookupDto> Users { get; set; }
    }
}