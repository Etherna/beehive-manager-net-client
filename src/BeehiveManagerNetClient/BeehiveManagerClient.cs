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
using Etherna.BeehiveManager.NetClient.InputModels;
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
                ApiVersions.v0_3 => new PostageBatchRefDto(await client.ApiV0_3PostageBatchesAsync(amount, depth, gasPrice, immutable, label, nodeId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public Task DeletePinFromNodeAsync(string nodeId, string hash) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => client.ApiV0_3NodesPinsDeleteAsync(nodeId, hash),
                _ => throw new InvalidOperationException()
            };

        public async Task<string> DilutePostageBatchAsync(string batchId, int depth) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => await client.ApiV0_3PostageBatchesDiluteAsync(batchId, depth).ConfigureAwait(false),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> FindNodeAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new BeeNodeDto(await client.ApiV0_3NodesGetAsync(nodeId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> FindNodeOwnerOfPostageBatchAsync(string batchId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new BeeNodeDto(await client.ApiV0_3LoadBalancerBatchAsync(batchId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<BeeNodeDto>> FindNodesPinningResourceAsync(string hash, bool requireAliveNodes = false) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => (await client.ApiV0_3PinningNodesAsync(hash, requireAliveNodes).ConfigureAwait(false)).Select(n => new BeeNodeDto(n)),
                _ => throw new InvalidOperationException()
            };

        public async Task<bool> ForceNodeFullStatusRefreshAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => await client.ApiV0_3NodesStatusPutAsync(nodeId).ConfigureAwait(false),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<BeeNodeStatusDto>> GetAllBeeNodeLiveStatusAsync() =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => (await client.ApiV0_3NodesStatusGetAsync().ConfigureAwait(false)).Select(s => new BeeNodeStatusDto(s)),
                _ => throw new InvalidOperationException()
            };

        public async Task<ChainStateDto> GetChainStateAsync() =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new ChainStateDto(await client.ApiV0_3ChainStateAsync().ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeStatusDto> GetNodeLiveStatusAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new BeeNodeStatusDto(await client.ApiV0_3NodesStatusGetAsync(nodeId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<PinnedResourceDto> GetPinDetailsAsync(string nodeId, string hash) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new PinnedResourceDto(await client.ApiV0_3NodesPinsGetAsync(nodeId, hash).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<string>> GetPinsByNodeAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => await client.ApiV0_3NodesPinsGetAsync(nodeId).ConfigureAwait(false),
                _ => throw new InvalidOperationException()
            };

        public async Task<PostageBatchDto> GetPostageBatchAsync(string ownerNodeId, string batchId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new PostageBatchDto(await client.ApiV0_3NodesBatchesGetAsync(ownerNodeId, batchId).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<PostageBatchDto>> GetPostageBatchesOwnedByNodeAsync(string nodeId) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => (await client.ApiV0_3NodesBatchesGetAsync(nodeId).ConfigureAwait(false)).Select(i => new PostageBatchDto(i)),
                _ => throw new InvalidOperationException()
            };

        public async Task<IEnumerable<BeeNodeDto>> GetRegisteredNodesAsync(int? page = null, int? take = null) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => (await client.ApiV0_3NodesGetAsync(page, take).ConfigureAwait(false)).Select(i => new BeeNodeDto(i)),
                _ => throw new InvalidOperationException()
            };

        public Task NotifyNodeOfUploadedPinnedResourceAsync(string id, string hash) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => client.ApiV0_3NodesPinsUploadedAsync(id, hash),
                _ => throw new InvalidOperationException()
            };

        public Task<string> PinResourceInNodeAsync(string hash, string? nodeId = null) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => client.ApiV0_3PinningAsync(hash, nodeId),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> RegisterNewNodeAsync(string connectionScheme, int debugApiPort, int gatewayApiPort, string hostname, NodeConfigInput nodeConfig) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new BeeNodeDto(await client.ApiV0_3NodesPostAsync(new Generated.BeeNodeInput
                {
                    ConnectionScheme = connectionScheme,
                    DebugApiPort = debugApiPort,
                    EnableBatchCreation = nodeConfig.EnableBatchCreation,
                    GatewayApiPort = gatewayApiPort,
                    Hostname = hostname
                }).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public Task RemoveNodeAsync(string id) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => client.ApiV0_3NodesDeleteAsync(id),
                _ => throw new InvalidOperationException()
            };

        public Task ReuploadResourceToNetwork(string nodeId, string hash) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => client.ApiV0_3NodesStewardshipPutAsync(nodeId, hash),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> SelectHealthyNodeAsync() =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new BeeNodeDto(await client.ApiV0_3LoadBalancerAsync().ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<BeeNodeDto> SelectLoadBalancedNodeForDownloadAsync(string hash) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => new BeeNodeDto(await client.ApiV0_3LoadBalancerDownloadAsync(hash).ConfigureAwait(false)),
                _ => throw new InvalidOperationException()
            };

        public async Task<string> TopUpPostageBatchAsync(string batchId, long amount) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => await client.ApiV0_3PostageBatchesTopupAsync(batchId, amount).ConfigureAwait(false),
                _ => throw new InvalidOperationException()
            };

        public Task UpdateNodeConfigAsync(string nodeId, NodeConfigInput nodeConfig) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => client.ApiV0_3NodesConfigAsync(
                    nodeId,
                    new Generated.UpdateNodeConfigInput
                    {
                        EnableBatchCreation = nodeConfig.EnableBatchCreation
                    }),
                _ => throw new InvalidOperationException()
            };

        public Task<bool> VerifyResourceAvailabilityFromNodeAsync(string nodeId, string hash) =>
            CurrentApiVersion switch
            {
                ApiVersions.v0_3 => client.ApiV0_3NodesStewardshipGetAsync(nodeId, hash),
                _ => throw new InvalidOperationException()
            };
    }
}
