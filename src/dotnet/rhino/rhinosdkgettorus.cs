#pragma warning disable 1591
#if RHINO_SDK
using System;

namespace Rhino.Input.Custom
{
  /// <summary>
  /// Class provides user interface to define a torus.
  /// </summary>
  public class GetTorus : IDisposable
  {
    IntPtr m_ptr_argsrhinogettorus;

    public GetTorus()
    {
      m_ptr_argsrhinogettorus = UnsafeNativeMethods.CArgsRhinoGetTorus_New();
    }

    IntPtr ConstPointer() { return m_ptr_argsrhinogettorus; }
    IntPtr NonConstPointer() { return m_ptr_argsrhinogettorus; }

    /// <summary>
    /// Passively reclaims unmanaged resources when the class user did not explicitly call Dispose().
    /// </summary>
    ~GetTorus()
    {
      Dispose(false);
    }

    /// <summary>
    /// Actively reclaims unmanaged resources that this instance uses.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// For derived class implementers.
    /// <para>This method is called with argument true when class user calls Dispose(), while with argument false when
    /// the Garbage Collector invokes the finalizer, or Finalize() method.</para>
    /// <para>You must reclaim all used unmanaged resources in both cases, and can use this chance to call Dispose on disposable fields if the argument is true.</para>
    /// <para>Also, you must call the base virtual method within your overriding method.</para>
    /// </summary>
    /// <param name="disposing">true if the call comes from the Dispose() method; false if it comes from the Garbage Collector finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
      if (IntPtr.Zero != m_ptr_argsrhinogettorus)
      {
        UnsafeNativeMethods.CArgsRhinoGetTorus_Delete(m_ptr_argsrhinogettorus);
        m_ptr_argsrhinogettorus = IntPtr.Zero;
      }
    }

    bool GetBool(UnsafeNativeMethods.ArgsGetCircleBoolConsts which)
    {
      IntPtr const_ptr_this = ConstPointer();
      return UnsafeNativeMethods.CArgsRhinoGetCircle_GetBool(const_ptr_this, which);
    }

    void SetBool(UnsafeNativeMethods.ArgsGetCircleBoolConsts which, bool value)
    {
      IntPtr ptr_this = NonConstPointer();
      UnsafeNativeMethods.CArgsRhinoGetCircle_SetBool(ptr_this, which, value);
    }

    /// <summary>
    /// Default radius or diameter (based on InDiameterMode)
    /// </summary>
    public double DefaultSize
    {
      get
      {
        IntPtr const_ptr_this = ConstPointer();
        return UnsafeNativeMethods.CArgsRhinoGetCircle_DefaultSize(const_ptr_this);
      }
      set
      {
        IntPtr ptr_this = NonConstPointer();
        UnsafeNativeMethods.CArgsRhinoGetCircle_SetDefaultSize(ptr_this, value);
      }
    }

    /// <summary>
    /// Determines if the "size" value is reperesenting a radius or diameter
    /// </summary>
    public bool InDiameterMode
    {
      get { return GetBool(UnsafeNativeMethods.ArgsGetCircleBoolConsts.UseDiameterMode); }
      set { SetBool(UnsafeNativeMethods.ArgsGetCircleBoolConsts.UseDiameterMode, value); }
    }

    /// <summary>
    /// Second radius opion. The first radius chosen sets the inner dimension of the torus and the second radius is constrained to be outside of the first radius.
    /// </summary>
    public bool FixInnerRadius
    {
      get
      {
        IntPtr const_ptr_this = ConstPointer();
        return UnsafeNativeMethods.CArgsRhinoGetTorus_FixInnerRadius(const_ptr_this);
      }
      set
      {
        IntPtr ptr_this = NonConstPointer();
        UnsafeNativeMethods.CArgsRhinoGetTorus_SetFixInnerRadius(ptr_this, value);
      }
    }

    /// <summary>
    /// Second radius opion. Determines if the second "size" value is reperesenting a radius or diameter
    /// </summary>
    public bool InSecondDiameterMode
    {
      get
      {
        IntPtr const_ptr_this = ConstPointer();
        return UnsafeNativeMethods.CArgsRhinoGetTorus_DiameterRadius(const_ptr_this);
      }
      set
      {
        IntPtr ptr_this = NonConstPointer();
        UnsafeNativeMethods.CArgsRhinoGetTorus_SetDiameterRadius(ptr_this, value);
      }
    }

    /// <summary>
    /// Second radius or diameter (based on InSecondDiameterMode)
    /// </summary>
    public double SecondSize
    {
      get
      {
        IntPtr const_ptr_this = ConstPointer();
        return UnsafeNativeMethods.CArgsRhinoGetTorus_SecondRadius(const_ptr_this);
      }
      set
      {
        IntPtr ptr_this = NonConstPointer();
        UnsafeNativeMethods.CArgsRhinoGetTorus_SetSecondRadius(ptr_this, value);
      }
    }

    /// <summary>
    /// Prompt for the getting of a torus.
    /// </summary>
    /// <param name="torus">The torus geometry defined by the user.</param>
    /// <returns>The result of the getting operation.</returns>
    public Commands.Result Get(out Geometry.Torus torus)
    {
      IntPtr ptr_this = NonConstPointer();
      torus = Geometry.Torus.Unset;
      uint rc = UnsafeNativeMethods.RHC_RhinoGetTorus(ref torus, ptr_this);
      return (Commands.Result)rc;
    }

    /// <summary>
    /// Prompt for the getting of a mesh torus.
    /// </summary>
    /// <param name="verticalFaces">The number of faces in the vertical direction.</param>
    /// <param name="aroundFaces">The number of faces in the around direction</param>
    /// <param name="torus">The torus geometry defined by the user.</param>
    /// <returns>The result of the getting operation.</returns>
    public Commands.Result GetMesh(ref int verticalFaces, ref int aroundFaces, out Geometry.Torus torus)
    {
      IntPtr ptr_this = NonConstPointer();
      torus = Geometry.Torus.Unset;
      uint rc = UnsafeNativeMethods.RHC_RhinoGetMeshTorus(ref torus, ref verticalFaces, ref aroundFaces, ptr_this);
      return (Commands.Result)rc;
    }

  }
}
#endif
