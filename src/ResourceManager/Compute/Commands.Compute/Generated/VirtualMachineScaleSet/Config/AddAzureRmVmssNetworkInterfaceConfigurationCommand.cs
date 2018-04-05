//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Add", "AzureRmVmssNetworkInterfaceConfiguration", SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachineScaleSet))]
    public partial class AddAzureRmVmssNetworkInterfaceConfigurationCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSVirtualMachineScaleSet VirtualMachineScaleSet { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public bool? Primary { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true)]
        public string Id { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 4,
            ValueFromPipelineByPropertyName = true)]
        public VirtualMachineScaleSetIPConfiguration[] IpConfiguration { get; set; }

        [Parameter(
            Mandatory = false)]
        public SwitchParameter EnableAcceleratedNetworking { get; set; }

        [Parameter(
            Mandatory = false)]
        public SwitchParameter EnableIPForwarding { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string NetworkSecurityGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        [Alias("DnsServer")]
        public string[] DnsSettingsDnsServer { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("VirtualMachineScaleSet", "Add"))
            {
                Run();
            }
        }

        private void Run()
        {
            WriteWarning("Add-AzureRmVmssNetworkInterfaceConfiguration: A property of the output of this cmdlet will change in an upcoming breaking change release. " +
                         "The StorageAccountType property for a DataDisk will return Standard_LRS and Premium_LRS");

            // VirtualMachineProfile
            if (this.VirtualMachineScaleSet.VirtualMachineProfile == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetVMProfile();
            }

            // NetworkProfile
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.NetworkProfile == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.NetworkProfile = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetNetworkProfile();
            }

            // NetworkInterfaceConfigurations
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations = new List<Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetNetworkConfiguration>();
            }

            var vNetworkInterfaceConfigurations = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetNetworkConfiguration();

            vNetworkInterfaceConfigurations.Name = this.MyInvocation.BoundParameters.ContainsKey("Name") ? this.Name : null;
            vNetworkInterfaceConfigurations.Primary = this.MyInvocation.BoundParameters.ContainsKey("Primary") ? this.Primary : (bool?) null;
            vNetworkInterfaceConfigurations.EnableAcceleratedNetworking = this.EnableAcceleratedNetworking.IsPresent;
            vNetworkInterfaceConfigurations.EnableIPForwarding = this.EnableIPForwarding.IsPresent;
            vNetworkInterfaceConfigurations.Id = this.MyInvocation.BoundParameters.ContainsKey("Id") ? this.Id : null;
            if (this.MyInvocation.BoundParameters.ContainsKey("NetworkSecurityGroupId"))
            {
                // NetworkSecurityGroup
                vNetworkInterfaceConfigurations.NetworkSecurityGroup = new Microsoft.Azure.Management.Compute.Models.SubResource();
                vNetworkInterfaceConfigurations.NetworkSecurityGroup.Id = this.NetworkSecurityGroupId;
            }
            if (this.MyInvocation.BoundParameters.ContainsKey("DnsSettingsDnsServer"))
            {
                // DnsSettings
                vNetworkInterfaceConfigurations.DnsSettings = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetNetworkConfigurationDnsSettings();
                vNetworkInterfaceConfigurations.DnsSettings.DnsServers = this.DnsSettingsDnsServer;
            }
            vNetworkInterfaceConfigurations.IpConfigurations = this.MyInvocation.BoundParameters.ContainsKey("IpConfiguration") ? this.IpConfiguration : null;
            this.VirtualMachineScaleSet.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations.Add(vNetworkInterfaceConfigurations);
            WriteObject(this.VirtualMachineScaleSet);
        }
    }
}

