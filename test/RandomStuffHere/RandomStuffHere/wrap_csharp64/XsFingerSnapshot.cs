
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

public class XsFingerSnapshot : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal XsFingerSnapshot(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(XsFingerSnapshot obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~XsFingerSnapshot() {
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
          movelladot_pc_sdkPINVOKE.delete_XsFingerSnapshot(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public int24_t m_iQ {
    set {
      movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_iQ_set(swigCPtr, int24_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_iQ_get(swigCPtr);
      int24_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new int24_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_int m_iV {
    set {
      movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_iV_set(swigCPtr, SWIGTYPE_p_int.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_iV_get(swigCPtr);
      SWIGTYPE_p_int ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_int(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_short m_mag {
    set {
      movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_mag_set(swigCPtr, SWIGTYPE_p_short.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_mag_get(swigCPtr);
      SWIGTYPE_p_short ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_short(cPtr, false);
      return ret;
    } 
  }

  public ushort m_flags {
    set {
      movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_flags_set(swigCPtr, value);
    } 
    get {
      ushort ret = movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_flags_get(swigCPtr);
      return ret;
    } 
  }

  public byte m_accClippingCounter {
    set {
      movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_accClippingCounter_set(swigCPtr, value);
    } 
    get {
      byte ret = movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_accClippingCounter_get(swigCPtr);
      return ret;
    } 
  }

  public byte m_gyrClippingCounter {
    set {
      movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_gyrClippingCounter_set(swigCPtr, value);
    } 
    get {
      byte ret = movelladot_pc_sdkPINVOKE.XsFingerSnapshot_m_gyrClippingCounter_get(swigCPtr);
      return ret;
    } 
  }

  public XsFingerSnapshot() : this(movelladot_pc_sdkPINVOKE.new_XsFingerSnapshot(), true) {
  }

}

}
