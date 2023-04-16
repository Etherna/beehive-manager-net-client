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
        public long CurrentPrice { get; }
        public string SourceNodeId { get; }
        public DateTimeOffset TimeStamp { get; }
        public long TotalAmount { get; }
    }
}
