using AutoMapper;
using TheThanh_WebAPI_Flight.Data;
using TheThanh_WebAPI_Flight.DTO;
using TheThanh_WebAPI_Flight.Repository;
using TheThanh_WebAPI_Flight.Validation;

namespace TheThanh_WebAPI_Flight.Services
{
    public interface IRoleUserService
    {
        Task<IEnumerable<RoleUserDTO>> GetAllRoleUser();
        Task<IEnumerable<RoleUserDTO>?> GetUserInRole(int id);
        Task<(bool Success, string? ErrorMessage)> AddUserToRole(RoleUserDTO createDTO);
        Task<(bool Success, string? ErrorMessage)> DeleteRoleUser(int roleId, int userId);

    }
    public class RoleUserService : IRoleUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleUserValidator _roleUserValidator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleUserService(IUnitOfWork unitOfWork, IMapper mapper, RoleUserValidator roleUserValidator, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleUserValidator = roleUserValidator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(bool Success, string? ErrorMessage)> AddUserToRole(RoleUserDTO createDTO)
        {
            FluentValidation.Results.ValidationResult validationResult = await _roleUserValidator.ValidateAsync(createDTO);
            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);


            RoleUser newRoleUser = _mapper.Map<RoleUser>(createDTO);
            await _unitOfWork.RoleUser.CreateAsync(newRoleUser);
            await _unitOfWork.SaveChangeAsync();

            return (true, null);
        }

        public async Task<(bool Success, string? ErrorMessage)> DeleteRoleUser(int roleId, int userId)
        {
            RoleUser? role = await _unitOfWork.RoleUser.GetByIdAsync(m => m.RoleID == roleId && m.UserID == userId);

            if (role == null) return (false, "RoleUser not found");

            _unitOfWork.RoleUser.Delete(role);
            await _unitOfWork.SaveChangeAsync();

            return (true, null);
        }

        public async Task<IEnumerable<RoleUserDTO>> GetAllRoleUser()
        {
            IEnumerable<RoleUser> roles = await _unitOfWork.RoleUser.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleUserDTO>>(roles);
        }

        public async Task<IEnumerable<RoleUserDTO>?> GetUserInRole(int id)
        {
            IEnumerable<RoleUser> roleUsers = await _unitOfWork.RoleUser.GetAllAsync(m => m.RoleID == id);
            if (!roleUsers.Any())
            {
                return null;
            }
            return _mapper.Map<IEnumerable<RoleUserDTO>>(roleUsers);
        }

    }
}
