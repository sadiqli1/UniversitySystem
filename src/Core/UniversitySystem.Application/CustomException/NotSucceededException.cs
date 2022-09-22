
using Microsoft.AspNetCore.Identity;

namespace UniversitySystem.Application.CustomException
{
    public class NotSucceededException: Exception
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public NotSucceededException(List<IdentityError> error)
        {
            error.ForEach(e =>
            {
                Code = e.Code;
                Description = e.Description;
            });
        }
        public override string Message => $"{Code} {Description}";
    }
}
