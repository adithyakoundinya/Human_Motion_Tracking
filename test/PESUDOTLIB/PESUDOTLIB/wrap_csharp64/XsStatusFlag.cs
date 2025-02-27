
//  WARNING: COPYRIGHT (C) 2023 MOVELLA TECHNOLOGIES OR SUBSIDIARIES WORLDWIDE. ALL RIGHTS RESERVED.
//  THIS FILE AND THE SOURCE CODE IT CONTAINS (AND/OR THE BINARY CODE FILES FOUND IN THE SAME
//  FOLDER THAT CONTAINS THIS FILE) AND ALL RELATED SOFTWARE (COLLECTIVELY, "CODE") ARE SUBJECT
//  TO A RESTRICTED LICENSE AGREEMENT ("AGREEMENT") BETWEEN XSENS AS LICENSOR AND THE AUTHORIZED
//  LICENSEE UNDER THE AGREEMENT. THE CODE MUST BE USED SOLELY WITH XSENS PRODUCTS INCORPORATED
//  INTO LICENSEE PRODUCTS IN ACCORDANCE WITH THE AGREEMENT. ANY USE, MODIFICATION, COPYING OR
//  DISTRIBUTION OF THE CODE IS STRICTLY PROHIBITED UNLESS EXPRESSLY AUTHORIZED BY THE AGREEMENT.
//  IF YOU ARE NOT AN AUTHORIZED USER OF THE CODE IN ACCORDANCE WITH THE AGREEMENT, YOU MUST STOP
//  USING OR VIEWING THE CODE NOW, REMOVE ANY COPIES OF THE CODE FROM YOUR COMPUTER AND NOTIFY
//  XSENS IMMEDIATELY BY EMAIL TO INFO@XSENS.COM. ANY COPIES OR DERIVATIVES OF THE CODE (IN WHOLE
//  OR IN PART) IN SOURCE CODE FORM THAT ARE PERMITTED BY THE AGREEMENT MUST RETAIN THE ABOVE
//  COPYRIGHT NOTICE AND THIS PARAGRAPH IN ITS ENTIRETY, AS REQUIRED BY THE AGREEMENT.
//  

//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.1
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace MovellaDotPcSdk {

public enum XsStatusFlag {
  XSF_SelfTestOk = 0x01,
  XSF_OrientationValid = 0x02,
  XSF_GpsValid = 0x04,
  XSF_NoRotationMask = 0x18,
  XSF_NoRotationAborted = 0x10,
  XSF_NoRotationSamplesRejected = 0x08,
  XSF_NoRotationRunningNormally = 0x18,
  XSF_RepresentativeMotion = 0x20,
  XSF_ExternalClockSynced = 0x40,
  XSF_FilterInputStart = 0x80,
  XSF_ClipAccX = 0x00000100,
  XSF_ClipAccY = 0x00000200,
  XSF_ClipAccZ = 0x00000400,
  XSF_ClipGyrX = 0x00000800,
  XSF_ClipGyrY = 0x00001000,
  XSF_ClipGyrZ = 0x00002000,
  XSF_ClipMagX = 0x00004000,
  XSF_ClipMagY = 0x00008000,
  XSF_ClipMagZ = 0x00010000,
  XSF_Retransmitted = 0x00040000,
  XSF_ClippingDetected = 0x00080000,
  XSF_Interpolated = 0x00100000,
  XSF_SyncIn = 0x00200000,
  XSF_SyncOut = 0x00400000,
  XSF_FilterMode = 0x03800000,
  XSF_HaveGnssTimePulse = 0x04000000,
  XSF_RtkStatus = 0x18000000
}

}
