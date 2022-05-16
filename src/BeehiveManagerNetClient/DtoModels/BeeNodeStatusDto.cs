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
