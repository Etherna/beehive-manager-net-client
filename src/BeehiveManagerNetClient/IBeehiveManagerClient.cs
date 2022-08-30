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
using System.Threading.Tasks;

namespace Etherna.BeehiveManager.NetClient
{
    public interface IBeehiveManagerClient
    {
        // Properties.
        ApiVersions CurrentApiVersion { get; }

        /// <summary>
        /// Buy a new postage batch
        /// </summary>
        /// <param name="depth">Batch depth</param>
        /// <param name="amount">Amount of BZZ in Plur added that the postage batch will have</param>
        /// <param name="gasPrice">Gas price for transaction</param>
        /// <param name="immutable">Is batch immutable</param>
        /// <param name="label">An optional label for this batch</param>
        /// <param name="nodeId">Bee node Id</param>
        /// <returns>New postage batch reference</returns>
        Task<PostageBatchRefDto> BuyNewPostageBatchAsync(
            long amount,
            int depth,
            long? gasPrice = null,
            bool immutable = false,
            string? label = null,
            string? nodeId = null);

        /// <summary>
        /// Delete a pinned resource from a node
        /// </summary>
        /// <param name="nodeId">Id of the bee node</param>
        /// <param name="hash">Resource hash</param>
        Task DeletePinFromNodeAsync(string nodeId, string hash);

        /// <summary>
        /// Dilute a postage batch depth
        /// </summary>
        /// <param name="batchId">Id of the postage batch</param>
        /// <param name="depth">New postage depth. Must be higher than the previous depth</param>
        /// <returns>Postage batch Id</returns>
        Task<string> DilutePostageBatchAsync(
            string batchId,
            int depth);

        /// <summary>
        /// Find bee node pinning a specific content
        /// </summary>
        /// <param name="hash">Reference hash of the content</param>
        /// <param name="requireAliveNodes">True if nodes needs to be alive</param>
        /// <response code="200">List of Bee nodes</response>
        Task<IEnumerable<BeeNodeDto>> FindBeeNodesPinningContentAsync(string hash, bool requireAliveNodes = false);

        /// <summary>
        /// Get node info by its id
        /// </summary>
        /// <param name="nodeId">Id of the bee node</param>
        /// <returns>Bee node info</returns>
        Task<BeeNodeDto> FindNodeAsync(string nodeId);

        /// <summary>
        /// Find bee node info by an owned postage batch Id
        /// </summary>
        /// <param name="batchId">Id of the postage batch</param>
        /// <returns>Bee node info</returns>
        Task<BeeNodeDto> FindNodeOwnerOfPostageBatchAsync(string batchId);

        /// <summary>
        /// Force full status refresh on a Bee node
        /// </summary>
        /// <param name="id">Id of the bee node</param>
        /// <returns>True if node was alive</returns>
        Task<bool> ForceNodeFullStatusRefreshAsync(string nodeId);

        /// <summary>
        /// Get live status of all Bee node
        /// </summary>
        /// <returns>Live status of all nodes</returns>
        Task<IEnumerable<BeeNodeStatusDto>> GetAllBeeNodeLiveStatus();

        /// <summary>
        /// Get chain state
        /// </summary>
        /// <returns>The chain state</returns>
        Task<ChainStateDto> GetChainStateAsync();

        /// <summary>
        /// Get live status of a Bee node
        /// </summary>
        /// <param name="id">Id of the bee node</param>
        /// <returns>Live status of the node</returns>
        Task<BeeNodeStatusDto> GetNodeLiveStatusAsync(string nodeId);

        /// <summary>
        /// Get details of a pinned resource on a node
        /// </summary>
        /// <param name="nodeId">Id of the bee node</param>
        /// <param name="hash">Resource hash</param>
        /// <returns>Pinned resource info</returns>
        Task<PinnedResourceDto> GetPinDetailsAsync(string nodeId, string hash);

        /// <summary>
        /// Get all pinned resources by a node
        /// </summary>
        /// <param name="id">Id of the bee node</param>
        /// <returns>List of pinned resources</returns>
        Task<IEnumerable<string>> GetPinsByNodeAsync(string nodeId);

        /// <summary>
        /// Find details of a postage batch owned by a node
        /// </summary>
        /// <param name="ownerNodeId">Id of the bee node</param>
        /// <param name="batchId">Postage Batch Id</param>
        /// <returns>Success</returns>
        Task<PostageBatchDto> GetPostageBatchAsync(string ownerNodeId, string batchId);

        /// <summary>
        /// Get all postage batches owned by a node
        /// </summary>
        /// <param name="nodeId">Id of the bee node</param>
        /// <returns>Success</returns>
        Task<IEnumerable<PostageBatchDto>> GetPostageBatchesOwnedByNodeAsync(string nodeId);

        /// <summary>
        /// Get list of registered bee nodes
        /// </summary>
        /// <param name="page">Current page of results</param>
        /// <param name="take">Number of items to retrieve. Max 100</param>
        /// <returns>Current page on list</returns>
        Task<IEnumerable<BeeNodeDto>> GetRegisteredNodesAsync(int? page = null, int? take = null);

        /// <summary>
        /// Pin a content into a node that doesn't already pin it
        /// </summary>
        /// <param name="hash">The content hash reference</param>
        /// <param name="nodeId">Bee node Id</param>
        /// <response code="200">Id of the new pinning node</response>
        Task<string> PinContentInNodeAsync(string hash, string? nodeId = null);

        /// <summary>
        /// Register a new bee node.
        /// </summary>
        /// <param name="connectionScheme">The connection scheme (ex: http)</param>
        /// <param name="debugApiPort">Debug api port</param>
        /// <param name="gatewayApiPort">Gateway api port</param>
        /// <param name="hostname">The hostname</param>
        /// <returns>Bee node info</returns>
        Task<BeeNodeDto> RegisterNewNodeAsync(string connectionScheme, int debugApiPort, int gatewayApiPort, string hostname);

        /// <summary>
        /// Remove a bee node.
        /// </summary>
        /// <param name="id">Id of the bee node</param>
        /// <returns>Success</returns>
        Task RemoveNodeAsync(string id);

        /// <summary>
        /// Top up a postage batch
        /// </summary>
        /// <param name="batchId">Postage batch Id</param>
        /// <param name="amount">Amount to top up</param>
        /// <returns>Postage batch Id</returns>
        Task<string> TopUpPostageBatchAsync(string batchId, long amount);
    }
}