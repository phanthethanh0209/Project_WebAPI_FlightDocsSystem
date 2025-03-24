using TheThanh_WebAPI_Flight.Data;

namespace TheThanh_WebAPI_Flight.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> User { get; }
        IGenericRepository<Role> Role { get; }
        IGenericRepository<Permission> Permission { get; }
        IGenericRepository<RolePermission> RolePermission { get; }
        IGenericRepository<RoleUser> RoleUser { get; }
        IGenericRepository<RefreshToken> RefreshToken { get; }
        IGenericRepository<DocumentType> DocumentType { get; }
        IGenericRepository<Flight> Flight { get; }
        IGenericRepository<Document> Document { get; }


        Task SaveChangeAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDBContext _db;

        public UnitOfWork(MyDBContext db)
        {
            _db = db;
        }

        private IGenericRepository<User> UserRepositoryBase;
        public IGenericRepository<User> User => UserRepositoryBase ??= new GenericRepository<User>(_db);


        public IGenericRepository<Role> RoleRepositoryBase;
        public IGenericRepository<Role> Role => RoleRepositoryBase ??= new GenericRepository<Role>(_db);


        public IGenericRepository<Permission> PermissionRepositoryBase;
        public IGenericRepository<Permission> Permission => PermissionRepositoryBase ??= new GenericRepository<Permission>(_db);


        public IGenericRepository<RolePermission> RolePermissionRepositoryBase;
        public IGenericRepository<RolePermission> RolePermission => RolePermissionRepositoryBase ??= new GenericRepository<RolePermission>(_db);


        public IGenericRepository<RoleUser> RoleUserRepositoryBase;
        public IGenericRepository<RoleUser> RoleUser => RoleUserRepositoryBase ??= new GenericRepository<RoleUser>(_db);


        public IGenericRepository<RefreshToken> RefreshTokenRepositoryBase;
        public IGenericRepository<RefreshToken> RefreshToken => RefreshTokenRepositoryBase ??= new GenericRepository<RefreshToken>(_db);



        private IGenericRepository<DocumentType> DocumentTypeRepositoryBase;
        public IGenericRepository<DocumentType> DocumentType => DocumentTypeRepositoryBase ??= new GenericRepository<DocumentType>(_db);


        private IGenericRepository<Flight> FlightRepositoryBase;
        public IGenericRepository<Flight> Flight => FlightRepositoryBase ??= new GenericRepository<Flight>(_db);


        private IGenericRepository<Document> DocumentRepositoryBase;
        public IGenericRepository<Document> Document => DocumentRepositoryBase ??= new GenericRepository<Document>(_db);


        public async Task SaveChangeAsync()
        {
            await _db.SaveChangesAsync();
        }

    }
}
