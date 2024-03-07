
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

public class XsStringImpl : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal XsStringImpl(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(XsStringImpl obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~XsStringImpl() {
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
          movelladot_pc_sdkPINVOKE.delete_XsStringImpl(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public XsStringImpl(uint count, string src) : this(movelladot_pc_sdkPINVOKE.new_XsStringImpl__SWIG_0(count, src), true) {
  }

  public XsStringImpl(uint count) : this(movelladot_pc_sdkPINVOKE.new_XsStringImpl__SWIG_1(count), true) {
  }

  public XsStringImpl() : this(movelladot_pc_sdkPINVOKE.new_XsStringImpl__SWIG_2(), true) {
  }

  public XsStringImpl(XsStringImpl other) : this(movelladot_pc_sdkPINVOKE.new_XsStringImpl__SWIG_3(XsStringImpl.getCPtr(other)), true) {
    if (movelladot_pc_sdkPINVOKE.SWIGPendingException.Pending) throw movelladot_pc_sdkPINVOKE.SWIGPendingException.Retrieve();
  }

  public XsStringImpl(ref string ref_, uint sz, XsDataFlags flags) : this(movelladot_pc_sdkPINVOKE.new_XsStringImpl__SWIG_4(ref ref_, sz, (int)flags), true) {
  }

  public void clear() {
    movelladot_pc_sdkPINVOKE.XsStringImpl_clear(swigCPtr);
  }

  public void reserve(uint count) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_reserve(swigCPtr, count);
  }

  public uint reserved() {
    uint ret = movelladot_pc_sdkPINVOKE.XsStringImpl_reserved(swigCPtr);
    return ret;
  }

  public SWIGTYPE_p_XsArrayDescriptor descriptor() {
    SWIGTYPE_p_XsArrayDescriptor ret = new SWIGTYPE_p_XsArrayDescriptor(movelladot_pc_sdkPINVOKE.XsStringImpl_descriptor(swigCPtr), false);
    return ret;
  }

  public char value(uint index) {
    char ret = movelladot_pc_sdkPINVOKE.XsStringImpl_value(swigCPtr, index);
    return ret;
  }

  public char first() {
    char ret = movelladot_pc_sdkPINVOKE.XsStringImpl_first(swigCPtr);
    return ret;
  }

  public char last() {
    char ret = movelladot_pc_sdkPINVOKE.XsStringImpl_last(swigCPtr);
    return ret;
  }

  public char at(uint index) {
    char ret = movelladot_pc_sdkPINVOKE.XsStringImpl_at__SWIG_0(swigCPtr, index);
    return ret;
  }

  public void insert(char item, uint index) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_insert__SWIG_0(swigCPtr, item, index);
  }

  public void insert(string items, uint index, uint count) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_insert__SWIG_1(swigCPtr, items, index, count);
  }

  public void pop_back(uint count) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_pop_back__SWIG_0(swigCPtr, count);
  }

  public void pop_back() {
    movelladot_pc_sdkPINVOKE.XsStringImpl_pop_back__SWIG_1(swigCPtr);
  }

  public void push_front(char item) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_push_front(swigCPtr, item);
  }

  public void pop_front(uint count) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_pop_front__SWIG_0(swigCPtr, count);
  }

  public void pop_front() {
    movelladot_pc_sdkPINVOKE.XsStringImpl_pop_front__SWIG_1(swigCPtr);
  }

  public uint size() {
    uint ret = movelladot_pc_sdkPINVOKE.XsStringImpl_size(swigCPtr);
    return ret;
  }

  public void erase(uint index, uint count) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_erase__SWIG_0(swigCPtr, index, count);
  }

  public void erase(uint index) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_erase__SWIG_1(swigCPtr, index);
  }

  public void assign(uint count, string src) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_assign(swigCPtr, count, src);
  }

  public void resize(uint count) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_resize(swigCPtr, count);
  }

  public void setSize(uint count) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_setSize(swigCPtr, count);
  }

  public void append(XsStringImpl other) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_append(swigCPtr, XsStringImpl.getCPtr(other));
    if (movelladot_pc_sdkPINVOKE.SWIGPendingException.Pending) throw movelladot_pc_sdkPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool empty() {
    bool ret = movelladot_pc_sdkPINVOKE.XsStringImpl_empty(swigCPtr);
    return ret;
  }

  public bool badAlloc() {
    bool ret = movelladot_pc_sdkPINVOKE.XsStringImpl_badAlloc(swigCPtr);
    return ret;
  }

  public void swap(XsStringImpl other) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_swap__SWIG_0(swigCPtr, XsStringImpl.getCPtr(other));
    if (movelladot_pc_sdkPINVOKE.SWIGPendingException.Pending) throw movelladot_pc_sdkPINVOKE.SWIGPendingException.Retrieve();
  }

  public void swap(uint a, uint b) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_swap__SWIG_1(swigCPtr, a, b);
  }

  public SWIGTYPE_p_ptrdiff_t find(char needle) {
    SWIGTYPE_p_ptrdiff_t ret = new SWIGTYPE_p_ptrdiff_t(movelladot_pc_sdkPINVOKE.XsStringImpl_find(swigCPtr, needle), true);
    return ret;
  }

  public bool contains(char needle) {
    bool ret = movelladot_pc_sdkPINVOKE.XsStringImpl_contains(swigCPtr, needle);
    return ret;
  }

  public void removeDuplicates() {
    movelladot_pc_sdkPINVOKE.XsStringImpl_removeDuplicates(swigCPtr);
  }

  public void removeDuplicatesPredicate(SWIGTYPE_p_f_p_q_const__void_p_q_const__void__int predicate) {
    movelladot_pc_sdkPINVOKE.XsStringImpl_removeDuplicatesPredicate(swigCPtr, SWIGTYPE_p_f_p_q_const__void_p_q_const__void__int.getCPtr(predicate));
  }

  public void sort() {
    movelladot_pc_sdkPINVOKE.XsStringImpl_sort(swigCPtr);
  }

  public void reverse() {
    movelladot_pc_sdkPINVOKE.XsStringImpl_reverse(swigCPtr);
  }

}

}
