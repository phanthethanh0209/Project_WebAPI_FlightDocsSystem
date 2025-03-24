using AutoMapper;
using TheThanh_WebAPI_Flight.Data;
using TheThanh_WebAPI_Flight.DTO;
using TheThanh_WebAPI_Flight.Repository;
using TheThanh_WebAPI_RobotHeineken.Validation;

namespace TheThanh_WebAPI_Flight.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRole();
        Task<RoleDTO?> GetRole(int id);
        Task<(bool Success, string? ErrorMessage)> CreateRole(RoleDTO createDTO);
        Task<(bool Success, string? ErrorMessage)> UpdateRole(int id, RoleDTO updateDTO);
        Task<(bool Success, string? ErrorMessage)> DeleteRole(int id);

    }
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleValidator _roleValidator;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, RoleValidator roleValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleValidator = roleValidator;
        }

        public async Task<(bool Success, string? ErrorMessage)> CreateRole(RoleDTO createDTO)
        {
            FluentValidation.Results.ValidationResult validationResult = await _roleValidator.ValidateAsync(createDTO);
            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);

            Role newRole = _mapper.Map<Role>(createDTO);
            await _unitOfWork.Role.CreateAsync(newRole);
            await _unitOfWork.SaveChangeAsync();

            return (true, null);
        }

        public async Task<(bool Success, string? ErrorMessage)> DeleteRole(int id)
        {
            Role? role = await _unitOfWork.Role.GetByIdAsync(m => m.RoleID == id);
            if (role == null) return (false, "Role not found");

            _unitOfWork.Role.Delete(role);
            await _unitOfWork.SaveChangeAsync();

            return (true, null);
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRole()
        {
            IEnumerable<Role> roles = await _unitOfWork.Role.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task<RoleDTO?> GetRole(int id)
        {
            Role? role = await _unitOfWork.Role.GetByIdAsync(m => m.RoleID == id);
            if (role == null) return null;

            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<(bool Success, string? ErrorMessage)> UpdateRole(int id, RoleDTO updateDTO)
        {
            FluentValidation.Results.ValidationResult validationResult = await _roleValidator.ValidateAsync(updateDTO);
            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);

            Role? role = await _unitOfWork.Role.GetByIdAsync(m => m.RoleID == id);
            if (role == null) return (false, "Role not found");

            _mapper.Map(updateDTO, role);
            _unitOfWork.Role.Update(role);
            await _unitOfWork.SaveChangeAsync();

            return (true, null);
        }
    }
}
