using Etherna.BeehiveManagerClient.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherna.BeehiveManagerClient
{
    public class BhmClient : IBhmClient
    {
        // Fields.
        private readonly Generated.IBhmClientGenerated client;

        // Constructor.
        public BhmClient(Uri baseUrl, ApiVersions apiVersion)
        {
            if (baseUrl is null)
                throw new ArgumentNullException(nameof(baseUrl));

            client = new Generated.BhmClientGenerated(baseUrl.ToString());
            CurrentApiVersion = apiVersion;
        }

        // Properties.
        public ApiVersions CurrentApiVersion { get; private set; }

        // Methods.
        public Task<string> BuyNewPostageBatchAsync(
            int amount,
            int depth,
            int? gasPrice = null,
            bool immutable = false,
            string? label = null,
            string? nodeId = null) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => client.ApiV0_3PostageBatchesPostAsync(depth, amount, gasPrice, immutable, label, nodeId),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> FindNodeAsync(string id) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new BeeNodeDto(await client.ApiV0_3NodesGetAsync(id).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<PostageBatchDto> GetPostageBatchAsync(string ownerNodeId, string batchId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new PostageBatchDto(await client.ApiV0_3NodesBatchesGetAsync(ownerNodeId, batchId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<PostageBatchDto>> GetPostageBatchesFromAllHealthyNodesAsync() =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => (await client.ApiV0_3PostageBatchesGetAsync().ConfigureAwait(false)).Select(i => new PostageBatchDto(i)),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<PostageBatchDto>> GetPostageBatchesOwnedByNodeAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => (await client.ApiV0_3NodesBatchesGetAsync(nodeId).ConfigureAwait(false)).Select(i => new PostageBatchDto(i)),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<BeeNodeDto>> GetRegisteredNodesAsync(int? page = null, int? take = null) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => (await client.ApiV0_3NodesGetAsync(page, take).ConfigureAwait(false)).Select(i => new BeeNodeDto(i)),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> RegisterNewNodeAsync(int debugApiPort, int gatewayApiPort, Uri url) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new BeeNodeDto(await client.ApiV0_3NodesPostAsync(new Generated.BeeNodeInput
                { 
                    DebugApiPort = debugApiPort,
                    GatewayApiPort = gatewayApiPort,
                    Url = url?.ToString() ?? throw new ArgumentNullException(nameof(url))
                }).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public Task RemoveNodeAsync(string id) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => client.ApiV0_3NodesDeleteAsync(id),
                _ => throw new InvalidOperationException()
            };
    }
}
