//   Copyright 2022-present Etherna Sagl
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using Etherna.BeehiveManager.NetClient.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etherna.BeehiveManager.NetClient
{
    public class BeehiveManagerClient : IBeehiveManagerClient
    {
        // Fields.
        private readonly Generated.IBhmClientGenerated client;

        // Constructor.
        public BeehiveManagerClient(Uri baseUrl, ApiVersions apiVersion)
        {
            if (baseUrl is null)
                throw new ArgumentNullException(nameof(baseUrl));

            client = new Generated.BhmClientGenerated(baseUrl.ToString());
            CurrentApiVersion = apiVersion;
        }

        // Properties.
        public ApiVersions CurrentApiVersion { get; private set; }

        // Methods.
        public async Task<PostageBatchRefDto> BuyNewPostageBatchAsync(
            long amount,
            int depth,
            long? gasPrice = null,
            bool immutable = false,
            string? label = null,
            string? nodeId = null) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new PostageBatchRefDto(await client.ApiV0_3PostageBatchesAsync(amount, depth, gasPrice, immutable, label, nodeId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<string> DilutePostageBatchAsync(string batchId, int depth) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => await client.ApiV0_3PostageBatchesDiluteAsync(batchId, depth).ConfigureAwait(false),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> FindNodeAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new BeeNodeDto(await client.ApiV0_3NodesGetAsync(nodeId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> FindNodeOwnerOfPostageBatchAsync(string batchId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new BeeNodeDto(await client.ApiV0_3PostageBatchesNodeAsync(batchId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<bool> ForceNodeFullStatusRefreshAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => await client.ApiV0_3NodesStatusPutAsync(nodeId).ConfigureAwait(false),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<BeeNodeStatusDto>> GetAllBeeNodeLiveStatus() =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => (await client.ApiV0_3NodesStatusGetAsync().ConfigureAwait(false)).Select(s => new BeeNodeStatusDto(s)),
                _ => throw new InvalidOperationException()
            };

        public async Task<ChainStateDto> GetChainStateAsync() =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new ChainStateDto(await client.ApiV0_3ChainStateAsync().ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeStatusDto> GetNodeLiveStatusAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new BeeNodeStatusDto(await client.ApiV0_3NodesStatusGetAsync(nodeId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<PostageBatchDto> GetPostageBatchAsync(string ownerNodeId, string batchId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new PostageBatchDto(await client.ApiV0_3NodesBatchesGetAsync(ownerNodeId, batchId).ConfigureAwait(false)),
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

        public async Task<BeeNodeDto> RegisterNewNodeAsync(string connectionScheme, int debugApiPort, int gatewayApiPort, string hostname) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => new BeeNodeDto(await client.ApiV0_3NodesPostAsync(new Generated.BeeNodeInput
                {
                    ConnectionScheme = connectionScheme,
                    DebugApiPort = debugApiPort,
                    GatewayApiPort = gatewayApiPort,
                    Hostname = hostname
                }).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public Task RemoveNodeAsync(string id) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => client.ApiV0_3NodesDeleteAsync(id),
                _ => throw new InvalidOperationException()
            };

        public async Task<string> TopUpPostageBatchAsync(string batchId, long amount) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3_0 => await client.ApiV0_3PostageBatchesTopupAsync(batchId, amount).ConfigureAwait(false),
                _ => throw new InvalidOperationException()
            };
    }
}
