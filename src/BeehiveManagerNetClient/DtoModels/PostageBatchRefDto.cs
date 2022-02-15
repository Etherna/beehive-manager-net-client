namespace Etherna.BeehiveManager.NetClient.DtoModels
{
    public class PostageBatchRefDto
    {
        internal PostageBatchRefDto(
            Generated.PostageBatchRefDto postageBatch)
        {
            BatchId = postageBatch.BatchId!;
            NodeId = postageBatch.NodeId!;
        }

        public string BatchId { get; }
        public string NodeId { get; }
    }
}
