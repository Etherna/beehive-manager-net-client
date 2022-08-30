using System;

namespace Etherna.BeehiveManager.NetClient.DtoModels
{
    public enum PinnedResourceStatusDto
    {
        InProgress,
        NotPinned,
        Pinned
    }

    public class PinnedResourceDto
    {
        internal PinnedResourceDto(Generated.PinnedResourceDto resource)
        {
            Hash = resource.Hash;
            NodeId = resource.NodeId;
            Status = resource.Status switch
            {
                Generated.PinnedResourceStatusDto.InProgress => PinnedResourceStatusDto.InProgress,
                Generated.PinnedResourceStatusDto.NotPinned => PinnedResourceStatusDto.NotPinned,
                Generated.PinnedResourceStatusDto.Pinned => PinnedResourceStatusDto.Pinned,
                _ => throw new InvalidOperationException()
            };
        }

        public string Hash { get; }
        public string NodeId { get; }
        public PinnedResourceStatusDto Status { get; }
    }
}
