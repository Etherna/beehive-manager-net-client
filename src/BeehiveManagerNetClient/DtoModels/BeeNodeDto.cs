using System;

namespace Etherna.BeehiveManagerClient.DtoModels
{
    public class BeeNodeDto
    {
        // Constructors.
        internal BeeNodeDto(Generated.BeeNodeDto beeNode)
        {
            if (beeNode is null)
                throw new ArgumentNullException(nameof(beeNode));

            Id = beeNode.Id!;
            DebugPort = beeNode.DebugPort;
            EthereumAddress = beeNode.EthereumAddress;
            GatewayPort = beeNode.GatewayPort;
            OverlayAddress = beeNode.OverlayAddress;
            PssPublicKey = beeNode.PssPublicKey;
            PublicKey = beeNode.PublicKey;
            Url = beeNode.Url!;
        }

        // Properties.
        public string Id { get; }
        public int? DebugPort { get; }
        public string? EthereumAddress { get; }
        public int? GatewayPort { get; }
        public string? OverlayAddress { get; }
        public string? PssPublicKey { get; }
        public string? PublicKey { get; }
        public Uri Url { get; }
    }
}
