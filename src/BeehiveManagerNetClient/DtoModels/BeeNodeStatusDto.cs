using System;
using System.Collections.Generic;

namespace Etherna.BeehiveManager.NetClient.DtoModels
{
    public class BeeNodeStatusDto
    {
        // Constructor.
        internal BeeNodeStatusDto(Generated.BeeNodeStatusDto beeNodeStatusDto)
        {
            if (beeNodeStatusDto is null)
                throw new ArgumentNullException(nameof(beeNodeStatusDto));

            Errors = beeNodeStatusDto.Errors;
            IsAlive = beeNodeStatusDto.IsAlive;
            PostageBatchesId = beeNodeStatusDto.PostageBatchesId;
            Id = beeNodeStatusDto.Id;
        }

        // Properties.
        public string Id { get; }
        public IEnumerable<string> Errors { get; }
        public bool IsAlive { get; }
        public IEnumerable<string> PostageBatchesId { get; }
    }
}
