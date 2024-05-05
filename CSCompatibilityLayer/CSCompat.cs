using SharpDX.Direct3D9;
using System;
using System.Runtime.InteropServices;


namespace CSCompatibilityLayer
{
    //Resolves language incompatibility issues between C# and VB for 3rd-party code
    public class CSCompat
    {
        public static void SetTransformation(ref Device device, ref TransformState transformState, ref SharpDX.Matrix matrix)
        {
            device.SetTransform(transformState, matrix);
        }

        public static Mesh CreateSphere(ref Device device, float radius, int slices, int stacks)
        {
            CreateSphere(device, radius, slices, stacks, out Mesh mesh);
            return mesh;
        }

        //From: https://github.com/sharpdx/SharpDX/blob/master/Source/SharpDX.Direct3D9/Generated/Functions.cs
        private static void CreateSphere(Device deviceRef, float radius, int slices, int stacks, out Mesh meshOut)
        {
            unsafe
            {
                IntPtr meshOut_ = IntPtr.Zero;
                SharpDX.Result result = D3DXCreateSphere_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), radius, slices, stacks, &meshOut_, null);
                meshOut = (meshOut_ == IntPtr.Zero) ? null : new Mesh(meshOut_);
                result.CheckError();
            }
        }

        [DllImport("d3dx9_43.dll", EntryPoint = "D3DXCreateSphere", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int D3DXCreateSphere_(void* arg0, float arg1, int arg2, int arg3, void* arg4, void* arg5);

        public static Mesh CreateBox(ref Device device, float width, float height, float depth)
        {
            CreateBox(device, width, height, depth, out Mesh mesh);
            return mesh;
        }

        private static void CreateBox(Device deviceRef, float width, float height, float depth, out Mesh meshOut)
        {
            unsafe
            {
                IntPtr meshOut_ = IntPtr.Zero;
      
                SharpDX.Result result = D3DXCreateBox_((void*)((deviceRef == null) ? IntPtr.Zero : deviceRef.NativePointer), width, height, depth, &meshOut_, null);
                meshOut = (meshOut_ == IntPtr.Zero) ? null : new Mesh(meshOut_);
                result.CheckError();
            }
        }

        [DllImport("d3dx9_43.dll", EntryPoint = "D3DXCreateBox", CallingConvention = CallingConvention.StdCall)]
        private unsafe static extern int D3DXCreateBox_(void* arg0, float arg1, float arg2, float arg3, void* arg4, void* arg5);
    }
}
