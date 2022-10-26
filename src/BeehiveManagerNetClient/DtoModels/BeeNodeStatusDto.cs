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

            Id = beeNodeStatusDto.Id;
            Errors = beeNodeStatusDto.Errors;
            EthereumAddress = beeNodeStatusDto.EthereumAddress;
            IsAlive = beeNodeStatusDto.IsAlive;
            OverlayAddress = beeNodeStatusDto.OverlayAddress;
            PinnedHashes = beeNodeStatusDto.PinnedHashes;
            PostageBatchesId = beeNodeStatusDto.PostageBatchesId;
            PssPublicKey = beeNodeStatusDto.PssPublicKey;
            PublicKey = beeNodeStatusDto.PublicKey;
        }

        // Properties.
        public string Id { get; }
        public IEnumerable<string> Errors { get; }
        public string? EthereumAddress { get; }
        public DateTimeOffset HeartbeatTimeStamp { get; }
        public bool IsAlive { get; }
        public string? OverlayAddress { get; }
        public IEnumerable<string> PinnedHashes { get; }
        public IEnumerable<string> PostageBatchesId { get; }
        public string? PssPublicKey { get; }
        public string? PublicKey { get; }
    }
}
