using AutoMapper;
using TheThanh_WebAPI_Flight.Data;
using TheThanh_WebAPI_Flight.DTO;
using TheThanh_WebAPI_Flight.Repository;
using TheThanh_WebAPI_Flight.Validation;

namespace TheThanh_WebAPI_Flight.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<PermissionDTO>> GetAllPermission();
        Task<PermissionDTO?> GetPermission(int id);
        Task<(bool Success, string? ErrorMessage)> CreatePermission(PermissionDTO createDTO);
        Task<(bool Success, string? ErrorMessage)> UpdatePermission(int id, PermissionDTO updateDTO);
        Task<(bool Success, string? ErrorMessage)> DeletePermission(int id);

    }
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PermissionValidator _permissionValidator;

        public PermissionService(IUnitOfWork unitOfWork, IMapper mapper, PermissionValidator permissionValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _permissionValidator = permissionValidator;
        }

        public async Task<(bool Success, string? ErrorMessage)> CreatePermission(PermissionDTO createDTO)
        {
            FluentValidation.Results.ValidationResult validationResult = await _permissionValidator.ValidateAsync(createDTO);
            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);

            Permission newPermission = _mapper.Map<Permission>(createDTO);
            await _unitOfWork.Permission.CreateAsync(newPermission);
            await _unitOfWork.SaveChangeAsync();

            return (true, null);
        }

        public async Task<(bool Success, string? ErrorMessage)> DeletePermission(int id)
        {
            Permission? permission = await _unitOfWork.Permission.GetByIdAsync(m => m.PermissionID == id);

            if (permission == null) return (false, "Permission not found");

            _unitOfWork.Permission.Delete(permission);
            await _unitOfWork.SaveChangeAsync();
            return (true, null);
        }

        public async Task<IEnumerable<PermissionDTO>> GetAllPermission()
        {
            IEnumerable<Permission> permissions = await _unitOfWork.Permission.GetAllAsync();
            return _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
        }

        public async Task<PermissionDTO?> GetPermission(int id)
        {
            Permission? permission = await _unitOfWork.Permission.GetByIdAsync(m => m.PermissionID == id);

            if (permission == null) return null;

            return _mapper.Map<PermissionDTO>(permission);
        }

        public async Task<(bool Success, string? ErrorMessage)> UpdatePermission(int id, PermissionDTO updateDTO)
        {
            FluentValidation.Results.ValidationResult validationResult = await _permissionValidator.ValidateAsync(updateDTO);
            if (!validationResult.IsValid)
                return (false, validationResult.Errors.First().ErrorMessage);

            Permission? permission = await _unitOfWork.Permission.GetByIdAsync(m => m.PermissionID == id);
            if (permission == null) return (false, "permission not found");

            _mapper.Map(updateDTO, permission);
            _unitOfWork.Permission.Update(permission);
            await _unitOfWork.SaveChangeAsync();

            return (true, null);
        }
    }
}
