
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

public class XsRawGnssSatInfo : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal XsRawGnssSatInfo(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(XsRawGnssSatInfo obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~XsRawGnssSatInfo() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          movelladot_pc_sdkPINVOKE.delete_XsRawGnssSatInfo(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public uint m_itow {
    set {
      movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_itow_set(swigCPtr, value);
    } 
    get {
      uint ret = movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_itow_get(swigCPtr);
      return ret;
    } 
  }

  public byte m_numSvs {
    set {
      movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_numSvs_set(swigCPtr, value);
    } 
    get {
      byte ret = movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_numSvs_get(swigCPtr);
      return ret;
    } 
  }

  public byte m_res1 {
    set {
      movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_res1_set(swigCPtr, value);
    } 
    get {
      byte ret = movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_res1_get(swigCPtr);
      return ret;
    } 
  }

  public byte m_res2 {
    set {
      movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_res2_set(swigCPtr, value);
    } 
    get {
      byte ret = movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_res2_get(swigCPtr);
      return ret;
    } 
  }

  public byte m_res3 {
    set {
      movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_res3_set(swigCPtr, value);
    } 
    get {
      byte ret = movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_res3_get(swigCPtr);
      return ret;
    } 
  }

  public XsSatInfo m_satInfos {
    set {
      movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_satInfos_set(swigCPtr, XsSatInfo.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = movelladot_pc_sdkPINVOKE.XsRawGnssSatInfo_m_satInfos_get(swigCPtr);
      XsSatInfo ret = (cPtr == global::System.IntPtr.Zero) ? null : new XsSatInfo(cPtr, false);
      return ret;
    } 
  }

  public XsRawGnssSatInfo() : this(movelladot_pc_sdkPINVOKE.new_XsRawGnssSatInfo(), true) {
  }

}

}
