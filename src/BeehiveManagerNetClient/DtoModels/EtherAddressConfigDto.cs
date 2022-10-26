using System;

namespace Etherna.BeehiveManager.NetClient.DtoModels
{
    public class EtherAddressConfigDto
    {
        // Constructor.
        internal EtherAddressConfigDto(Generated.EtherAddressDto etherAddressDto)
        {
            if (etherAddressDto is null)
                throw new ArgumentNullException(nameof(etherAddressDto));

            Address = etherAddressDto.Address;
            PreferredSocNode = new BeeNodeDto(etherAddressDto.PreferredSocNode);
        }

        // Properties.
        public string Address { get; }
        public BeeNodeDto PreferredSocNode { get; }
    }
}
