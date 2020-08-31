using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DiscordExplorer.CacheParser
{
    internal class Util
    {
        internal static T ByteToType<T>(BinaryReader reader)
        {
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();

            return theStructure;
        }

		internal static void ReplaceByte(ref byte[] arr, byte before, byte after)
		{
			for (int i = 0; i < arr.Length; i++) 
			{
				if (arr[i] == before)
					arr[i] = after;
			}
		}

		internal static byte[] ReadNBytesFrom(string filename, long offset, int count)
		{
			if (!File.Exists(filename))
				throw new FileNotFoundException($"Couldn't open file [{filename}]");

			FileStream fs = new FileStream(filename, FileMode.Open);
			fs.Seek(offset, SeekOrigin.Begin);

			BinaryReader br = new BinaryReader(fs);
			byte[] outBuffer = br.ReadBytes((int)count);
			return outBuffer;
		}

		internal static byte[] SliceByteArray(byte[] orig, UInt32 start, UInt32 end)
		{
			return new List<byte>(orig).GetRange((int)start, (int)end).ToArray();
		}
	
		internal static DateTime ConvertWebkitTime(ulong timestamp)
		{
			TimeSpan time = TimeSpan.FromMilliseconds((double)(timestamp/1000));
			DateTime date = new DateTime(1601, 1, 1) + time;
			return date;
		}

		internal static object CreateDynamicList(Type type, params object[] args)
		{
			Type specificType = typeof(List<>).MakeGenericType(new Type[] { type } );
			return Activator.CreateInstance(specificType, args);
		}
    }
}
