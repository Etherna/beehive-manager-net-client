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
        public long BatchTTL { get; }
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
