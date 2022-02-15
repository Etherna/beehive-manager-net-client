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
        /// <returns>Success</returns>
        Task<string> BuyNewPostageBatchAsync(
            long amount,
            int depth,
            long? gasPrice = null,
            bool immutable = false,
            string? label = null,
            string? nodeId = null);

        /// <summary>
        /// Get node info by its id
        /// </summary>
        /// <param name="id">Id of the bee node</param>
        /// <returns>Bee node info</returns>
        Task<BeeNodeDto> FindNodeAsync(string id);

        /// <summary>
        /// Find details of a postage batch owned by a node
        /// </summary>
        /// <param name="ownerNodeId">Id of the bee node</param>
        /// <param name="batchId">Postage Batch Id</param>
        /// <returns>Success</returns>
        Task<PostageBatchDto> GetPostageBatchAsync(string ownerNodeId, string batchId);

        /// <summary>
        /// Get all postage batches from all healthy nodes
        /// </summary>
        /// <returns>Success</returns>
        Task<IEnumerable<PostageBatchDto>> GetPostageBatchesFromAllHealthyNodesAsync();

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
        /// Register a new bee node.
        /// </summary>
        /// <param name="debugApiPort">Debug api port</param>
        /// <param name="gatewayApiPort">Gateway api port</param>
        /// <param name="url">Node url</param>
        /// <returns>Bee node info</returns>
        Task<BeeNodeDto> RegisterNewNodeAsync(int debugApiPort, int gatewayApiPort, Uri url);

        /// <summary>
        /// Remove a bee node.
        /// </summary>
        /// <param name="id">Id of the bee node</param>
        /// <returns>Success</returns>
        Task RemoveNodeAsync(string id);
    }
}