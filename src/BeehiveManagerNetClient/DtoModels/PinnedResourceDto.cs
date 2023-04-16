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
                Generated.PinnedResourceDtoStatus.InProgress => PinnedResourceStatusDto.InProgress,
                Generated.PinnedResourceDtoStatus.NotPinned => PinnedResourceStatusDto.NotPinned,
                Generated.PinnedResourceDtoStatus.Pinned => PinnedResourceStatusDto.Pinned,
                _ => throw new InvalidOperationException()
            };
        }

        public string Hash { get; }
        public string NodeId { get; }
        public PinnedResourceStatusDto Status { get; }
    }
}
