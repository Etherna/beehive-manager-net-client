using System;

namespace Etherna.BeehiveManager.NetClient.DtoModels
{
    public class PostageBatchDto
    {
        // Constructors.
        internal PostageBatchDto(Generated.PostageBatchDto postageBatch)
        {
            if (postageBatch is null)
                throw new ArgumentNullException(nameof(postageBatch));

            Id = postageBatch.Id!;
            BatchTTL = postageBatch.BatchTTL;
            BlockNumber = postageBatch.BlockNumber;
            BucketDepth = postageBatch.BucketDepth;
            Depth = postageBatch.Depth;
            Exists = postageBatch.Exists;
            ImmutableFlag = postageBatch.ImmutableFlag;
            Label = postageBatch.Label;
            OwnerAddress = postageBatch.OwnerAddress;
            Usable = postageBatch.Usable;
            Utilization = postageBatch.Utilization;
            Value = postageBatch.Value;
        }

        // Properties.
        public string Id { get; }
        public long? Value { get; }
        public int BatchTTL { get; }
        public int BlockNumber { get; }
        public int BucketDepth { get; }
        public int Depth { get; }
        public bool Exists { get; }
        public bool ImmutableFlag { get; }
        public string? Label { get; }
        public long NormalisedBalance { get; }
        public string? OwnerAddress { get; }
        public bool Usable { get; }
        public int? Utilization { get; }
    }
}
