using GetirClone.Application.Enums;

namespace GetirClone.Application.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastGeneratedCode { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsExist { get; set; }
        public SignInResultType SignInResult { get; set; }
    }
}
