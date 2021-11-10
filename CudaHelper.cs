using System;
using System.IO;
using GK_P2.Bitmap;
using GK_P2.Properties;
using ManagedCuda;

namespace GK_P2
{
    class CudaHelper
    {
        private static CudaHelper instance;

        public static CudaHelper GetInstance()
        {
            if (instance == null) instance = new CudaHelper();
            return instance;
        }

        private CudaContext ctx;
        private CudaKernel cudaKernel;

        private CudaHelper()
        {
            this.ctx = new CudaContext(CudaContext.GetMaxGflopsDeviceId());
            Stream stream = new MemoryStream(Resources.GetColor);//;File.OpenRead(@"F:\Edukacja\Studia\Sem 5\GrafikaKomputerowa\CUDA\CUDA\CudaProgramme2\GetColor.ptx");

            if (stream == null) throw new ArgumentException("Kernel not found in resources.");

            this.cudaKernel = ctx.LoadKernelPTX(stream, "VecAdd");
        }

        public void Calculate(PixelStruct[] pixels, PointStruct lightV, ColorStruct lightColor, int N, out Int32[] result)
        {
            CudaDeviceVariable<Int32> deviceResult = new CudaDeviceVariable<Int32>(N);
            CudaDeviceVariable<PixelStruct> devicePixels = pixels;

            int threadsPerBlock = 256;
            this.cudaKernel.BlockDimensions = threadsPerBlock;
            this.cudaKernel.GridDimensions = (N + threadsPerBlock - 1) / threadsPerBlock;

            this.cudaKernel.Run(
                devicePixels.DevicePointer,
                lightColor,
                lightV,
                (float)Settings.Kd,
                (float)Settings.Ks,
                Settings.M,
                N,
                deviceResult.DevicePointer
            );

            result = deviceResult;

            deviceResult.Dispose();
            devicePixels.Dispose();
        }
    }
}
