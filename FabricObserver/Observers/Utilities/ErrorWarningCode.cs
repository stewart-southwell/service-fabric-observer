﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace FabricObserver.Utilities
{
    public sealed class ErrorWarningCode
    {
        // CPU...
        public const string ErrorCpuTime = "FO001";
        public const string WarningCpuTime = "FO002";

        // Disk
        public const string ErrorDiskSpacePercentUsed = "FO003";
        public const string ErrorDiskSpaceMB = "FO004";
        public const string WarningDiskSpacePercentUsed = "FO005";
        public const string WarningDiskSpaceMB = "FO006";
        public const string ErrorDiskIoReads = "FO007";
        public const string WarningDiskIoReads = "FO008";
        public const string ErrorDiskIoWrites = "FO009";
        public const string WarningDiskIoWrites = "FO010";
        public const string ErrorDiskAverageQueueLength = "FO011";
        public const string WarningDiskAverageQueueLength = "FO012";

        // Memory
        public const string ErrorMemoryCommitted = "FO013";
        public const string WarningMemoryCommitted = "FO014";
        public const string ErrorMemoryPercentUsed = "FO015";
        public const string WarningMemoryPercentUsed = "FO016";
        public const string ErrorMemoryCommittedMB = "FO017";
        public const string WarningMemoryCommittedMB = "FO018";

        // Networking
        public const string ErrorNetworkEndpointUnreachable = "FO019";
        public const string WarningNetworkEndpointUnreachable = "FO020";
        public const string ErrorTooManyActivePorts = "FO021";
        public const string WarningTooManyActiveTcpPorts = "FO022";
        public const string ErrorTooManyFirewallRules = "FO023";
        public const string WarningTooManyFirewallRules = "FO024";
        public const string ErrorTooManyActiveEphemeralPorts = "FO025";
        public const string WarningTooManyActiveEphemeralPorts = "FO026";

        // Unknown
        public const string Unknown = "FO000";
    }
}
