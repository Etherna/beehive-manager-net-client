﻿//   Copyright 2022-present Etherna Sagl
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

using System;

namespace Etherna.BeehiveManager.NetClient.DtoModels
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
