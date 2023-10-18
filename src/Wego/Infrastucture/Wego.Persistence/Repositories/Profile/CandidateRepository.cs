using Dapper;
using Wego.Application.IRepo;
using Wego.Domain.Profile;


namespace Wego.Persistence.Repositories.Profile
{
    internal class CandidateRepository : ICandidateRepository
    {
        private readonly DapperContext _context;
        public CandidateRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(CandidateModel candidate, CancellationToken cancellationToken = default)
        {
            var sql = "INSERT INTO [chat].[Candidates] (Email, Name, IsConnected, ProfileId, ConnectionId, ModifiedDate)  VALUES " +
                       "(@email, @name, @isConnected, @profileId, @connectionId, GETUTCDATE())";
            var parameters = new DynamicParameters();
            parameters.Add("email", candidate.Email);
            parameters.Add("name", candidate.Name);
            parameters.Add("profileId", candidate.ProfileId);
            parameters.Add("connectionId", candidate.ConnectionId);
            parameters.Add("isConnected", candidate.IsConnected);

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
            }
        }

        public async Task<int> SetConnected(long profileId, bool isConnected, CancellationToken cancellationToken = default)
        {
            var sql = "Update [chat].[Candidates] SET IsConnected = @isConnected WHERE ProfileId = @profileId";
            var parameters = new DynamicParameters();
            parameters.Add("isConnected", isConnected);
            parameters.Add("profileId", profileId);

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
            }
        }
    }
}
