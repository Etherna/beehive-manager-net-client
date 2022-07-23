using System;

namespace Etherna.BeehiveManager.NetClient.DtoModels
{
    public class ChainStateDto
    {
        internal ChainStateDto(Generated.ChainStateDto chainStateDto)
        {
            if (chainStateDto is null)
                throw new ArgumentNullException(nameof(chainStateDto));

            Block = chainStateDto.Block;
            CurrentPrice = chainStateDto.CurrentPrice;
            SourceNodeId = chainStateDto.SourceNodeId;
            TimeStamp = chainStateDto.TimeStamp;
            TotalAmount = chainStateDto.TotalAmount;
        }

        public long Block { get; }
        public string CurrentPrice { get; }
        public string SourceNodeId { get; }
        public DateTimeOffset TimeStamp { get; }
        public string TotalAmount { get; }
    }
}
