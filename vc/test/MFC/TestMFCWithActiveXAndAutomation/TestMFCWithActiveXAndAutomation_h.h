

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Fri Jun 03 20:51:16 2016
 */
/* Compiler settings for TestMFCWithActiveXAndAutomation.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 7.00.0555 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __TestMFCWithActiveXAndAutomation_h_h__
#define __TestMFCWithActiveXAndAutomation_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ITestMFCWithActiveXAndAutomation_FWD_DEFINED__
#define __ITestMFCWithActiveXAndAutomation_FWD_DEFINED__
typedef interface ITestMFCWithActiveXAndAutomation ITestMFCWithActiveXAndAutomation;
#endif 	/* __ITestMFCWithActiveXAndAutomation_FWD_DEFINED__ */


#ifndef __TestMFCWithActiveXAndAutomation_FWD_DEFINED__
#define __TestMFCWithActiveXAndAutomation_FWD_DEFINED__

#ifdef __cplusplus
typedef class TestMFCWithActiveXAndAutomation TestMFCWithActiveXAndAutomation;
#else
typedef struct TestMFCWithActiveXAndAutomation TestMFCWithActiveXAndAutomation;
#endif /* __cplusplus */

#endif 	/* __TestMFCWithActiveXAndAutomation_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __TestMFCWithActiveXAndAutomation_LIBRARY_DEFINED__
#define __TestMFCWithActiveXAndAutomation_LIBRARY_DEFINED__

/* library TestMFCWithActiveXAndAutomation */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_TestMFCWithActiveXAndAutomation;

#ifndef __ITestMFCWithActiveXAndAutomation_DISPINTERFACE_DEFINED__
#define __ITestMFCWithActiveXAndAutomation_DISPINTERFACE_DEFINED__

/* dispinterface ITestMFCWithActiveXAndAutomation */
/* [uuid] */ 


EXTERN_C const IID DIID_ITestMFCWithActiveXAndAutomation;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("D2303C8A-E76A-473B-A69D-595EC1382663")
    ITestMFCWithActiveXAndAutomation : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct ITestMFCWithActiveXAndAutomationVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ITestMFCWithActiveXAndAutomation * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ITestMFCWithActiveXAndAutomation * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ITestMFCWithActiveXAndAutomation * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            ITestMFCWithActiveXAndAutomation * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            ITestMFCWithActiveXAndAutomation * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            ITestMFCWithActiveXAndAutomation * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            ITestMFCWithActiveXAndAutomation * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } ITestMFCWithActiveXAndAutomationVtbl;

    interface ITestMFCWithActiveXAndAutomation
    {
        CONST_VTBL struct ITestMFCWithActiveXAndAutomationVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ITestMFCWithActiveXAndAutomation_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define ITestMFCWithActiveXAndAutomation_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define ITestMFCWithActiveXAndAutomation_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define ITestMFCWithActiveXAndAutomation_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define ITestMFCWithActiveXAndAutomation_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define ITestMFCWithActiveXAndAutomation_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define ITestMFCWithActiveXAndAutomation_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __ITestMFCWithActiveXAndAutomation_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_TestMFCWithActiveXAndAutomation;

#ifdef __cplusplus

class DECLSPEC_UUID("BB224350-E6E2-4DD1-92F5-8B6818E0EDB7")
TestMFCWithActiveXAndAutomation;
#endif
#endif /* __TestMFCWithActiveXAndAutomation_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


